package cz.cvut.fit.game_viewer.api.model.converter;

import cz.cvut.fit.game_viewer.api.model.TeamDto;
import cz.cvut.fit.game_viewer.domain.team.Team;
import org.springframework.stereotype.Component;

import java.util.function.Function;

@Component
public class TeamToEntityConverter implements Function<TeamDto, Team> {
  @Override
  public Team apply(TeamDto teamDto) {
    return new Team(teamDto.getId(), teamDto.getName(), teamDto.getShortname());
  }
}
