using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWDemo.Application.DTOs;
using WWDemo.Application.Products.Queries.GetProductsByPrice;
using WWDemo.Data.Products;

namespace WWDemo.Application.Products.Queries.GetProductsByAmount
{
    class GetProductsByAmountHandler
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;
        public GetProductsByAmountHandler(IMapper mapper, IProductRepository productRepository)
        {
            mapper = mapper;
            productRepository = productRepository;
        }
        public async Task<List<ProductRepresentation>> Handle(GetProductsByAmountQuery request, CancellationToken cancellationToken)
        {
            var result = await productRepository.GetProductsByAmount(request.Amount);
            return mapper.Map<List<Models.Product>, List<DTOs.ProductRepresentation>>(result!);
        }
    }
}
