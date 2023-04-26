namespace CarMechanicClient.Managers
{
    public class AttributeManager
    {
        public class Attribute
        {
            private string fieldName;
            private string variableName;
            private int sortIndicator = 0; // 0-NoSort 1-Decrease 2-Increase
            private string searchbarText = "";

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
            public string getSearchbarText() { return searchbarText; }
            public void setSearchbarText(string value) { searchbarText = value; }

            public string getSimbol()
            {
                if (sortIndicator == 0) return "-";
                else if (sortIndicator == 1) return "ˇ";
                else return "^";
            }

            public string show()
            {
                return getFieldName() + getSimbol();
            }
        }

        public Attribute[] attribute = new Attribute[11];

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
            attribute[8] = new Attribute("Created Date", "CreatedDate");
            attribute[9] = new Attribute("Worktime Estimination", "WorktimeEstimination");
            attribute[10] = new Attribute("Work Status", "WorkStatus");

            attribute[0].setSortIndicator(1);
        }

        public int activeAttributeId = 0;
        private string searchPrompt = "";

        public string getActiveVariableName()
        {
            return attribute[activeAttributeId].getVariableName();
        }
        public bool getActiveDescending()
        {
            if (attribute[activeAttributeId].getSortIndicator() == 1) return false;
            else return true;
        }

        public string getSearchPrompt(){ return searchPrompt; }

        public void generateSearchPrompt()
        {
            // [{ "Workstatus":"DONE"},{ "CarType": "Merci"}]
            string text = "[";
            foreach (Attribute att in attribute)
            {
                if(att.getSearchbarText() != "")
                {
                    text = text + "{ \"" + att.getVariableName() + "\":\"" + att.getSearchbarText() + "\"},";
                }
            }
            text = text.Substring(0, text.Length - 1);

            searchPrompt = text + "]";
            if (searchPrompt == "]") searchPrompt = null;
        }
    }
}
