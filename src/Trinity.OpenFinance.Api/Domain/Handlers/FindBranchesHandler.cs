using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Trinity.OpenFinance.Api.Domain.Entities;
using Trinity.OpenFinance.Api.Domain.Interfaces;
using Trinity.OpenFinance.Api.Domain.Queries.Requests;

namespace Trinity.OpenFinance.Api.Domain.Handlers
{
    public class FindBranchesHandler: IRequestHandler<FindBranchesRequest, BranchData>
    {

        private readonly IGetBranches _getBranches;

        public FindBranchesHandler(IGetBranches getBranches)
        {
            _getBranches = getBranches ?? throw new ArgumentNullException(nameof(getBranches));
        }

        public async Task<BranchData> Handle(FindBranchesRequest request, CancellationToken cancellationToken)
        {
            return await _getBranches.GetAllBranchesAsync(request.Page, request.Size);
        }
    }
}