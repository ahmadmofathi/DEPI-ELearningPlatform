using E_LearningPlatform.Models;
using System.Web.Mvc;

namespace E_LearningPlatform.DataAccess.ViewModels
{
    public class RequestVM
    {
        public Request Request { get; set; }
        public IEnumerable<SelectListItem> CourseList { get; set; }


    }    
}




