package cz.cvut.fit.game_viewer.domain.match;

import cz.cvut.fit.game_viewer.domain.DomainEntity;
import cz.cvut.fit.game_viewer.domain.player.Player;
import cz.cvut.fit.game_viewer.domain.team.Team;

import javax.persistence.*;
import java.time.LocalDate;
import java.util.Collection;

@Entity
public class Match implements DomainEntity<Long> {

  @Id
  @GeneratedValue
  private Long id;
  private Integer homeTeamScore;
  private Integer awayTeamScore;
  private AgeLimit ageLimit;
  private LocalDate dateOfTheMatch;
  @ManyToOne
  private Team homeTeam;
  @ManyToOne
  private Team awayTeam;
  @ManyToMany(fetch = FetchType.EAGER)
  private Collection<Player> participants;

  public Match(Long id, Integer homeTeamScore, Integer awayTeamScore, AgeLimit ageLimit, LocalDate dateOfTheMatch, Team homeTeam, Team awayTeam, Collection<Player> participants) {
    this.id = id;
    this.homeTeamScore = homeTeamScore;
    this.awayTeamScore = awayTeamScore;
    this.ageLimit = ageLimit;
    this.dateOfTheMatch = dateOfTheMatch;
    this.homeTeam = homeTeam;
    this.awayTeam = awayTeam;
    this.participants = participants;
  }

  public Match () {
  }

  public void setId(Long id) {
    this.id = id;
  }

  public Integer getHomeTeamScore() {
    return homeTeamScore;
  }

  public void setHomeTeamScore(Integer homeTeamScore) {
    this.homeTeamScore = homeTeamScore;
  }

  public Integer getAwayTeamScore() {
    return awayTeamScore;
  }

  public void setAwayTeamScore(Integer awayTeamScore) {
    this.awayTeamScore = awayTeamScore;
  }

  public AgeLimit getAgeLimit() {
    return ageLimit;
  }

  public void setAgeLimit(AgeLimit ageLimit) {
    this.ageLimit = ageLimit;
  }

  public LocalDate getDateOfTheMatch() {
    return dateOfTheMatch;
  }

  public void setDateOfTheMatch(LocalDate dateOfTheMatch) {
    this.dateOfTheMatch = dateOfTheMatch;
  }

  public Team getHomeTeam() {
    return homeTeam;
  }

  public void setHomeTeam(Team homeTeam) {
    this.homeTeam = homeTeam;
  }

  public Team getAwayTeam() {
    return awayTeam;
  }

  public void setAwayTeam(Team awayTeam) {
    this.awayTeam = awayTeam;
  }

  public Collection<Player> getParticipants() {
    return participants;
  }

  public void setParticipants(Collection<Player> participants) {
    this.participants = participants;
  }

  @Override
  public Long getId() {
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
