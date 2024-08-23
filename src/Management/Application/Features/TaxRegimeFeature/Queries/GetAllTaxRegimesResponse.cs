using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.TaxRegimeFeature.Queries
{
    public record GetAllTaxRegimesResponse
        {
            public Guid Id { get; init; }
            public string? Code { get; init; }
        }
}