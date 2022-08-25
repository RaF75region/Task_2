using System;
using Task2.Models;

namespace Task2.Models
{
    public interface IRepository
    {
        List<Entity> Entitys{get;}

        public void AddEntity(Entity item);

        public Entity GetEntity(Guid id);

    }
}
