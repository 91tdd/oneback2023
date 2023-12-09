using OneBackComboTrainingWeb.Domains;

namespace OneBackComboTrainingWeb.Repos;

public interface IMatchRepo
{
    Match GetMatch(int matchId);
    void UpdateMatchResult(Match match);
}