namespace EmlaBot.Models
{
    public class ChastitySession
    {
        public string ChastitySessionId { get; set; }
        public int CloseDate { get; set; }
        public int Created { get; set; }
        public int Duration { get; set; }
        public int MaxDuration { get; set; }
        public int MinDuration { get; set; }
        public int Offer { get; set; }
        public int RandomDuration { get; set; }
        public int StartDate { get; set; }
        public int StartDuration { get; set; }
        public int Status { get; set; }
        public int TimeInLock { get; set; }
        public string WearerId { get; set; }
    }
}