package cz.cvut.fit.game_viewer.api.model.valid_dto;

import cz.cvut.fit.game_viewer.api.model.PlayerDto;
import cz.cvut.fit.game_viewer.domain.player.PlayerPosition;
import org.springframework.stereotype.Component;

import java.time.DateTimeException;
import java.time.LocalDate;
import java.util.function.Function;

@Component
public class PlayerDtoCheck implements Function<PlayerDto, Boolean> {
    @Override
    public Boolean apply(PlayerDto dto) {
        if (dto.getName() == null || dto.getPosition() == null ||
            dto.getDayOfBirth() == null || dto.getMonthOfBirth() == null || dto.getYearOfBirth() == null ||
            dto.getTeam() == null || dto.getMatchesPlayed() == null) {
            return false;
        }
        try {
            PlayerPosition.valueOf(dto.getPosition());
            LocalDate.of(dto.getYearOfBirth(), dto.getMonthOfBirth(), dto.getDayOfBirth());
        }
        catch (IllegalArgumentException | DateTimeException ignored) {
            return false;
        }

        return true;
    }
}
