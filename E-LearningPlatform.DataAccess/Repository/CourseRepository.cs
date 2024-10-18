using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_LearningPlatform.DataAccess.Context;
using E_LearningPlatform.DataAccess.Repository.IRepository;
using E_LearningPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace E_LearningPlatform.DataAccess.Repository
{
    public class CourseRepository : Repository<Course>, ICourse
    {
        private AppDbContext _db;
        public CourseRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Course course)
        {
            _db.Update(course);
        }

    }
}
