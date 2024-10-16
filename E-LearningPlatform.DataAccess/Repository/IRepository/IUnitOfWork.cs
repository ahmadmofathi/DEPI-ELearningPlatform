using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechneStore.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IEnrollmentRepository  Enrollment{ get; }
        IRequestRepository Request{ get; }
        IProgressRepository Progress{ get; }
        void Save();
    }
}
