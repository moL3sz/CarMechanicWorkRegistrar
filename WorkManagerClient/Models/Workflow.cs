using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using WorkManagerClient.Enums;

namespace WorkManagerClient.Models
{
    public class Workflow
    {
        [Key]
        public int WorkflowId { get; set; }

        [Required(ErrorMessage = "A vezetéknév kötelező!")]
        
        public string ClientFirstName { get; set; }

        [Required(ErrorMessage = "A keresztnév kötelező!")]
        public string ClientLastName { get; set; }

        [Required(ErrorMessage = "Az autó típus kötelező!")]
        public string CarType { get; set; }

        [Required(ErrorMessage = "A rendszám kötelező!")]
        [RegularExpression(pattern: @"^[A-Z]{3}[- ]?[0-9]{3}", ErrorMessage = "A rendszám rossz formátumban van megadva! Példa: ABC-123")]
        public string LicencePlateNumber { get; set; }



        //TODO
        /*[Range(typeof(DateTime), DateTime.MinValue.ToString(), DateTime.Now.ToString(),
        ErrorMessage = "Value for {0} must be between {1} and {2}")]*/

        [Required(ErrorMessage = "A gyártási év kötelező")]
        public int ManufactureYear { get; set; }

        [Required(ErrorMessage = "A munka típsua kötelező!")]
        [EnumDataType(typeof(WorkCatagory), ErrorMessage = "Rossz munkakört adott meg!")]
        public WorkCatagory WorkCatagory { get; set; }

        [Required(ErrorMessage = "A leírás kötelező")]
        public string Description { get; set; }

        [Required]
        [Range(0, 10)]
        public short IssueSeriousness { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool Active { get; set; }

        [DefaultValue(WorkStatus.ACCEPTED)]
        [EnumDataType(typeof(WorkStatus), ErrorMessage = "Rossz munka státuszt adott meg!")]
        public WorkStatus WorkStatus { get; set; }
    }
}
