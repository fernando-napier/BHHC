using System;

namespace BHHC.Core
{
    public class Reason
    {
        public int ReasonId { get; set; }
        public string Description { get; set; }
        public ReasonType ReasonType { get; set; }
        public ImportanceType ImportanceType { get; set; }

    }
}
