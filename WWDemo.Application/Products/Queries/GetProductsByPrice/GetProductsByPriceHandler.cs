using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWDemo.Application.DTOs;
using WWDemo.Data.Products;
using WWDemo.Models;

namespace WWDemo.Application.Products.Queries.GetProductsByPrice
{
    public class GetProductsByPriceHandler : IRequestHandler<GetProductsByPriceQuery, List<ProductRepresentation>>
    {
        private readonly Mapper mapper;
        private readonly IProductRepository productRepository;
        public GetProductsByPriceHandler(IMapper mapper, IProductRepository productRepository)
        {
            mapper = mapper;
            productRepository = productRepository;
        }
        public async Task<List<ProductRepresentation>> Handle(GetProductsByPriceQuery request, CancellationToken cancellationToken)
        {
            var result = await productRepository.GetProductsByPrice(request.Price);
            return mapper.Map<List<Models.Product>, List<DTOs.ProductRepresentation>>(result!);
        }
    }
}
