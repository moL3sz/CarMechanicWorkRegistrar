using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkRegistrarAPI.Enums;
using WorkRegistrarAPI.Models;

namespace WorkhourEstiminationTest
{
    public class WorkhourEstiminationTest
    {
        // the CarAge value is in relation with time ( YEAR ) so if you run the test in 2024 it might NOT WORK!
        [Fact]
        public void WorkhourEstiminationForEngineIssue()
        {
           
            Workflow workflow = new Workflow{ 
                ManuFactureYear = 1999,
                WorkCatagory = WorkRegistrarAPI.Enums.WorkCatagory.ENGINE,
                IssueSeriousness = 6 
            };

            Assert.Equal( 9.6, workflow.WorktimeEstimination, 0.000001);


        }
        [Fact]
        public void WorkhourEstiminationBrakeSystemIssue()
        {

            Workflow workflow = new Workflow
            {
                ManuFactureYear = 1999,
                WorkCatagory = WorkRegistrarAPI.Enums.WorkCatagory.BRAKE_SYSTEM,
                IssueSeriousness = 6
            };

            Assert.Equal(9.6, workflow.WorktimeEstimination, 0.000001);


        }
        [Fact]
        public void WorkhourEstiminationForBodyWorkIssue()
        {

            Workflow workflow = new Workflow
            {
                ManuFactureYear = 1999,
                WorkCatagory = WorkRegistrarAPI.Enums.WorkCatagory.BODYWORK,
                IssueSeriousness = 6
            };

            Assert.Equal(9.6, workflow.WorktimeEstimination, 0.000001);


        }
        [Fact]
        public void WorkhourEstiminationForLandingGearIssue()
        {

            Workflow workflow = new Workflow
            {
                ManuFactureYear = 1999,
                WorkCatagory = WorkRegistrarAPI.Enums.WorkCatagory.ENGINE,
                IssueSeriousness = 6
            };

            Assert.Equal(9.6, workflow.WorktimeEstimination, 0.000001);


        }
    }
}
