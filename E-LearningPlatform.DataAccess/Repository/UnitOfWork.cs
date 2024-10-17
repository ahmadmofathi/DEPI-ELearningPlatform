using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechneStore.DataAccess.Repository.IRepository;
using E_LearningPlatform.DataAccess.Context;
using E_LearningPlatform.DataAccess.Repository.IRepository;
using E_LearningPlatform.DataAccess.Repository;

namespace TechneStore.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;
        public IEnrollmentRepository Enrollment { get; private set; }
        public IProgressRepository Progress { get; private set; }
        public IRequestRepository Request { get; private set; }
        public ICategory Category { get; private set; }

        public ICourse Course { get; private set; }

        public IVideo Video { get; private set; }


        public UnitOfWork(AppDbContext context) 
        {
            _db = context;
            Enrollment = new EnrollmentRepository(_db);
            Progress = new ProgressRepository(_db);
            Request = new RequestRepository(_db);
            Category = new CategoryRepository(_db);
            Course = new CourseRepository(_db);
            Video = new VideoRepository(_db);


        }


        public void Save()
        {
            _db.SaveChanges();

        }


    }
}

