using MessagePack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace DietApp.Models
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Nazwa produktu jest wymagana!")]
        [MaxLength(50, ErrorMessage = "Nazwa może mieć maksymalnie 50 znaków")]
        [Display(Name = "Nazwa produktu")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Wartość energetyczna w 100g produktu jest wymagana!")]
        [Range(0, 900, ErrorMessage = "Nieprawidłowa liczba!")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Wpisana wartość musi być liczbą")]
        [Display(Name = "kcal w 100g produktu")]
        public decimal KcalPer100 { get; set; }
        
        [Required(ErrorMessage = "Tłuszcz w 100g produktu jest wymagany!")]
        [Range(0, 100, ErrorMessage = "Nieprawidłowa liczba!")]
        [Column(TypeName = "decimal(3,2)")]
        [Display(Name = "Tłuszcz w 100g produktu")]
        public decimal FatPer100 { get; set; }
       
        [Required(ErrorMessage = "Węglowodany w 100g produktu są wymagane!")]
        [Range(0, 100, ErrorMessage = "Nieprawidłowa liczba!")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Wpisana wartość musi być liczbą")]
        [Display(Name = "Węglowodany w 100g produktu")]
        public decimal CarboPer100 { get; set; }

        [Required(ErrorMessage = "Białko w 100g produktu jest wymagane!")]
        [Range(0, 100, ErrorMessage = "Nieprawidłowa liczba!")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Wpisana wartość musi być liczbą")]
        [Display(Name = "Białko w 100g produktu")]
        public decimal ProteinPer100 { get; set; }
        public int RecipeId { get; set; }
        public string ImageName { get; set; }

        [NotMapped]
        [Display(Name = "Zdjęcie produktu")]
        public IFormFile Image { get; set; }

        public virtual ICollection<ApplicationUser> UsersFavorite { get; set; }
    }
}
