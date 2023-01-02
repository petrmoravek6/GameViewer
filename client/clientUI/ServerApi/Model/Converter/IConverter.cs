using clientUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.ServerApi.Model.Converter
{
    public interface IConverter<E, DTO>
    {
        public abstract DTO ToDto(E entity);
        public abstract E ToEntity(DTO dto);
    }
}
