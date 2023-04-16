namespace TestCreator.CypressTests
{
    public class TestResult
    {
        public int Tests { get; set; }
        public int Passes { get; set; }
        public int Failures { get; set; }
        public double PassPercent { get; set; }
        public int Duration { get; set; }
    }
    public class StatsData
    {
        public TestResult Stats { get; set; }
    }

    
}
