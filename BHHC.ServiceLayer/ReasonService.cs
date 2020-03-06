using BHHC.Core;
using BHHC.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BHHC.ServiceLayer
{
    public class ReasonService : IReasonService
    {
        public IReasonAccessor _reasonAccessor;

        public ReasonService(IReasonAccessor reasonAccessor)
        {
            _reasonAccessor = reasonAccessor;
        }

        public IEnumerable<Reason> GetAllReasons()
        {
            return _reasonAccessor.GetAllReasons();
        }

        public IEnumerable<Reason> GetReasons(ReasonType reasonType, ImportanceType importanceType)
        {
            return _reasonAccessor.GetReasons(reasonType, importanceType);
        }

        public int InsertReason(Reason reason)
        {
            return _reasonAccessor.InsertReason(reason);
        }

        public int UpdateReason(int reasonId, Reason reason)
        {
            var reasonToUpdate = _reasonAccessor.GetReasonById(reasonId);

            if (reasonToUpdate == null)
            {
                return 0;
            }

            return _reasonAccessor.UpdateReason(reason);
        }
    }
}
