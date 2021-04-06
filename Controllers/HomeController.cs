using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bowling.Models;
using Microsoft.EntityFrameworkCore;
using Bowling.Models.ViewModels;

namespace Bowling.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(long? teamID,string teamName, int pageNum = 0)
        {
            //page size....number of teams per page
            int pageSize = 5;

            //displays all bowlers based on selected team
            return View(new IndexViewModel
            {
                Bowlers = (_context.Bowlers
                .Where(t => t.TeamId == teamID || teamID == null)
                .OrderBy(t => t.BowlerFirstName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList()),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,

                    //if no team has been selected then get th full count, otherwise only get the number from the team count thnat has been selected
                    TotalNumItems = (teamID == null ? _context.Bowlers.Count() :
                        _context.Bowlers.Where(x => x.TeamId == teamID).Count())

                },

                TeamName = teamName

                
            });
            
                

        
                
                
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
