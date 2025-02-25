using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWDemo.Application.DTOs;
using WWDemo.Application.Products.Queries.GetProductBySerialNumber;
using WWDemo.Data.Products;

namespace WWDemo.Application.Products.Queries.GetProductByCategory
{
    class GetProductByCategoryHandler
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductByCategoryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<List<ProductRepresentation>> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            var queryResult = await _productRepository.GetProductByCategory(request.Category);
            return _mapper.Map<List<Models.Product>, List<DTOs.ProductRepresentation>>(queryResult!);
        }
    }
}
