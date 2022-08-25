using System;

namespace Task2.Models
{
    public class Repository:IRepository
    {
        private List<Entity> data;

        public Repository(){
            data=new List<Entity>();
        }

        public List<Entity> Entitys=>data;

        public void AddEntity(Entity item){
            data.Add(item);
        }

        public Entity GetEntity(Guid id)=>data.Where(opt=>opt.Id==id).FirstOrDefault();
    }
}
