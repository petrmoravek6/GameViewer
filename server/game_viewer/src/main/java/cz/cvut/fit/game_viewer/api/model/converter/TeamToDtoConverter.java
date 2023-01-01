package cz.cvut.fit.game_viewer.api.model.converter;

import cz.cvut.fit.game_viewer.api.model.TeamDto;
import cz.cvut.fit.game_viewer.domain.match.Match;
import cz.cvut.fit.game_viewer.domain.player.Player;
import cz.cvut.fit.game_viewer.domain.team.Team;
import org.springframework.stereotype.Component;

import java.util.List;
import java.util.function.Function;
import java.util.stream.Collectors;

@Component
public class TeamToDtoConverter implements Function<Team, TeamDto> {
  @Override
  public TeamDto apply(Team team) {
    TeamDto res = new TeamDto();

    res.setId(team.getId());
    res.setName(team.getName());
    res.setShortname(team.getShortname());

    return res;
  }
}
