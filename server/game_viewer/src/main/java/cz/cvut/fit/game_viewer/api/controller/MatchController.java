package cz.cvut.fit.game_viewer.api.controller;

import cz.cvut.fit.game_viewer.api.model.MatchDto;
import cz.cvut.fit.game_viewer.api.model.converter.MatchToDtoConverter;
import cz.cvut.fit.game_viewer.api.model.converter.MatchToEntityConverter;
import cz.cvut.fit.game_viewer.business.MatchService;
import cz.cvut.fit.game_viewer.domain.match.Match;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Collection;

@RestController
@RequestMapping("/match")
public class MatchController extends AbstractCrudController<Match, MatchDto, Long> {
  public MatchController(MatchService service, MatchToDtoConverter toDtoConverter, MatchToEntityConverter toEntityConverter) {
    super(service, toDtoConverter, toEntityConverter);
  }

  @GetMapping
  public Collection<MatchDto> readAll() {return super.readAll();}
}
