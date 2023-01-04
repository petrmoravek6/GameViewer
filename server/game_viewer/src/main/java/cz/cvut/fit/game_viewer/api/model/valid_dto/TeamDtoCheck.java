package cz.cvut.fit.game_viewer.api.model.valid_dto;

import cz.cvut.fit.game_viewer.api.model.TeamDto;
import org.springframework.stereotype.Component;

import java.util.function.Function;

@Component
public class TeamDtoCheck implements Function<TeamDto, Boolean> {
    @Override
    public Boolean apply(TeamDto dto) {
        if (dto.getName() == null || dto.getShortname() == null) {
            return false;
        }

        return true;
    }
}
