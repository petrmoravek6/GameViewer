using clientUI.Model;
using clientUI.ServerApi.Model;
using clientUI.ServerApi.Model.Converter;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.ServerApi
{
    public class MatchRequester : CrudRequester<long?, Match, MatchDto>
    {
        public MatchRequester(string basePath, MatchConverter converter) : base(basePath, "match", converter)
        {
        }
    }
}
