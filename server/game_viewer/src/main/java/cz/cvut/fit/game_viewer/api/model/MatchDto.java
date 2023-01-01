package cz.cvut.fit.game_viewer.api.model;

import cz.cvut.fit.game_viewer.domain.DomainEntity;

import java.util.List;

public class MatchDto implements DomainEntity<Long> {
  private Long id;
  private Integer homeTeamScore;
  private Integer awayTeamScore;
  private String ageLimit;
  private Integer day;
  private Integer month;
  private Integer year;
  private Long homeTeam;
  private Long awayTeam;
  private List<Long> participants;

  public Long getId() {
    return id;
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

  public String getAgeLimit() {
    return ageLimit;
  }

  public void setAgeLimit(String ageLimit) {
    this.ageLimit = ageLimit;
  }

  public Integer getDay() {
    return day;
  }

  public void setDay(Integer day) {
    this.day = day;
  }

  public Integer getMonth() {
    return month;
  }

  public void setMonth(Integer month) {
    this.month = month;
  }

  public Integer getYear() {
    return year;
  }

  public void setYear(Integer year) {
    this.year = year;
  }

  public Long getHomeTeam() {
    return homeTeam;
  }

  public void setHomeTeam(Long homeTeam) {
    this.homeTeam = homeTeam;
  }

  public Long getAwayTeam() {
    return awayTeam;
  }

  public void setAwayTeam(Long awayTeam) {
    this.awayTeam = awayTeam;
  }

  public List<Long> getParticipants() {
    return participants;
  }

  public void setParticipants(List<Long> participants) {
    this.participants = participants;
  }
}
