package cz.cvut.fit.game_viewer.business;

import cz.cvut.fit.game_viewer.dao.match.MatchRepository;
import cz.cvut.fit.game_viewer.domain.match.Match;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
public class MatchService extends AbstractCrudService<Match, Long> {
  public MatchService(MatchRepository repository) {
    super(repository);
  }
}
