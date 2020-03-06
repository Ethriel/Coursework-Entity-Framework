using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Interfaces;
using DAL.Model;
using DAL.Helpers;

namespace DAL.Interface.Admin
{
    public class AttractionAdmin : IEntityAdmin<Attraction>
    {
        TravelAgencyContext tac;
        public AttractionAdmin()
        {
            tac = ContextHelper.GetContext();
        }
        public void Add(Attraction entity)
        {
            var a = tac.Attractions.FirstOrDefault(x => x.Id.Equals(entity.Id));
            if (a == null)
            {
                tac.Attractions.Add(entity);
                tac.SaveChanges();
            }
            else
            {
                throw new Exception("Attraction already exists in database!");
            }
        }
        public void Remove(Attraction entity)
        {
            Find(entity.AttractionName);
            tac.Attractions.Remove(entity);
            tac.SaveChanges();
        }
        public void Update(int id, Attraction newEntity)
        {
            var a = FindById(id);
            if (a != null)
            {
                a = newEntity;
                tac.SaveChanges();
            }
            else
            {
                throw new Exception("Attraction does not exist in database!");
            }
        }
        public Attraction Find(string name)
        {
            return tac.Attractions.FirstOrDefault(x => x.AttractionName.ToLower().Equals(name.ToLower())) ?? throw new Exception("Attraction not found");
        }
        public Attraction FindById(int id)
        {
            return tac.Attractions.FirstOrDefault(x => x.Id.Equals(id)) ?? throw new Exception("Attraction was not found");
        }
        public Attraction Get(int id)
        {
            return tac.Attractions.Find(id) ?? throw new Exception("No attraction to show");
        }
        public ICollection<Attraction> GetEntities()
        {
            return tac.Attractions.ToList() ?? throw new Exception("No attractions to show");
        }

        public void AddRange(ICollection<Attraction> entities)
        {
            tac.Attractions.AddRange(entities);
            tac.SaveChanges();
        }

        public void RemoveRange(ICollection<Attraction> entities)
        {
            tac.Attractions.RemoveRange(entities);
            tac.SaveChanges();
        }
    }
}
