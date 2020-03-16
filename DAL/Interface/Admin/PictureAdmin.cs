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
    public class PictureAdmin : IEntityAdmin<Picture>
    {
        TravelAgencyContext tac;
        public PictureAdmin()
        {
            tac = ContextHelper.GetContext();
        }
        public void Add(Picture entity)
        {
            var c = tac.Countries.FirstOrDefault(x => x.Id.Equals(entity.Id));
            if (c == null)
            {
                tac.Pictures.Add(entity);
                tac.SaveChanges();
            }
            else
            {
                throw new Exception("Picture is already at database!");
            }
        }

        public async void RemoveAsync(Picture entity)
        {
            await FindByIdAsync(entity.Id);
            tac.Pictures.Remove(entity);
            await tac.SaveChangesAsync();
        }

        public async void UpdateAsync(int id, Picture newEntity)
        {
            var c = await FindByIdAsync(id);
            c = newEntity;
            await tac.SaveChangesAsync();
        }
        public void AddRange(ICollection<Picture> entities)
        {
            tac.Pictures.AddRange(entities);
            tac.SaveChanges();
        }

        public void RemoveRange(ICollection<Picture> entities)
        {
            tac.Pictures.RemoveRange(entities);
            tac.SaveChanges();
        }

        public async Task<Picture> FindByNameAsync(string name)
        {
            return await tac.Pictures.FirstOrDefaultAsync(x => x.Picture1.ToLower().Equals(name.ToLower())) ?? throw new Exception("Picture was not found");
        }

        public async Task<Picture> FindByIdAsync(int id)
        {
            return await tac.Pictures.FindAsync(id) ?? throw new Exception("Picture was not found");
        }

        public async Task<Picture> GetAsync(int id)
        {
            return await tac.Pictures.FirstOrDefaultAsync(x => x.Id.Equals(id)) ?? throw new Exception("No picture to show");
        }

        public async Task<ICollection<Picture>> GetEntitiesAsync()
        {
            var pictures = await tac.Pictures.ToListAsync();
            return pictures.Count > 0 ? pictures : throw new Exception("No pictures to show");
        }
        public async Task<Picture> GetByReferenceAsync(string reference)
        {
            return await tac.Pictures.FirstOrDefaultAsync(x => x.Picture1.ToLower().Equals(reference.ToLower())) ?? throw new Exception("Picture was not found");
        }
    }
}
