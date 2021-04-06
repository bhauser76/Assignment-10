using Bowling.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//Class for the team view
namespace Bowling.Components
{
    public class TeamViewComponent : ViewComponent
    {
        private BowlingLeagueContext _context;
        public TeamViewComponent (BowlingLeagueContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {

            ViewBag.SelectedTeam = RouteData?.Values["Team"];

            //ordered by each team. Unique teams only
            return View(_context.Teams
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
