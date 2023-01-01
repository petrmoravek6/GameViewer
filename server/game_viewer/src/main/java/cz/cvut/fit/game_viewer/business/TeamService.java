package cz.cvut.fit.game_viewer.business;

import cz.cvut.fit.game_viewer.dao.team.TeamRepository;
import cz.cvut.fit.game_viewer.domain.team.Team;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.Collection;
import java.util.Collections;

@Service
public class TeamService extends AbstractCrudService<Team, Long> {
  public TeamService(TeamRepository repository) {
    super(repository);
  }
}
