using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.TaxRegimeFeature.Queries;
using DespachoWorkspace.Management.Application.Common.Models.Results;

namespace DespachoWorkspace.Management.Application.Features.TaxRegimeFeature.Queries
{
    public record GetAllTaxRegimesQuery : IRequest<IDataResult<List<GetAllTaxRegimesResponse>>>
    {
        
    }
}