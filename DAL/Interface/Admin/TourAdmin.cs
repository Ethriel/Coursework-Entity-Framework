using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Helpers;
using DAL.Interface.Interfaces;
using DAL.Model;

namespace DAL.Interface.Admin
{
    public class TourAdmin : IEntityAdmin<Tour>
    {
        TravelAgencyContext tac;
        public TourAdmin()
        {
            tac = ContextHelper.GetContext();
        }
        public void Add(Tour entity)
        {
            var a = tac.Tours.FirstOrDefault(x => x.Id.Equals(entity.Id));
            if (a == null)
            {
                tac.Tours.Add(entity);
                tac.SaveChanges();
            }
            else
            {
                throw new Exception("Tour already exists in database!");
            }
        }
        public void Remove(Tour entity)
        {
            Find(entity.TourName);
            tac.Tours.Remove(entity);
            tac.SaveChanges();
        }
        public void Update(int id, Tour newEntity)
        {
            var a = FindById(id);
            if (a != null)
            {
                a = newEntity;
                tac.SaveChanges();
            }
            else
            {
                throw new Exception("Tour does not exist in database!");
            }
        }
        public Tour Find(string name)
        {
            return tac.Tours.FirstOrDefault(x => x.TourName.ToLower().Equals(name.ToLower())) ?? throw new Exception("Tour not found");
        }
        public Tour FindById(int id)
        {
            return tac.Tours.FirstOrDefault(x => x.Id.Equals(id)) ?? throw new Exception("Tour was not found");
        }
        public Tour Get(int id)
        {
            return tac.Tours.Find(id) ?? throw new Exception("No tour to show");
        }
        public ICollection<Tour> GetEntities()
        {
            return tac.Tours.ToList() ?? throw new Exception("No tours to show");
        }

        public void AddRange(ICollection<Tour> entities)
        {
            tac.Tours.AddRange(entities);
            tac.SaveChanges();
        }

        public void RemoveRange(ICollection<Tour> entities)
        {
            tac.Tours.RemoveRange(entities);
            tac.SaveChanges();
        }
    }
}
