package cz.cvut.fit.game_viewer.api.model.converter;

import cz.cvut.fit.game_viewer.api.model.PlayerDto;
import cz.cvut.fit.game_viewer.dao.match.MatchRepository;
import cz.cvut.fit.game_viewer.dao.team.TeamRepository;
import cz.cvut.fit.game_viewer.domain.match.Match;
import cz.cvut.fit.game_viewer.domain.player.Player;
import cz.cvut.fit.game_viewer.domain.player.PlayerPosition;
import org.springframework.stereotype.Component;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.function.Function;


@Component
public class PlayerToEntityConverter implements Function<PlayerDto, Player> {
  private final MatchRepository matchRepository;
  private final TeamRepository teamRepository;

  public PlayerToEntityConverter(MatchRepository matchRepository, TeamRepository teamRepository) {
    this.matchRepository = matchRepository;
    this.teamRepository = teamRepository;
  }

  @Override
  public Player apply(PlayerDto playerDto) {
    var matches = new ArrayList<Match>();
    matchRepository.findAllById(playerDto.getMatchesPlayed()).forEach(matches::add);
    return new Player(playerDto.getId(), playerDto.getName(), LocalDate.of(playerDto.getYearOfBirth(), playerDto.getMonthOfBirth(), playerDto.getDayOfBirth()),
            PlayerPosition.valueOf(playerDto.getPosition()), teamRepository.findById(playerDto.getTeam()).get(),
            matches);
  }
}
