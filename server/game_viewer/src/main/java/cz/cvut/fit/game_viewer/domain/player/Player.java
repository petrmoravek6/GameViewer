package cz.cvut.fit.game_viewer.domain.player;

import cz.cvut.fit.game_viewer.domain.DomainEntity;
import cz.cvut.fit.game_viewer.domain.match.Match;
import cz.cvut.fit.game_viewer.domain.team.Team;

import javax.persistence.*;
import java.time.LocalDate;
import java.util.Collection;

@Entity
public class Player implements DomainEntity<Long> {
  @Id
  @GeneratedValue
  private Long id;
  private String name;
  private LocalDate dateOfBirth;
  private PlayerPosition position;
  /**
   * The team which the player plays in.
   */
  @ManyToOne
  private Team team;
  /**
   * The matches that the player participates in.
   */
  @ManyToMany(mappedBy = "participants", fetch = FetchType.EAGER)
  private Collection<Match> matchesPlayed;


  public Player(Long id, String name, LocalDate dateOfBirth, PlayerPosition position, Team team, Collection<Match> matchesPlayed) {
    this.id = id;
    this.name = name;
    this.dateOfBirth = dateOfBirth;
    this.position = position;
    this.team = team;
    this.matchesPlayed = matchesPlayed;
  }

  public Player() {
  }

  @Override
  public Long getId() {
    return id;
  }

  public void setId(Long id) {
    this.id = id;
  }

  public String getName() {
    return name;
  }

  public void setName(String name) {
    this.name = name;
  }

  public LocalDate getDateOfBirth() {
    return dateOfBirth;
  }

  public void setDateOfBirth(LocalDate dateOfBirth) {
    this.dateOfBirth = dateOfBirth;
  }

  public PlayerPosition getPosition() {
    return position;
  }

  public void setPosition(PlayerPosition position) {
    this.position = position;
  }

  public Team getTeam() {
    return team;
  }

  public void setTeam(Team team) {
    this.team = team;
  }

  public Collection<Match> getMatchesPlayed() {
    return matchesPlayed;
  }

  public void setMatchesPlayed(Collection<Match> matchesPlayed) {
    this.matchesPlayed = matchesPlayed;
  }

  public boolean equals(Object o) {
    if (this == o) return true;
    if (o == null || getClass() != o.getClass()) return false;

    Player other = (Player) o;

    return getId() != null ? getId().equals(other.getId()) : other.getId() == null;
  }

  public int hashCode() {
    return getId() != null ? getId().hashCode() : 0;
  }
}
