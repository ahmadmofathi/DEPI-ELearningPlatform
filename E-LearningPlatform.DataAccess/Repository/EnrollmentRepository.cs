using E_LearningPlatform.DataAccess.Context;
using E_LearningPlatform.DataAccess.Repository;
using E_LearningPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using E_LearningPlatform.DataAccess.Repository.IRepository;

namespace E_LearningPlatform.DataAccess.Repository
{
    public class EnrollmentRepository : Repository<Enrollment>, IEnrollmentRepository
    {
        private AppDbContext _db;
        public EnrollmentRepository(AppDbContext db) : base(db) {
            _db = db;
        }

      
        public void Update(Enrollment enrollment)
        {
            _db.Update(enrollment);
        }
    }
}
