using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BundesligaDomain;
using BundesligaEF;
using BundesligaWeb.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using BundesligaServices.Interfaces;
using AutoMapper;
using BundesligaServices.DTO;

namespace BundesligaWeb.Controllers
{
    [Route("[controller]")]
    public class MatchController : Controller
    {
        private IMatchServices _matchServices;
        

        public MatchController(IMatchServices matchServices)
        {
            _matchServices = matchServices;
           
        }
        [HttpGet("Matches")]      
        public IActionResult Index()
        {
            var matches = _matchServices.GetAllMatches();
            var vm = Mapper.Map<List<MatchesViewViewModel>>(matches);
           
            return View(vm);
        }

        [HttpPost("Matches")]
        public IActionResult Index(int week)
        {
            var weekMatches = _matchServices.GetMatchesByWeek(week);
            var vm = Mapper.Map<List<MatchesViewViewModel>>(weekMatches);

            return View(vm);
        }


        [HttpGet("AddMatch")]      
        [Authorize]
        public IActionResult AddMatch()
        {
            var match = _matchServices.GetDataForMatch();
            var vm = Mapper.Map<MatchViewModel>(match);

            return View(vm);
        }


        [HttpPost("AddMatch")]
        public IActionResult AddMatch(MatchViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var matchDTO = Mapper.Map<MatchDTO>(vm);              
                var id=_matchServices.SaveMatch(matchDTO);             

                return RedirectToAction("AddStatistic", new { id =id });
            }
            return View(vm);
           
        }


        [HttpGet("{id}/statistics")]    
        [Authorize]
        public IActionResult AddStatistic(int id)
        {
            var statistics = _matchServices.GetDataForStatistics(id);
            var vm = Mapper.Map<MatchStatisticsViewModel>(statistics);
            return View(Enumerable.Repeat(vm, 28).ToList());
        }
        [HttpPost("{id}/statistics")]
       public IActionResult AddStatistic(IList<MatchStatisticsViewModel> vm)
        {
            var statistics = Mapper.Map<IList<MatchStatisticsDTO>>(vm);
            _matchServices.SaveStatistics(statistics);           
            
            return RedirectToAction("AddMatch");
        }


        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var matchForEdit = _matchServices.GetDataForEdit(id);
            var vm = Mapper.Map<MatchViewModel>(matchForEdit);


            return View(vm);

        }

        [HttpPost("edit/{id}")]
        public IActionResult Edit(MatchViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var matchDTO = Mapper.Map<MatchDTO>(vm);
                _matchServices.EditMatch(matchDTO);

                return RedirectToAction("Index");
            }

            return View(vm);

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _matchServices.DeleteMatch(id);
            return RedirectToAction("Index");
        }
    }
}