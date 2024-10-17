using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_LearningPlatform.DataAccess.Repository.IRepository;

namespace TechneStore.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IEnrollmentRepository  Enrollment{ get; }
        IRequestRepository Request{ get; }
        IProgressRepository Progress{ get; }
        ICourse Course { get; }
        ICategory Category { get; }
        IVideo Video { get; }
        void Save();
    }
}
