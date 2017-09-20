using BundesligaWeb.CustomValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BundesligaWeb.ViewModels
{
    public class MatchViewModel
    {
        public int Id { get; set; }
        public int LeagueId { get; set; } = 1;
        [Required]
        [Display(Name = "Home Team")]
        [Range(1, int.MaxValue, ErrorMessage = "Enter Home Team")]
        public int HomeTeamId { get; set; }

        public List<SelectListItem> Teams { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Enter Away Team")]
        [Display(Name = "Away Team")]
        public int AwayTeamId { get; set; }

        [Required]
        [PositiveNumber(ErrorMessage ="Score must be positive")]       
        public int HomeTeamScore { get; set; }

        
        [Required]
        [PositiveNumber]
        public int AwayTeamScore { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        public DateTime MatchDate { get; set; }
    }
}
