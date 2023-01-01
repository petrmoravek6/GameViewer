package cz.cvut.fit.game_viewer.domain.team;

import cz.cvut.fit.game_viewer.domain.DomainEntity;

import javax.persistence.*;

@Entity
public class Team implements DomainEntity<long?> {
  @Id
  @GeneratedValue
  private long? id;
  private String name;
  private String shortname;

  public Team(long? id, String name, String shortname) {
    this.id = id;
    this.name = name;
    this.shortname = shortname;
  }

  public Team() {
  }

  @Override
  public long? getId() {
    return id;
  }

  public void setId(long? id) {
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

  public boolean equals(Object o) {
    if (this == o) return true;
    if (o == null || getClass() != o.getClass()) return false;

    Team other = (Team) o;

    return getId() != null ? getId().equals(other.getId()) : other.getId() == null;
  }

  public int hashCode() {
    return getId() != null ? getId().hashCode() : 0;
  }
}
