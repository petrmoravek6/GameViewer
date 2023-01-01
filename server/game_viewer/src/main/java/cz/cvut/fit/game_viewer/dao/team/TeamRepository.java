package cz.cvut.fit.game_viewer.dao.team;

import cz.cvut.fit.game_viewer.domain.team.Team;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Repository;

import java.util.Collection;

@Repository
public interface TeamRepository extends CrudRepository<Team, Long> {
}
