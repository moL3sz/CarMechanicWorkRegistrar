using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using WorkRegistrarAPI.Data;
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
        public string ClientLastName { get; set; }

        [Required(ErrorMessage = "Az autó típus kötelező!")]
        public string CarType { get; set; }

        [Required(ErrorMessage = "A rendszám kötelező!")]
        [RegularExpression(pattern: "^[A-Z]{3}[- ]?[0-9]{3}", ErrorMessage = "A rendszám rossz formátumban van megadva! Példa: ABC-123")]
        public string LicencePlateNumber { get; set; }

        [Required(ErrorMessage = "A gyártási év kötelező")]
        public int ManufactureYear { get; set; }

        [Required(ErrorMessage = "A munka típsua kötelező!")]
        [EnumDataType(typeof(WorkCatagory), ErrorMessage = "Rossz munkakört adott meg!")]
        public WorkCatagory WorkCatagory { get; set; }

        [DefaultValue(WorkStatus.ACCEPTED)]
        [EnumDataType(typeof(WorkStatus), ErrorMessage = "Rossz munka státuszt adott meg!")]
        public WorkStatus WorkStatus { get; set; }

        [Required(ErrorMessage = "A leírás kötelező")]
        public string Description { get; set; }

        [Required]
        [Range(0, 10)]
        public short IssueSeriousness { get; set; }

        public bool Active { get; set; }

        public DateTime CreatedDate { get; set; }


        #region -------- Calcualted values ----------
        [NotMapped]
        public int CarAge => DateTime.Now.Year - this.ManufactureYear;

        [NotMapped]
        public double WorktimeEstimination
        {
            get
            {
                //TODO Estimation

                var CategoryHour = GlobalStaticVariables.WORKCATEGORY_HOURS.GetValueOrDefault(this.WorkCatagory, 0);
                var ManufactureRate = GlobalStaticVariables.MANUFACTURE_YEAR_RATE
                    .FirstOrDefault(x => this.CarAge >= x.Key.Item1 && this.CarAge <= x.Key.Item2).Value;
                var IssueSeriousnessRate = GlobalStaticVariables.ISSUE_SERIOUSNESS_RATE
                    .FirstOrDefault(x => this.IssueSeriousness >= x.Key.Item1 && this.IssueSeriousness <= x.Key.Item2).Value;

                Console.WriteLine(CategoryHour);
                Console.WriteLine(ManufactureRate);
                Console.WriteLine(IssueSeriousnessRate);



                return CategoryHour * ManufactureRate * IssueSeriousnessRate;
            }
        }
        #endregion -------- Calcualted values ----------
    }
}
