using clientUI.Model;
using clientUI.ServerApi.Model;
using clientUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.UIContext
{
    public class MatchContext : GameModelContext<long?, Match, MatchDto>
    {
        public MatchContext(MatchService service) : base(service)
        {
        }

        public override void CreateEntity()
        {
            throw new NotImplementedException();
        }

        public override void DeleteEntity(int idx)
        {
            throw new NotImplementedException();
        }

        public override void DisplayEntity(int idx)
        {
            throw new NotImplementedException();
        }
    }
}
