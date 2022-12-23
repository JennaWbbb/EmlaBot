namespace EmlaBot.Models
{
    public class Action
    {
        public int Duration { get; set; }
        public string UserId { get; set; }
        public int Time { get; set; }
        public string ProtocolId { get; set; }
        public string Message { get; set; }
        public string Comment { get; set; }
        public int? Pillory { get; set; }
        public int? TimeValue { get; set; }
    }
}