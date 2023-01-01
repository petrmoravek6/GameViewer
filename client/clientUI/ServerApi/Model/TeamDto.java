package cz.cvut.fit.game_viewer.api.model;

import cz.cvut.fit.game_viewer.domain.DomainEntity;

import java.util.List;

public class TeamDto implements DomainEntity<Long> {
  Long id;
  String name;
  String shortname;

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

  public String getShortname() {
    return shortname;
  }

  public void setShortname(String shortname) {
    this.shortname = shortname;
  }
}
