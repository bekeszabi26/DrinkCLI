namespace drink
{
    internal class Citizen
    {
        
        public int Age { get; set; }
        public int CitizenId { get; set; }
        public bool Drinking { get; set; }
        public int DrinkingWeekdays { get; set; }
        public int DrinkingWeekends { get; set; }
        public bool Gender { get; set; }
        public int NationalityId { get; set; }
        public string NationalityName { get; set; }
        public string NetIncome { get; set; }
        public int PopulationGroupID { get; set; }
        public string PopulationGroupName { get; set; }
        public string SchoolDropout { get; set; }
        public string State { get; set; }
        public bool Treatment { get; set; }

        public Citizen(string row, int id)
        {
            string[] t = row.Split(';');
            Age = int.Parse(t[0]);
            CitizenId = id;
            Drinking = t[1] == "Yes" ? true : false;
            DrinkingWeekdays = t[2] == "NO" ? -1 : int.Parse(t[2]);
            DrinkingWeekends = t[3] == "NO" ? -1 : int.Parse(t[3]);
            Gender = t[4] == "Male" ? true : false;
            NationalityId = int.Parse(t[5]);
            NationalityName = t[6];
            NetIncome = t[7];
            PopulationGroupID = int.Parse(t[8]);
            PopulationGroupName = t[9];
            SchoolDropout = t[10];
            State = t[11];
            Treatment = t[12] == "1" ? true : false;
        }

        public override string ToString()
        {
            return $"\tCitizen Id: {CitizenId}\n" +
                $"\tAge: {Age}\n" +
                $"\tDrinking: {(Drinking? "Yes" : "No")}\n" +
                $"\tDrinking on weekdays: {(DrinkingWeekdays ==  -1 ? "NO" : DrinkingWeekdays)}\n" +
                $"\tDrinking on weekends: {(DrinkingWeekends == -1 ? "NO" : DrinkingWeekends)}\n" +
                $"\tGender: {(Gender? "Male" : "Female")}\n" +
                $"\tNationality: {NationalityName}\n" +
                $"\tNetIncome: {NetIncome}\n" +
                $"\tPopulation Group: {PopulationGroupName}\n" +
                $"\tDrop out from school: {SchoolDropout}\n" +
                $"\tState: {State}\n" +
                $"\tTreatment: {Treatment}\n" +
                $"\tAverage Drinking: {AverageDrinking()}\n";
        }

        private string AverageDrinking()
        {
            if (DrinkingWeekdays == -1 || DrinkingWeekends == -1)
            {
                return "NaN";
            }
            else
            {
                return $"{((double)DrinkingWeekdays + DrinkingWeekends) / 7:0.00}";
            }
        }

    }
}