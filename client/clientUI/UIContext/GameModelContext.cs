using clientUI.Model;
using clientUI.Services;
using clientUI.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.UIContext
{
    
    public abstract class GameModelContext<ID, TYPE, DTO> : Context where TYPE: GameModel<ID> 
    {
        protected readonly CrudService<ID, TYPE, DTO> service;

        private readonly MainFormMainListVisitor mainListVisitor = new();

        protected List<TYPE> entities;

        public GameModelContext(CrudService<ID, TYPE, DTO> service)
        {
            this.service = service;
        }

        public abstract void CreateEntity();

        public void DeleteEntity(int idx)
        {
            service.Delete(entities[idx]);
        }
        public abstract void DisplayEntity(int idx);

        public List<string> ReloadAndGetMainList()
        {
            entities = service.ReadAll();
            return entities.Select(e => e.apply(mainListVisitor)).ToList();
        }

        public async Task<List<string>> ReloadAndGetMainListAsync()
        {
            entities = await service.ReadAllAsync();
            return entities.Select(e => e.apply(mainListVisitor)).ToList();
        }
    }
}
