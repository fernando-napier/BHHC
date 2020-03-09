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

        public static string CreateReasonDB => @"CREATE TABLE IF NOT EXISTS [Reasons] (
                          [ReasonId] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                          [Description] NVARCHAR(2048)  NULL,
                          [ReasonType] TEXT CHECK(ReasonType IN ('BENEFITS','STABILITY','CAREER_ADVANCEMENT','CULTURE')) NOT NULL DEFAULT 'STABILITY',
                          [ImportanceType] TEXT CHECK(ImportanceType IN ('LOW','MEDIUM','HIGH')) NOT NULL DEFAULT 'LOW'
                          )";

        public static DbContextOptions<ReasonContext> Options => new DbContextOptionsBuilder<ReasonContext>()
                .UseInMemoryDatabase("reasons")
                .Options;
    }
}
