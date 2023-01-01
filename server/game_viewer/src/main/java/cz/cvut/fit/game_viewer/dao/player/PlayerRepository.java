package cz.cvut.fit.game_viewer.dao.player;

import cz.cvut.fit.game_viewer.domain.player.Player;
import cz.cvut.fit.game_viewer.domain.team.Team;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Repository;

import java.util.Collection;

@Repository
public interface PlayerRepository extends CrudRepository<Player, Long> {

}
