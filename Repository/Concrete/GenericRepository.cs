using HamburgerMenuProject.Context;
using HamburgerMenuProject.Models.BaseEntities;
using HamburgerMenuProject.Repository.Abstract;
using System.Linq.Expressions;

namespace HamburgerMenuProject.Repository.Concrete
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext db; // DEpendency Injeciton Syntax for constructor
        public GenericRepository(ApplicationDbContext applicationDb)
        {
            db = applicationDb;
        }
        public bool Add(T entity)
        {
            db.Set<T>().Add(entity);
            return db.SaveChanges() > 0;
        }

        public void AddPhoto(BaseEntity baseEntity, IFormFile formFile)
        {
            if (formFile != null)
            {
                string imageName = formFile.FileName;
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imageName}");
                var stream = new FileStream(path, FileMode.Create);
                baseEntity.Photo = imageName;
                formFile.CopyTo(stream);
            }
        }

        public bool Delete(T entity)
        {
            var delete = GetById(entity.ID);
            delete.IsActive = false; 
            return db.SaveChanges() > 0;
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>();
        }

        public T GetById(int id)
        {
            return db.Set<T>().FirstOrDefault(a => a.ID == id);
        }

        public IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Where(predicate);
        }

        public bool Update(T entity)
        {
            db.Set<T>().Update(entity);
            return db.SaveChanges() > 0;
        }
    }
}
