package cz.cvut.fit.game_viewer.api.model.converter;

import cz.cvut.fit.game_viewer.api.model.MatchDto;
import cz.cvut.fit.game_viewer.domain.match.Match;
import cz.cvut.fit.game_viewer.domain.player.Player;
import org.springframework.stereotype.Component;

import java.util.List;
import java.util.function.Function;
import java.util.stream.Collectors;

@Component
public class MatchToDtoConverter implements Function<Match, MatchDto> {
  @Override
  public MatchDto apply(Match match) {
    MatchDto res = new MatchDto();

    res.setId(match.getId());
    res.setHomeTeamScore(match.getHomeTeamScore());
    res.setAwayTeamScore(match.getAwayTeamScore());
    res.setAgeLimit(match.getAgeLimit().toString());
    var date = match.getDateOfTheMatch();
    res.setDay(date.getDayOfMonth());
    res.setMonth(date.getMonthValue());
    res.setYear(date.getYear());
    res.setHomeTeam(match.getHomeTeam().getId());
    res.setAwayTeam(match.getAwayTeam().getId());
    List<Long> participants = match.getParticipants().stream()
            .map(Player::getId)
            .collect(Collectors.toList());
    res.setParticipants(participants);

    return res;
  }
}
