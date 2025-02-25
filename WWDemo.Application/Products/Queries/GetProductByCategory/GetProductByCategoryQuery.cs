using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWDemo.Application.DTOs;
using MediatR;

namespace WWDemo.Application.Products.Queries.GetProductByCategory
{
    public class GetProductByCategoryQuery : IRequest<ProductRepresentation>
    {
        public string? Category { get; set; }
    }
}
