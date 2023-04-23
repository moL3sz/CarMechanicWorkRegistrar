using System.ComponentModel;

namespace CarMechanicClient.Enums
{
    public enum WorkCatagory
    {
        [Description("Karosszéria")]
        BODYWORK = 0,

        [Description("Motor")]
        ENGINE = 1,

        [Description("Futómű")]
        LANDING_GEAR = 2,

        [Description("Fékberendezés")]
        BRAKE_SYSTEM = 3,
    }
}
