using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_LearningPlatform.DataAccess.ViewModels
{
    public class CouresCategoriesVm
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public string Description { get; set; }

        public int NoOfVideos { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
