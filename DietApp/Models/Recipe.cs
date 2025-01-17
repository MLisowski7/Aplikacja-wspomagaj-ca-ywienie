﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietApp.Models
{
    public class Recipe
    {
        [HiddenInput(DisplayValue = false)]
        public int RecipeId { get; set; }
        [Display(Name = "Użytkownik")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Nazwa przepisu jest wymagana!")]
        [MaxLength(50, ErrorMessage = "Nazwa może mieć maksymalnie 50 znaków")]
        [Display(Name = "Nazwa przepisu")]
        public string Title { get; set; }
        public string ImageName { get; set; }
        [NotMapped]
        [Display(Name = "Zdjęcie przepisu")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Opis przepisu jest wymagany!")]
        [MaxLength(5000, ErrorMessage = "Opis może mieć maksymalnie 5000 znaków")]
        [Display(Name = "Opis przepisu")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Wybierz poziom trudności!")]
        [Display(Name = "Poziom trudności")]
        [EnumDataType(typeof(Difficulty))]
        public Difficulty DifficultyLevel { get; set; }

        [Required(ErrorMessage = "Czas przygotowania jest wymagany!")]
        [Display(Name = "Czas przygotowania")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} musi być większy niż 0.")]
        public int PreparationTime { get; set; }

        [Required(ErrorMessage = "Liczba porcji jest wymagany!")]
        [Display(Name = "Liczba porcji")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} musi być większa niż 0.")]
        public int Portions { get; set; }
        public decimal TotalKcal { get; set; }
        public decimal TotalFat { get; set; }
        public decimal TotalCarbo { get; set; }
        public decimal TotalProtein { get; set; }
        public int TotalWeight { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        [Display(Name = "Kategorie")]
        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<RecipeIngredient> Ingredients { get; set; }

        public enum Difficulty
        {
            [Display(Name = "Bardzo łatwy")]
            VeryEasy =1,
            [Display(Name = "łatwy")]
            Easy =2,
            [Display(Name = "Średni")]
            Medium =3,
            [Display(Name = "Trudny")]
            Hard =4,
            [Display(Name = "Bardzo trudny")]
            VeryHard =5
        }
    }
}
