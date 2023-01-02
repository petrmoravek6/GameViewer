namespace clientUI.Model;

public class Match : DomainEntity<long?>
{
    private long? id;
    public int homeTeamScore;
    public int awayTeamScore;
    public AgeLimit ageLimit;
    public DateTime dateOfTheMatch;
    public Team homeTeam;
    public Team awayTeam;
    private readonly PlayerService playerService;

    public readonly ISet<Player> participants
    {
        get
        {
            return participants;
        }
    }

    public Match(long? id, int homeTeamScore, int awayTeamScore, AgeLimit ageLimit, DateTime dateOfTheMatch, Team homeTeam, Team awayTeam, PlayerService playerService)
    {
        this.id = id;
        this.homeTeamScore = homeTeamScore;
        this.awayTeamScore = awayTeamScore;
        this.ageLimit = ageLimit;
        this.dateOfTheMatch = dateOfTheMatch;
        this.homeTeam = homeTeam;
        this.awayTeam = awayTeam;
        this.playerService = playerService;
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
}
