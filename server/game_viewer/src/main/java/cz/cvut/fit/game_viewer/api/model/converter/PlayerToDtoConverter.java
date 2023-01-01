package cz.cvut.fit.game_viewer.api.model.converter;

import cz.cvut.fit.game_viewer.api.model.PlayerDto;
import cz.cvut.fit.game_viewer.domain.match.Match;
import cz.cvut.fit.game_viewer.domain.player.Player;
import org.springframework.stereotype.Component;

import java.util.List;
import java.util.function.Function;
import java.util.stream.Collectors;

@Component
public class PlayerToDtoConverter implements Function<Player, PlayerDto> {
  @Override
  public PlayerDto apply(Player player) {
    PlayerDto res = new PlayerDto();

    res.setId(player.getId());
    res.setName(player.getName());
    var dateOfBirth = player.getDateOfBirth();
    res.setDayOfBirth(dateOfBirth.getDayOfMonth());
    res.setMonthOfBirth(dateOfBirth.getMonthValue());
    res.setYearOfBirth(dateOfBirth.getYear());
    res.setPosition(player.getPosition().toString());
    res.setTeam(player.getTeam().getId());
    List<Long> matchesPlayed = player.getMatchesPlayed().stream()
            .map(Match::getId)
            .collect(Collectors.toList());
    res.setMatchesPlayed(matchesPlayed);

    return res;
  }
}
