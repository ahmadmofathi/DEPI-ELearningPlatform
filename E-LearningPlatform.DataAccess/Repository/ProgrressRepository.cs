using E_LearningPlatform.DataAccess.Context;
using E_LearningPlatform.DataAccess.Repository;
using E_LearningPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechneStore.DataAccess.Repository.IRepository;

namespace TechneStore.DataAccess.Repository
{
    public class ProgressRepository : Repository<Progress>, IProgressRepository
    {
        private AppDbContext _db;
        public ProgressRepository(AppDbContext db) : base(db) {
            _db = db;
        }

      
        public void Update(Progress progress)
        {
            _db.Update(progress);
        }


    }
}
