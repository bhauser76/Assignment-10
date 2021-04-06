using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//page info class to help with pagination calculations
namespace Bowling.Models.ViewModels
{
    public class PageNumberingInfo
    {
        public int NumItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNumItems { get; set; }
        public int NumPages => (int) (Math.Ceiling((decimal) TotalNumItems / NumItemsPerPage));


    }
}
