using MediatR;
using Microsoft.AspNetCore.Mvc;
using WWDemo.Api.Requests;
using WWDemo.Application.DTOs;
using WWDemo.Application.Products.Commands.AddProduct;
using WWDemo.Application.Products.Queries.GetAllProducts;
using WWDemo.Application.Products.Queries.GetProductBySerialNumber;
using WWDemo.Application.Products.Queries.GetProductsByPrice;
using WWDemo.Application.Products.Queries.GetProductByCategory;
using WWDemo.Application.Products.Queries.GetProductsByAmount;

namespace WWDemo.Api.Controllers
{
    [Route("[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> AddProduct(AddProductRequest request)
		{
			await _mediator.Send(new AddProductCommand
			{
				Name = request.Name,
				Price = request.Price,
				SerialNumber = request.SerialNumber,
            });

            return Ok();
        }

		[HttpGet]
		public async Task<IActionResult> GetProductByName([FromRoute(Name = "name")]string name) 
		{
			return Ok(); //TO BE IMPLEMENTED
		}

		[HttpGet]
        [ProducesResponseType(typeof(List<ProductRepresentation>), StatusCodes.Status200OK)]
        public async Task<List<ProductRepresentation>> GetAllProducts()
		{
			var result = await _mediator.Send(new GetAllProductsQuery());

			return result;
		}

		[HttpGet]
		public async Task<IActionResult> GetProductsByPrice(string price) 
		{
			var results  = await _mediator.Send(new GetProductsByPriceQuery() { Price = price })

            return Ok(results);
		}

		[HttpGet("serial-number")]
		public async Task<IActionResult> GetProductBySerialNumber([FromRoute(Name = "serial-number")]string serialNumber)
		{
            var result = await _mediator.Send(new GetProductBySerialNumberQuery() { SerialNumber = serialNumber });// map serial number
            
			return Ok(result);
		}

		[HttpGet("category")]
		public async Task<IActionResult> GetProductByCategory([FromRoute(Name = "category")]string category)
		{
			var result = await _mediator.Send(new GetProductByCategoryQuery() { Category = category });
			return Ok(result);
		}

		[HttpGet("amount")]
		public async Task<IActionResult> GetProductsByAmount([FromRoute(Name = "amount")]uint? amount)
		{
			var result = await _mediator.Send(new GetProductsByAmountQuery() { Amount = amount });
			return Ok(result);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteProduct()
		{
			return Ok();
		}
	}
}
