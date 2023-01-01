package cz.cvut.fit.game_viewer.api.model;

import cz.cvut.fit.game_viewer.api.model.converter.TeamToEntityConverter;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

@SpringBootTest
public class TeamToEntityConverterTest {

  @Autowired
  TeamToEntityConverter teamToEntityConverter;

  @Test
  void apply() {
    TeamDto dto1 = new TeamDto();
    dto1.setId(123L);
    dto1.setName("FK Praha");
    dto1.setShortname("FKP");
    TeamDto dto2 = new TeamDto();
    dto2.setId(0L);
    dto2.setName("");
    dto2.setShortname("");
    TeamDto dto3 = new TeamDto();
    dto3.setId(333L);
    dto3.setName("FK Brno");
    dto3.setShortname("FKB");

    var team1 = teamToEntityConverter.apply(dto1);
    var team2 = teamToEntityConverter.apply(dto2);
    var team3 = teamToEntityConverter.apply(dto3);

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
