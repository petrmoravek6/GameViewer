package cz.cvut.fit.game_viewer.api.model;

import cz.cvut.fit.game_viewer.api.model.converter.TeamToDtoConverter;
import cz.cvut.fit.game_viewer.domain.team.Team;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

@SpringBootTest
public class TeamToDtoConverterTest {

  @Autowired
  TeamToDtoConverter teamToDtoConverter;

  @Test
  void apply() {
    Team team1 = new Team(123L, "FK Praha", "FKP");
    Team team2 = new Team(0L, "", "");
    Team team3 = new Team(333L, "FK Brno", "FKB");

    var dto1 = teamToDtoConverter.apply(team1);
    var dto2 = teamToDtoConverter.apply(team2);
    var dto3 = teamToDtoConverter.apply(team3);

    Assertions.assertEquals(team1.getId(), dto1.getId());
    Assertions.assertEquals(team2.getId(), dto2.getId());
    Assertions.assertEquals(team3.getId(), dto3.getId());
    Assertions.assertEquals(team1.getName(), dto1.getName());
    Assertions.assertEquals(team2.getName(), dto2.getName());
    Assertions.assertEquals(team3.getName(), dto3.getName());
    Assertions.assertEquals(team1.getShortname(), dto1.getShortname());
    Assertions.assertEquals(team2.getShortname(), dto2.getShortname());
    Assertions.assertEquals(team3.getShortname(), dto3.getShortname());
  }
}
