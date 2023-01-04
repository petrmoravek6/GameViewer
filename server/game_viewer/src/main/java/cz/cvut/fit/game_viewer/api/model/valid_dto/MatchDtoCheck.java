package cz.cvut.fit.game_viewer.api.model.valid_dto;

import cz.cvut.fit.game_viewer.api.model.MatchDto;
import cz.cvut.fit.game_viewer.domain.match.AgeLimit;
import org.springframework.stereotype.Component;

import java.time.DateTimeException;
import java.time.LocalDate;
import java.util.function.Function;

@Component
public class MatchDtoCheck implements Function<MatchDto, Boolean> {
    @Override
    public Boolean apply(MatchDto dto) {
        if (dto.getHomeTeamScore() == null || dto.getAwayTeamScore() == null ||
            dto.getAgeLimit() == null || dto.getDay() == null || dto.getMonth() == null || dto.getYear() == null ||
            dto.getHomeTeam() == null || dto.getAwayTeam() == null || dto.getParticipants() == null) {
            return false;
        }
        try {
            AgeLimit.valueOf(dto.getAgeLimit());
            LocalDate.of(dto.getYear(), dto.getMonth(), dto.getDay());
        }
        catch (IllegalArgumentException | DateTimeException ignored) {
            return false;
        }
        if (dto.getParticipants().isEmpty())
            return false;

        return true;
    }
}
