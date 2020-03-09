using BHHC.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BHHC.DataAccessLayer
{
    public interface IReasonAccessor
    {
        Task<int> InsertReasonAsync(Reason reason);
        Task<int> UpdateReasonAsync(Reason reason);
        Task<List<Reason>> GetReasonsAsync(ReasonType reasonType, ImportanceType importanceType);
        Task<Reason> GetReasonByIdAsync(int reasonId);
        Task<List<Reason>> GetAllReasonsAsync();
        Task<int> DeleteReasonAsync(Reason reason);
    }
}
