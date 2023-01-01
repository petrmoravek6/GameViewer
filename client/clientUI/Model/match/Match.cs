namespace Model.Match;
public class Match implements DomainEntity<long?> {


    public long? id;
    public int homeTeamScore;
    public int awayTeamScore;
    public AgeLimit ageLimit;
    public LocalDate dateOfTheMatch;
    public Team homeTeam;
    public Team awayTeam;
    public Collection<Player> participants;

  public Match(long? id, Integer homeTeamScore, Integer awayTeamScore, AgeLimit ageLimit, LocalDate dateOfTheMatch, Team homeTeam, Team awayTeam, Collection<Player> participants) {
    this.id = id;
    this.homeTeamScore = homeTeamScore;
    this.awayTeamScore = awayTeamScore;
    this.ageLimit = ageLimit;
    this.dateOfTheMatch = dateOfTheMatch;
    this.homeTeam = homeTeam;
    this.awayTeam = awayTeam;
    this.participants = participants;
  }

  

    override public long? getId() {
        return id;
    }

  public boolean equals(Object o) {
    if (this == o) return true;
    if (o == null || getClass() != o.getClass()) return false;

    Match other = (Match) o;

    return getId() != null ? getId().equals(other.getId()) : other.getId() == null;
  }

  public int hashCode() {
    return getId() != null ? getId().hashCode() : 0;
  }
}
