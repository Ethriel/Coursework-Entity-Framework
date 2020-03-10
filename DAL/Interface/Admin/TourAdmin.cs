using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public async void RemoveAsync(Tour entity)
        {
            await FindByNameAsync(entity.TourName);
            tac.Tours.Remove(entity);
            tac.SaveChanges();
        }
        public async void UpdateAsync(int id, Tour newEntity)
        {
            var a = await FindByIdAsync(id);
            a = newEntity;
            tac.SaveChanges();
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
        public void MarkNotRelevant()
        {
            var tours = tac.Tours.ToList();
            for (int i = 0; i < tours.Count; i++)
            {
                if (tours[i].EndDate < DateTime.Now)
                {
                    tours[i].IsDeleted = true;
                }
            }
            tac.SaveChanges();
        }

        public async Task<Tour> FindByNameAsync(string name)
        {
            return await tac.Tours.FirstOrDefaultAsync(x => x.TourName.ToLower().Equals(name.ToLower())) ?? throw new Exception("Tour not found");
        }

        public async Task<Tour> FindByIdAsync(int id)
        {
            return await tac.Tours.FindAsync(id) ?? throw new Exception("Tour was not found");
        }

        public async Task<Tour> GetAsync(int id)
        {
            return await tac.Tours.FirstOrDefaultAsync(x => x.Id.Equals(id)) ?? throw new Exception("No tour to show");
        }

        public async Task<ICollection<Tour>> GetEntitiesAsync()
        {
            var tours = await tac.Tours.ToListAsync();
            return tours.Count > 0 ? tours : throw new Exception("No tours to show");
        }
    }
}
