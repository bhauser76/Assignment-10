using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//model view for the paging info that is passed into the controller
namespace Bowling.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Bowlers> Bowlers { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }

        public string TeamName { get; set; }
    }
}
