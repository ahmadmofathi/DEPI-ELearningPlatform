using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechneStore.DataAccess.Repository.IRepository;
using E_LearningPlatform.DataAccess.Context;

namespace TechneStore.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;
        public IEnrollmentRepository Enrollment { get; private set; }
        public IProgressRepository Progress { get; private set; }
        public IRequestRepository Request { get; private set; }

        public UnitOfWork(AppDbContext context) 
        {
            _db = context;
            Enrollment = new EnrollmentRepository(_db);
            Progress = new ProgressRepository(_db);
            Request = new RequestRepository(_db);


        }


        public void Save()
        {
            _db.SaveChanges();

        }


    }
}

