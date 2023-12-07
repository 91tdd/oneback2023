namespace OneBackComboTrainingWeb.Domains;

public class Size
{
    public Size(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public double Height { get; private set; }
    public double Length { get; private set; }
    public double Width { get; private set; }
}

public class Product
{
    public Product(Size size, double weight)
    {
        Size = size;
        Weight = weight;
    }

    public Size Size { get; private set; }
    public double Weight { get; private set; }
}

public class PostOffice : IShipper
{
    public double ShippingFee(Product product)
    {
        double feeByWeight = 80 + product.Weight * 10;
        double volume = product.Size.Length * product.Size.Width * product.Size.Height;
        double feeBySize = volume * 0.00002 * 1100;
        return feeByWeight < feeBySize ? feeByWeight : feeBySize;
    }
}

public class Hsinchu : IShipper
{
    public double ShippingFee(Product product)
    {
        double volume = product.Size.Length * product.Size.Width * product.Size.Height;
        if (product.Size.Length > 100 || product.Size.Width > 100 || product.Size.Height > 100)
        {
            return volume * 0.00002 * 1100 + 500;
        }
        else
        {
            return volume * 0.00002 * 1200;
        }
    }
}

public interface IShipper
{
    double ShippingFee(Product product);
}

public class Blackcat : IShipper
{
    public virtual double ShippingFee(Product product)
    {
        if (product.Weight > 20)
        {
            return 500;
        }
        else
        {
            return 100 + product.Weight * 10;
        }
    }
}

public class NotExistShipper : IShipper
{
    public double ShippingFee(Product product)
    {
        throw new ArgumentException("shipper not exist");
    }
}

public class ShipperFactory
{
    private readonly Dictionary<string, Func<IShipper>> _shipperMapping = new()
                                                                          {
                                                                              { "black cat", () => GetBlackcat() },
                                                                              { "hsinchu", () => new Hsinchu() },
                                                                              { "post office", () => new PostOffice() },
                                                                          };

    public IShipper GetShipper(string shipperName)
    {
        return _shipperMapping
               .GetValueOrDefault(shipperName,
                                  () => new NotExistShipper())
               .Invoke();
    }

    private static Blackcat GetBlackcat()
    {
        if (DateTime.Today.Year < 2024)
        {
            return new Blackcat();
        }

        return new Blackcat2024();
    }
}

internal class Blackcat2024 : Blackcat
{
    public override double ShippingFee(Product product)
    {
        return 100;
    }
}

public class Cart
{
    private readonly NotExistShipper _notExistShipper = new NotExistShipper();
    private readonly ShipperFactory _shipperFactory = new ShipperFactory();

    public double ShippingFee(string shipperName, Product product)
    {
        var shipper = _shipperFactory.GetShipper(shipperName);

        return shipper.ShippingFee(product);
    }
}