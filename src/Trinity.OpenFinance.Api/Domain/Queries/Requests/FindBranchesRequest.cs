using MediatR;
using Trinity.OpenFinance.Api.Domain.Entities;

namespace Trinity.OpenFinance.Api.Domain.Queries.Requests
{
    public class FindBranchesRequest: IRequest<BranchData>
    {
        public int? Page { get; set; }

        public int? Size { get; set; }
    }
}