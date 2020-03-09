using BHHC.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BHHC.ServiceLayer
{
    public interface IReasonService
    {
        Task<int> InsertReasonAsync(Reason reason);
        Task<int> UpdateReasonAsync(int reasonID, Reason reason);
        Task<List<Reason>> GetReasonsAsync(ReasonType reasonType, ImportanceType importanceType);
        Task<List<Reason>> GetAllReasonsAsync();
        Task<int> DeleteReasonAsync(Reason reason);
        Task<Reason> GetReasonByIdAsync(int value);
    }
}
