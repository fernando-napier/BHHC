using BHHC.Core;
using BHHC.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BHHC.ServiceLayer
{
    public class ReasonService : IReasonService
    {
        public IReasonAccessor _reasonAccessor;

        public ReasonService(IReasonAccessor reasonAccessor)
        {
            _reasonAccessor = reasonAccessor;
        }

        public Task<List<Reason>> GetAllReasonsAsync()
        {
            return _reasonAccessor.GetAllReasonsAsync();
        }

        public Task<List<Reason>> GetReasonsAsync(ReasonType reasonType, ImportanceType importanceType)
        {
            return _reasonAccessor.GetReasonsAsync(reasonType, importanceType);
        }

        public Task<int> InsertReasonAsync(Reason reason)
        {
            return _reasonAccessor.InsertReasonAsync(reason);
        }

        public async Task<int> UpdateReasonAsync(int reasonId, Reason reason)
        {
            var reasonToUpdate = await _reasonAccessor.GetReasonByIdAsync(reasonId);

            if (reasonToUpdate == null)
            {
                return 0;
            }

            return await _reasonAccessor.UpdateReasonAsync(reason);
        }

        public Task<Reason> GetReasonByIdAsync(int reasonId)
        {
            return _reasonAccessor.GetReasonByIdAsync(reasonId);
        }

        public Task<int> DeleteReasonAsync(Reason reason)
        {
            return _reasonAccessor.DeleteReasonAsync(reason);
        }
    }
}
