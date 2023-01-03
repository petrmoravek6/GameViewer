using clientUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.UIContext
{
    public interface Context
    {
        public List<string> ReloadAndGetMainList();

        public void CreateEntity();
        public void DisplayEntity(int idx);
        public void DeleteEntity(int idx);
    }
}
