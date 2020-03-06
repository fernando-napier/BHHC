using BHHC.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BHHC.ServiceLayer
{
    public interface IReasonService
    {
        int InsertReason(Reason reason);
        int UpdateReason(int reasonID, Reason reason);
        IEnumerable<Reason> GetReasons(ReasonType reasonType, ImportanceType importanceType);
        IEnumerable<Reason> GetAllReasons();


    }
}
