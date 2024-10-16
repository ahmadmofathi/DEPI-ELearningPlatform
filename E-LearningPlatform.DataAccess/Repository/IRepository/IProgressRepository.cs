using E_LearningPlatform.DataAccess.Repository.IRepository;
using E_LearningPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TechneStore.DataAccess.Repository.IRepository
{
    public interface IProgressRepository : IRepository<Progress>
    {
        void Update(Progress progress);
    }
}
