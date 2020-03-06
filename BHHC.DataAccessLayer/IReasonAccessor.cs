using BHHC.Core;
using System.Collections.Generic;

namespace BHHC.DataAccessLayer
{
    public interface IReasonAccessor
    {
        int InsertReason(Reason reason);
        int UpdateReason(Reason reason);
        IEnumerable<Reason> GetReasons(ReasonType reasonType, ImportanceType importanceType);
        Reason GetReasonById(int reasonId);
        IEnumerable<Reason> GetAllReasons();
    }
}
