namespace HelloAutomationKit.Models
{
  
        public class MesData
        {
            public TraceabilityData Inputs { get; set; }
            public int ExecutionMode { get; set; }
            public string JobPool { get; set; }
            public int Retries { get; set; }
            public int SleepTime { get; set; }
            public string SynchronuousQueue { get; set; }
            public int Timeout { get; set; }
        }

}
