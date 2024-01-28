//https://learn.microsoft.com/pt-br/dotnet/api/system.componentmodel.dataannotations?view=net-8.0
using CSharpRestfulAPI.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace CSharpRestfulAPI.Models
{
    public class Shirt
    {
        public int ShirtId { get; set; }

        [Required]
        public string? Brand { get; set; }

        [Required]
        public string? Color { get; set; }

        [Shirt_EnsureCorrectSizingAttibute]
        public int? Size { get; set; }

        [Required]
        public string? Gender { get; set; }

        public double? Price { get; set; }

    }
}
