using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.Model
{
    public interface DomainEntity<ID>
    {
        ID getId();
        void setId(ID id);
    }
}
