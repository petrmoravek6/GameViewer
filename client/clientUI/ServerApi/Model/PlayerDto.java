package cz.cvut.fit.game_viewer.api.model;

import cz.cvut.fit.game_viewer.domain.DomainEntity;

import java.util.List;

public class PlayerDto implements DomainEntity<Long> {
  private Long id;
  private String name;
  private Integer dayOfBirth;
  private Integer monthOfBirth;
  private Integer yearOfBirth;
  private String position;
  private Long team;
  private List<Long> matchesPlayed;

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

  public Integer getDayOfBirth() {
    return dayOfBirth;
  }

  public void setDayOfBirth(Integer dayOfBirth) {
    this.dayOfBirth = dayOfBirth;
  }

  public Integer getMonthOfBirth() {
    return monthOfBirth;
  }

  public void setMonthOfBirth(Integer monthOfBirth) {
    this.monthOfBirth = monthOfBirth;
  }

  public Integer getYearOfBirth() {
    return yearOfBirth;
  }

  public void setYearOfBirth(Integer yearOfBirth) {
    this.yearOfBirth = yearOfBirth;
  }

  public String getPosition() {
    return position;
  }

  public void setPosition(String position) {
    this.position = position;
  }

  public Long getTeam() {
    return team;
  }

  public void setTeam(Long team) {
    this.team = team;
  }

  public List<Long> getMatchesPlayed() {
    return matchesPlayed;
  }

  public void setMatchesPlayed(List<Long> matchesPlayed) {
    this.matchesPlayed = matchesPlayed;
  }
}
