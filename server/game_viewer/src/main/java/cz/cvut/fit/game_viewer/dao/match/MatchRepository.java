package cz.cvut.fit.game_viewer.dao.match;

import cz.cvut.fit.game_viewer.domain.match.Match;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Repository;

@Repository
public interface MatchRepository extends CrudRepository<Match, Long> {
}
