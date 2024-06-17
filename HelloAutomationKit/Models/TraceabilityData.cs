namespace HelloAutomationKit.Models
{

    public class TraceabilityData
    {
        public string serialNumber { get; set; }
        public string moNumber { get; set; }
        public string op { get; set; }
        public string moItemNumber { get; set; }
        public bool passFailFlag { get; set; }
        public DateTime timeStamp { get; set; }
        public string machineID { get; set; }
    }

}
