﻿using System.ComponentModel;

namespace WorkManagerClient.Enums
{
    public enum WorkStatus
    {

        [Description("Felvett munka")]
        ACCEPTED = 0,

        [Description("Elvégzés alatt")]
        WORKING_PROGRESS = 1,

        [Description("Befejezett")]
        DONE = 2,
    }
}
