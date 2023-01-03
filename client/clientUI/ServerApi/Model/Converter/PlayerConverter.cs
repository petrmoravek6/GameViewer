using clientUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.ServerApi.Model.Converter
{
    public class PlayerConverter : IConverter<Player, PlayerDto>
    {
        private readonly TeamRequester teamRequester;

        public PlayerConverter(TeamRequester teamRequester)
        {
            this.teamRequester = teamRequester;
        }

        public PlayerDto ToDto(Player entity)
        {
            return new PlayerDto(entity.getId(), entity.name, entity.dateOfBirth.Day, entity.dateOfBirth.Month, entity.dateOfBirth.Year,
                entity.position.ToString(), entity.team.getId().Value);
        }

        public Player ToEntity(PlayerDto dto)
        {
            return new Player(dto.getId(), dto.name, new DateTime(dto.yearOfBirth, dto.monthOfBirth, dto.dayOfBirth),
                (PlayerPosition)Enum.Parse(typeof(PlayerPosition), dto.position), teamRequester.Get(dto.team));
        }
    }
}
