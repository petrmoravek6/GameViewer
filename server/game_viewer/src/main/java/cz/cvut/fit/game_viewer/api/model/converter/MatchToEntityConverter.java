package cz.cvut.fit.game_viewer.api.model.converter;

import cz.cvut.fit.game_viewer.api.model.MatchDto;
import cz.cvut.fit.game_viewer.dao.player.PlayerRepository;
import cz.cvut.fit.game_viewer.dao.team.TeamRepository;
import cz.cvut.fit.game_viewer.domain.match.AgeLimit;
import cz.cvut.fit.game_viewer.domain.match.Match;
import cz.cvut.fit.game_viewer.domain.player.Player;
import org.springframework.stereotype.Component;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.Collection;
import java.util.function.Function;

@Component
public class MatchToEntityConverter implements Function<MatchDto, Match> {
  private final TeamRepository teamRepository;
  private final PlayerRepository playerRepository;
  public MatchToEntityConverter(TeamRepository teamRepository, PlayerRepository playerRepository) {
    this.teamRepository = teamRepository;
    this.playerRepository = playerRepository;
  }
  @Override
  public Match apply(MatchDto matchDto) {
    var players = new ArrayList<Player>();
    if (matchDto.getParticipants() != null) {
      playerRepository.findAllById(matchDto.getParticipants()).forEach(players::add);
    }
    return new Match(matchDto.getId(), matchDto.getHomeTeamScore(), matchDto.getAwayTeamScore(), AgeLimit.valueOf(matchDto.getAgeLimit()),
            LocalDate.of(matchDto.getYear(), matchDto.getMonth(), matchDto.getDay()), teamRepository.findById(matchDto.getHomeTeam()).get(),
            teamRepository.findById(matchDto.getAwayTeam()).get(), players);
  }
}
