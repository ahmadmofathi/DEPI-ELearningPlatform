using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_LearningPlatform.DataAccess.Context;
using E_LearningPlatform.DataAccess.Repository.IRepository;
using E_LearningPlatform.Models;
<<<<<<< HEAD
using E_LearningPlatform.DataAccess.Repository.IRepository;
=======
>>>>>>> fde47c85bdd86ad23fbfbe25812cdddda84131dc

namespace E_LearningPlatform.DataAccess.Repository
{
    public class VideoRepository : Repository<Video>, IVideo
    {
        private AppDbContext _db;
        public VideoRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Video video)
        {
            _db.Update(video);
        }
    }
}
