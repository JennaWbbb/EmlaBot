using System.Collections.Generic;

namespace EmlaBot.Models
{
    public class AggregatedAction
    {
        public string Action { get; set; }
        public int Time { get; set; }
        public int Until { get; set; }
        public int? Duration { get; set; }
        public List<Action> Actions { get; set; }
        public string Message { get; set; }
        public string Comment { get; set; }
        public int? Pillory { get; set; }
    }
}