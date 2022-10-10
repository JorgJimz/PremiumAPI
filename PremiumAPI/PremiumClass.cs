namespace PremiumAPI
{

    public class PremiumParam
    {
        public DateTime? DateOfBirth { get; set; }
        public string? State { get; set; }
        public int Age { get; set; }
        public string? Plan { get; set; }
    }


    public class PremiumClass
    {
        public string Carrier { get; set; }
        public decimal Premium { get; set; }
    }

    public class PremiumModel
    {
        public string Carrier { get; set; }
        public string Plan { get; set; }
        public string State { get; set; }
        public string MonthOfBirth { get; set; }
        public int AgeStart { get; set; }
        public int AgeEnd { get; set; }
        public decimal Premium { get; set; }
    }
}
