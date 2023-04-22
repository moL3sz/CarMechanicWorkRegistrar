using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WorkManagerClient.Models
{
    public class WorkFlow
    {
        [DisplayName("Vezetéknév")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string FirstName { get; set; }

        [DisplayName("Keresztnév")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LastName { get; set; }

        [DisplayName("Autó típusa")]
        public string CarType { get; set; }

        [DisplayName("Rendszám")]
        public string LicensePlateNumber { get; set; }

        [DisplayName("Gyártási év")]
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int YearOfManufacture { get; set; }

        [DisplayName("Munka kategória")]
        [Required]
        public string WorkType { get; set; }

        [DisplayName("Hiba rövid leírása")]
        [Required]
        public string ProblemDescription { get; set; }

        [DisplayName("Hiba súlyossága")]
        [Required]
        [Range(1, 10)]
        public int HowBadIsIt { get; set; }
    }
}
