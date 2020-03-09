using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BHHC.Core.Models
{
    public class Constants
    {
        public static List<Reason> SeededReasons => new List<Reason>
        {
            new Reason { Description = "test stability", ImportanceType = ImportanceType.LOW, ReasonType = ReasonType.STABILITY},
            new Reason { Description = "test benetifs", ImportanceType = ImportanceType.LOW, ReasonType = ReasonType.BENEFITS },
            new Reason { Description = "test", ImportanceType = ImportanceType.LOW, ReasonType = ReasonType.STABILITY },
        };
    }
}
