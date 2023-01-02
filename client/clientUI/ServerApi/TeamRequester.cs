using clientUI.Model;
using clientUI.ServerApi.Model;
using clientUI.ServerApi.Model.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.ServerApi
{
    internal class TeamRequester : CrudRequester<long?, Team, TeamDto>
    {
        public TeamRequester(string basePath, string parameter, IConverter<Team, TeamDto> converter) : base(basePath, parameter, converter)
        {
        }
    }
}
