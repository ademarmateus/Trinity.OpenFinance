using System.Threading.Tasks;
using Trinity.OpenFinance.Api.Domain.Entities;

namespace Trinity.OpenFinance.Api.Domain.Interfaces
{
    public interface IGetBranches
    {
        Task<BranchData> GetAllBranchesAsync(int? page, int? pageSize);
    }
}