using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_LearningPlatform.DataAccess.Context;
using E_LearningPlatform.DataAccess.Repository.IRepository;
using E_LearningPlatform.Models;

namespace E_LearningPlatform.DataAccess.Repository
{
    public class CategoryRepository:Repository<Category>,ICategory
    {
        private AppDbContext _db;
        public CategoryRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Category category)
        {
            _db.Update(category);
        }
    }
}
