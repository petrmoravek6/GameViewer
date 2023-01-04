package cz.cvut.fit.game_viewer.api.controller;

import cz.cvut.fit.game_viewer.api.model.TeamDto;
import cz.cvut.fit.game_viewer.api.model.converter.TeamToDtoConverter;
import cz.cvut.fit.game_viewer.api.model.converter.TeamToEntityConverter;
import cz.cvut.fit.game_viewer.api.model.valid_dto.TeamDtoCheck;
import cz.cvut.fit.game_viewer.business.TeamService;
import cz.cvut.fit.game_viewer.domain.team.Team;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Collection;

@RestController
@RequestMapping("/team")
public class TeamController extends AbstractCrudController<Team, TeamDto, Long> {
  public TeamController(TeamService service, TeamToDtoConverter toDtoConverter, TeamToEntityConverter toEntityConverter,
                        TeamDtoCheck teamDtoCheck) {
    super(service, toDtoConverter, toEntityConverter, teamDtoCheck);
  }

  @GetMapping
  public Collection<TeamDto> readAll() {return super.readAll();}
}
