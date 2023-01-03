namespace clientUI.Model;

public class Match : GameModel<long?>
{
    private long? id;
    public int homeTeamScore;
    public int awayTeamScore;
    public AgeLimit ageLimit;
    public DateTime dateOfTheMatch;
    public Team homeTeam;
    public Team awayTeam;
    public readonly List<Player> participants;

    public Match(long? id, int homeTeamScore, int awayTeamScore, AgeLimit ageLimit, DateTime dateOfTheMatch, Team homeTeam, Team awayTeam, List<Player> participants)
    {
        this.id = id;
        this.homeTeamScore = homeTeamScore;
        this.awayTeamScore = awayTeamScore;
        this.ageLimit = ageLimit;
        this.dateOfTheMatch = dateOfTheMatch;
        this.homeTeam = homeTeam;
        this.awayTeam = awayTeam;
        this.participants = participants;
    }

    public long? getId()
    {
        return id;
    }

    public void setId(long? id)
    {
        this.id = id;
    }

    public override bool Equals(object? obj)
    {
        return obj is Match match &&
               id == match.id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(id);
    }

    public T apply<T>(Visitor<T> visitor)
    {
        return visitor.VisitMatch(this);
    }
}
