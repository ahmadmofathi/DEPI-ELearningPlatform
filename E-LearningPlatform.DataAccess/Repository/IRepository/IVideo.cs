using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_LearningPlatform.Models;

namespace E_LearningPlatform.DataAccess.Repository.IRepository
{
    public interface IVideo:IRepository<Video>
    {
        void Update(Video video);

    }
}
