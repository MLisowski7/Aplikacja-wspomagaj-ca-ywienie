﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietApp.Models
{
    public class RecipeIngredient
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipeIngredientId { get; set; }

        public int ProductId { get; set; }
        public int RecipeId { get; set; }
        public int Weight { get; set; }

        public virtual Product Product { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
