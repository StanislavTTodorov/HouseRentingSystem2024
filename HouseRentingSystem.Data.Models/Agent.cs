﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HouseRentingSystem.Common.EntityValidationConstants.Agent;

namespace HouseRentingSystem.Data.Models
{
    public class Agent
    {
        public Agent()
        {
            this.Id = Guid.NewGuid();
            this.OwnedHouses = new HashSet<House>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public virtual ICollection<House> OwnedHouses { get; set; }
    }
}