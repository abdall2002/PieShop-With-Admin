﻿using System.ComponentModel.DataAnnotations;

namespace BethenyPieShopAdmin.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }

        [StringLength(50, ErrorMessage = "The name should be no longer than 50 characters.")]
        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "The amount should be no longer than 100 characters.")]
        [Display(Name = "Amount")]
        public string Amount { get; set; } = string.Empty;

    }
}