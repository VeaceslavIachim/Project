using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BundesligaWeb.ViewModels
{
    public class MatchesViewViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Home Team")]
        public string HomeTeam { get; set; }
        [Display(Name ="      ")]
        public string HomeTeamPhoto { get; set; }
        [Display(Name ="Away Team")]
        public string AwayTeam { get; set; }
        [Display(Name ="      ")]
        public string AwayTeamPhoto { get; set; }
        [Display (Name ="Score")]
        public int HomeTeamScore { get; set; }
        [Display(Name = "Score")]
        public int AwayTeamScore { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}
