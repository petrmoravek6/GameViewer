package cz.cvut.fit.game_viewer.business;

import cz.cvut.fit.game_viewer.dao.player.PlayerRepository;
import cz.cvut.fit.game_viewer.domain.player.Player;
import cz.cvut.fit.game_viewer.domain.team.Team;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.Collection;
import java.util.Collections;
import java.util.HashSet;
import java.util.NoSuchElementException;

@Service
public class PlayerService extends AbstractCrudService<Player, Long> {
  public PlayerService(PlayerRepository repository) {
    super(repository);
  }

  public Collection<Team> getAllTeamsPlayerWonAgainst(Long playerId) throws NoSuchElementException {
    var optionalPlayer = readById(playerId);
    var player = optionalPlayer.orElseThrow();

    var matchesOfPlayer = player.getMatchesPlayed();

    var res = new HashSet<Team>();
    for (var match : matchesOfPlayer) {
      if (match.getHomeTeam().equals(player.getTeam()) && match.getHomeTeamScore() > match.getAwayTeamScore())
        res.add(match.getAwayTeam());
      else if (match.getAwayTeam().equals(player.getTeam()) && match.getHomeTeamScore() < match.getAwayTeamScore())
        res.add(match.getHomeTeam());
    }
    return res;
  }
}