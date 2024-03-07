﻿

using HouseRentingSystem.Web.ViewModels.House.Enums;
using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Common.GeneralApplicationConstants;

namespace HouseRentingSystem.Web.ViewModels.House
{
    public class AllHousesQueryModel
    {
        public AllHousesQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.HousesPerPage = DefaultEntitiesPerPage;

            this.Categories = new HashSet<string>();
            this.Houses = new HashSet<HouseAllViewModel>();
        }

        public string? Category { get; set; }

        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort House by")]

        public HouseSorting HouseSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name ="Show Houses On Page")]
        public int HousesPerPage { get; set; }

        public int TotalHouses { get; set; }

        public IEnumerable<string> Categories { get; set; } 

        public IEnumerable<HouseAllViewModel> Houses { get; set; }
    }
}
