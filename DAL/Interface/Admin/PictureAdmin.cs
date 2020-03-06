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

        public Picture Find(string name)
        {
            return tac.Pictures.FirstOrDefault(x => x.Picture1.ToLower().Equals(name.ToLower())) ?? throw new Exception("Picture was not found");
        }
        public Picture FindById(int id)
        {
            return tac.Pictures.FirstOrDefault(x=>x.Id.Equals(id)) ?? throw new Exception("Picture was not found");
        }

        public Picture Get(int id)
        {
            return tac.Pictures.FirstOrDefault(x => x.Id.Equals(id)) ?? throw new Exception("No picture to show");
        }

        public ICollection<Picture> GetEntities()
        {
            return tac.Pictures.ToList() ?? throw new Exception("No pictures to show");
        }

        public void Remove(Picture entity)
        {
            FindById(entity.Id);
            tac.Pictures.Remove(entity);
            tac.SaveChanges();
        }

        public void Update(int id, Picture newEntity)
        {
            var c = FindById(id);
            if (c != null)
            {
                c = newEntity;
                tac.SaveChanges();
            }
            else
            {
                throw new Exception("Picture does not exist in database!");
            }
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
    }
}
