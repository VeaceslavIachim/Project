using BundesligaDomain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BundesligaWeb.ViewModels
{
    public class TeamViewModel
    {
        //public TeamViewModel()
        //{
        //    Players = new List<PlayerViewModel>();
        //}
        public string Name { get; set; }
        public string Photo { get; set; }
     
        public IEnumerable<PlayerViewModel> Players { get; set; }

       
    }
}
