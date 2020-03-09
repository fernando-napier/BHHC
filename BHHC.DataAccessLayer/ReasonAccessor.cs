using BHHC.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHHC.DataAccessLayer
{
    public class ReasonAccessor : IReasonAccessor
    {
        private ReasonContext _reasonContext;

        public ReasonAccessor(ReasonContext reasonContext)
        {
            _reasonContext = reasonContext;
        }

        public async Task<int> DeleteReasonAsync(Reason reason)
        {
            var deletedEntry = _reasonContext.Reasons.Remove(reason);
            await _reasonContext.SaveChangesAsync();

            return deletedEntry.State == EntityState.Deleted ? 1 : 0;
        }

        public async Task<List<Reason>> GetAllReasonsAsync()
        {
            // Entity Framework does it's own thing when actually materializing the objects (executing the sql query) being grabbed from the context
            // luckily this is not complex data access but when using EF for data access be mindful of calling ToList()/ToArray() when manipulating result sets from EF
            var returnList = await _reasonContext.Reasons.ToListAsync();
            return returnList.OrderByDescending(x => x.ImportanceType).ToList();
        }

        public Task<Reason> GetReasonByIdAsync(int reasonId)
        {
            return _reasonContext.Reasons.Where(x => x.ReasonId == reasonId).FirstOrDefaultAsync();
        }

        public Task<List<Reason>> GetReasonsAsync(ReasonType reasonType, ImportanceType importanceType)
        {
            return _reasonContext.Reasons.Where(x => x.ImportanceType == importanceType && x.ReasonType == reasonType).ToListAsync();
        }

        public async Task<int> InsertReasonAsync(Reason reason)
        {
            _reasonContext.Add(reason);
            await _reasonContext.SaveChangesAsync();
            return reason.ReasonId;

        }

        public async Task<int> UpdateReasonAsync(Reason reason)
        {
            var reasonToUpdate = await _reasonContext.Reasons.Where(x => x.ReasonId == reason.ReasonId).FirstOrDefaultAsync();


            reasonToUpdate.ImportanceType = reason.ImportanceType;
            reasonToUpdate.ReasonType = reason.ReasonType;
            reasonToUpdate.Description = reason.Description;

            await _reasonContext.SaveChangesAsync();

            return reason.ReasonId;
            
        }
    }
}
