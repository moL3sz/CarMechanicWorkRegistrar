using System.ComponentModel.DataAnnotations;
using WorkRegistrarAPI.Enums;

namespace WorkRegistrarAPI.Models
{
    public class Workflow
    {
        [Key]
        public int WorkflowId { get; set; }

        [Required(ErrorMessage = "A vezetéknév kötelező!")]

        public string ClientFirstName { get; set; }

        [Required(ErrorMessage = "A keresztnév kötelező!")]
        public string ClientLastName { get;set; }

        [Required(ErrorMessage = "Az autó típus kötelező!")]

        public string CarType { get; set; }

        [Required(ErrorMessage = "A rendszám kötelező!")]
        [RegularExpression(pattern: "^[A-Z]{3}[- ]?[0-9]{3}")]
        public string LicencePlateNumber { get; set; }

        [Required(ErrorMessage ="A gyártási év kötelező")]
        public int ManuFactureYear { get; set; }

        [Required(ErrorMessage = "A munka típsua kötelező!")]
        public WorkCatagory WorkCatagory;

        [Required(ErrorMessage = "A leírás kötelező")]
        public string Description { get; set; }

        [Required]
        [Range(0, 10)]
        public short IssueSeriousness { get; set; }

        public bool Active { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
