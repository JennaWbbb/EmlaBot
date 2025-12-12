using System;
using System.Collections.Generic;
using System.Text;

namespace EmlaBot.Models
{
    public enum ActionTypeDescription
    {
        ApiAdd,
        ApiAddMinimum,
        ApiAddMaximum,
        ApiAddRequirementRandom,
        ApiSub,
        ApiSubMinimum,
        ApiSubMaximum,
        ApiSubRequirementRandom,
        CreateSession,
        UpdateSessionHolder,
        UpdateSessionPilloryActivated,
        UpdateSessionPilloryChanged,
        Requirement,
        Vote,
        PilloryVote,
        WheelOfFortune
    }
}
