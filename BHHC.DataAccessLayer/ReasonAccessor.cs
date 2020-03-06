using BHHC.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BHHC.DataAccessLayer
{
    public class ReasonAccessor : IReasonAccessor
    {
        private ReasonContext _reasonContext;

        public ReasonAccessor(ReasonContext reasonContext, IConfiguration configuration)
        {
            _reasonContext = reasonContext;
        }

        public IEnumerable<Reason> GetAllReasons()
        {
            // Entity Framework does it's own thing when actually materializing the objects (executing the sql query) being grabbed from the context
            // luckily this is not complex data access but when using EF for data access be mindful of calling ToList()/ToArray() when manipulating result sets from EF
            return _reasonContext.Reasons;
        }

        public Reason GetReasonById(int reasonId)
        {
            return _reasonContext.Reasons.Where(x => x.ReasonId == reasonId).FirstOrDefault();
        }

        public IEnumerable<Reason> GetReasons(ReasonType reasonType, ImportanceType importanceType)
        {
            return _reasonContext.Reasons.Where(x => x.Importance == importanceType && x.ReasonType == reasonType);
        }

        public int InsertReason(Reason reason)
        {
            _reasonContext.Add(reason);
            _reasonContext.SaveChanges();
            return reason.ReasonId;

        }

        public int UpdateReason(Reason reason)
        {
            var reasonToUpdate = _reasonContext.Reasons.Where(x => x.ReasonId == reason.ReasonId).FirstOrDefault();


            reasonToUpdate.Importance = reason.Importance;
            reasonToUpdate.ReasonType = reason.ReasonType;
            reasonToUpdate.Description = reason.Description;

            _reasonContext.SaveChanges();

            return reason.ReasonId;
            
        }
    }
}
