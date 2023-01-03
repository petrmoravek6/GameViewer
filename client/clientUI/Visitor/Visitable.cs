using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.Model
{
    public interface Visitable
    {
        T apply<T>(Visitor<T> visitor); 
    }
}
