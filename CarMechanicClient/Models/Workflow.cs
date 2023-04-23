using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using CarMechanicClient.Enums;

namespace CarMechanicClient.Models
{
    public class Workflow
    {

        public int WorkflowId { get; set; }

        public string ClientFirstName { get; set; }

        public string ClientLastName { get; set; }

        public string CarType { get; set; }

        public string LicencePlateNumber { get; set; }

        public int ManuFactureYear { get; set; }

        public WorkCatagory WorkCatagory;

        public WorkStatus WorkStatus { get; set; }

        public string Description { get; set; }

        public short IssueSeriousness { get; set; }

        public bool Active { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CarAge { get; set; }

        public double WorktimeEstimination { get; set; }
    }
}
