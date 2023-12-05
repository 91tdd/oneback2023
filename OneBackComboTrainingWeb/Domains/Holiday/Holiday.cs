namespace OneBackComboTrainingWeb.Domains.Holiday;

public class Holiday
{
    public string GetTheme()
    {
        var today = GetToday();
        if (today.Month == 12 && (today.Day == 25 || today.Day == 24))
        {
            return "Merry Xmas";
        }

        return "Today is not Xmas";
    }

    protected virtual DateTime GetToday()
    {
        return DateTime.Today;
    }
}