using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using WorkManagerClient.Enums;
using WorkManagerClient.Models;
using Xunit.Abstractions;

namespace WorkManagerClientUnitTests
{
    public class FormValidationTests
    {

        private readonly ITestOutputHelper output;

        public FormValidationTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void FirstNameCheck()
        {
            Workflow workflow = new Workflow();
            workflow.ClientFirstName = "Példa";

            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(workflow, new ValidationContext(workflow), validationResultList, true);
            validationResultList.ForEach(o => { output.WriteLine(o.ToString()); });
            var message = validationResultList[0].ErrorMessage;
            Assert.NotEqual("A vezetéknév kötelezõ!", message);
        }

        [Fact]
        public void FirstNameCheckNull()
        {
            Workflow workflow = new Workflow();
            workflow.ClientFirstName = null;

            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(workflow, new ValidationContext(workflow), validationResultList, true);
            validationResultList.ForEach(o => { output.WriteLine(o.ToString()); });
            var message = validationResultList[0].ErrorMessage;
            Assert.Equal("A vezetéknév kötelezõ!", message);
        }

        [Fact]
        public void LastNameCheck()
        {
            Workflow workflow = new Workflow();
            workflow.ClientLastName = "Példa";

            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(workflow, new ValidationContext(workflow), validationResultList, true);
            validationResultList.ForEach(o => { output.WriteLine(o.ToString()); });
            var message = validationResultList[1].ErrorMessage;
            Assert.NotEqual("A keresztnév kötelezõ!", message);
        }

        [Fact]
        public void LastNameCheckNull()
        {
            Workflow workflow = new Workflow();
            workflow.ClientLastName = null;

            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(workflow, new ValidationContext(workflow), validationResultList, true);
            validationResultList.ForEach(o => { output.WriteLine(o.ToString()); });
            var message = validationResultList[1].ErrorMessage;
            Assert.Equal("A keresztnév kötelezõ!", message);
        }

        [Fact]
        public void CarTypeCheck()
        {
            Workflow workflow = new Workflow();
            workflow.CarType = "Példa";

            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(workflow, new ValidationContext(workflow), validationResultList, true);
            validationResultList.ForEach(o => { output.WriteLine(o.ToString()); });
            var message = validationResultList[2].ErrorMessage;
            Assert.NotEqual("Az autó típus kötelezõ!", message);
        }

        [Fact]
        public void CarTypeCheckNull()
        {
            Workflow workflow = new Workflow();
            workflow.CarType = null;

            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(workflow, new ValidationContext(workflow), validationResultList, true);
            validationResultList.ForEach(o => { output.WriteLine(o.ToString()); });
            var message = validationResultList[2].ErrorMessage;
            Assert.Equal("Az autó típus kötelezõ!", message);
        }

        [Fact]
        public void LicencePlateNumberCheck()
        {
            Workflow workflow = new Workflow();
            workflow.LicencePlateNumber = "ASD-123";

            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(workflow, new ValidationContext(workflow), validationResultList, true);
            validationResultList.ForEach(o => { output.WriteLine(o.ToString()); });
            var message = validationResultList[3].ErrorMessage;
            Assert.NotEqual("A rendszám rossz formátumban van megadva! Példa: ABC-123", message);
        }

        [Fact]
        public void LicencePlateNumberCheckNull()
        {
            Workflow workflow = new Workflow();
            workflow.LicencePlateNumber = null;

            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(workflow, new ValidationContext(workflow), validationResultList, true);
            validationResultList.ForEach(o => { output.WriteLine(o.ToString()); });
            var message = validationResultList[3].ErrorMessage;
            Assert.Equal("A rendszám kötelezõ!", message);
        }

        [Fact]
        public void ManufactureYear()
        {
            Workflow workflow = new Workflow();
            workflow.ManufactureYear = 2022;

            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(workflow, new ValidationContext(workflow), validationResultList, true);
            validationResultList.ForEach(o => { output.WriteLine(o.ToString()); });
            var message = validationResultList[4].ErrorMessage;
            Assert.NotEqual("A gyártási év kötelezõ", message);
        }

        //TODO lecsekkolni, hogyan kell intre null testet írni
        /*
        [Fact]
        public void ManufactureYearNull()
        {
            Workflow workflow = new Workflow();
            workflow.ManufactureYear = -1;

            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(workflow, new ValidationContext(workflow), validationResultList, true);
            validationResultList.ForEach(o => { output.WriteLine(o.ToString()); });
            var message = validationResultList[4].ErrorMessage;
            Assert.Equal("A gyártási év kötelezõ", message);
        }
        
        //TODO megmókolni, mert ez egy agyhalott indexelés téren 
        
        [Fact]
        public void WorkCatagoryCheck()
        {
            Workflow workflow = new Workflow();
            List<WorkCatagory> categories = Enum.GetValues(typeof(WorkCatagory)).Cast<WorkCatagory>().ToList();
            categories.ForEach(c => output.WriteLine(c.ToString()));
            workflow.WorkCatagory = categories[0];

            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(workflow, new ValidationContext(workflow), validationResultList, true);
            //validationResultList.ForEach(o => { output.WriteLine(o.ToString()); });
            var message = validationResultList[5].ErrorMessage;
            Assert.NotEqual("Rossz munkakört adott meg!", message);
        }
        */
        
        [Fact]
        public void DescriptionCheck()
        {
            Workflow workflow = new Workflow();
            workflow.Description = "Példa";

            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(workflow, new ValidationContext(workflow), validationResultList, true);
            validationResultList.ForEach(o => { output.WriteLine(o.ToString()); });
            var message = validationResultList[4].ErrorMessage;
            Assert.NotEqual("A leírás kötelezõ", message);
        }
        
    }
}