using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWDemo.Application.DTOs;

namespace WWDemo.Application.Products.Queries.GetProductsByPrice
{
    public class GetProductsByPriceQuery : IRequest<List<ProductRepresentation>>
    {
        public string? Price { get; set; }
    }
}
