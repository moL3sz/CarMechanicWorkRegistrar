namespace WorkManagerClient.Managers
{
    public class AttributeManager
    {
        public class Attribute
        {
            private string fieldName;
            private string variableName;
            private int sortIndicator = 0; // 0-NoSort 1-Decrease 2-Increase

            public Attribute(string fieldName_, string variableName_)
            {
                fieldName = fieldName_;
                variableName = variableName_;
            }

            // Van jobb mód a getterek és setterekre?
            public string getFieldName() { return fieldName; }
            public void setFieldName(string value) { fieldName = value; }
            public string getVariableName() { return variableName; }
            public void setVariableName(string value) { variableName = value; }
            public int getSortIndicator() { return sortIndicator; }
            public void setSortIndicator(int value) { sortIndicator = value; }

            public string getSimbol()
            {
                if (sortIndicator == 0) return "";
                else if (sortIndicator == 1) return "+";
                else return "-";
            }

            public string show()
            {
                return getFieldName() + getSimbol();
            }
        }

        public Attribute[] attribute = new Attribute[8];

        public AttributeManager()
        {
            attribute[0] = new Attribute("Client First Name", "ClientFirstName");
            attribute[1] = new Attribute("Client Last Name", "ClientLastName");
            attribute[2] = new Attribute("Car Type", "CarType");
            attribute[3] = new Attribute("Licence Plate Number", "LicencePlateNumber");
            attribute[4] = new Attribute("Manufacture Year", "ManufactureYear");
            attribute[5] = new Attribute("Work Catagory", "WorkCatagory");
            attribute[6] = new Attribute("Description", "Description");
            attribute[7] = new Attribute("Issue Seriousness", "IssueSeriousness");

            attribute[0].setSortIndicator(1);
        }

        public int activeAttributeId = 0;

        public string getActiveVariableName()
        {
            return attribute[activeAttributeId].getVariableName();
        }
        public bool getActiveDescending()
        {
            if (attribute[activeAttributeId].getSortIndicator() == 1) return false;
            else return true;
        }
    }
}
