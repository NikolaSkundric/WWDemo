using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WWDemo.Application.DTOs;

namespace WWDemo.Application.Products.Queries.GetProductsByAmount
{
    public class GetProductsByAmountQuery : IRequest<List<ProductRepresentation>>
    {
        public uint? Amount { get; set; }
    }
}
