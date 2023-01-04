package cz.cvut.fit.game_viewer.api.controller;

import cz.cvut.fit.game_viewer.api.model.PlayerDto;
import cz.cvut.fit.game_viewer.api.model.TeamDto;
import cz.cvut.fit.game_viewer.api.model.converter.PlayerToDtoConverter;
import cz.cvut.fit.game_viewer.api.model.converter.PlayerToEntityConverter;
import cz.cvut.fit.game_viewer.api.model.converter.TeamToDtoConverter;
import cz.cvut.fit.game_viewer.api.model.valid_dto.PlayerDtoCheck;
import cz.cvut.fit.game_viewer.business.PlayerService;
import cz.cvut.fit.game_viewer.domain.player.Player;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Collection;
import java.util.NoSuchElementException;

@RestController
@RequestMapping("/player")
public class PlayerController extends AbstractCrudController<Player, PlayerDto, Long> {

  private final TeamToDtoConverter teamToDtoConverter;

  public PlayerController(PlayerService service, PlayerToDtoConverter toDtoConverter, PlayerToEntityConverter toEntityConverter,
                          TeamToDtoConverter teamToDtoConverter, PlayerDtoCheck playerDtoCheck) {
    super(service, toDtoConverter, toEntityConverter, playerDtoCheck);
    this.teamToDtoConverter = teamToDtoConverter;
  }

  @GetMapping
  public Collection<PlayerDto> readAll() {return super.readAll();}

  @GetMapping("/{id}/won_teams")
  public ResponseEntity<Collection<TeamDto>> readTeamsPlayerWonAgainst(@PathVariable Long id) {
    try {
      var res = ((PlayerService)service).getAllTeamsPlayerWonAgainst(id);
      return ResponseEntity.ok(res.stream().map(teamToDtoConverter::apply).toList());
    }
    catch (NoSuchElementException e) {
      return ResponseEntity.notFound().build();
    }

  }

}
