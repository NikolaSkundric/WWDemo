using MediatR;
using WWDemo.Application.DTOs;

namespace WWDemo.Application.Products.Queries.GetProductBySerialNumber
{
    public class GetProductBySerialNumberQuery : IRequest<ProductRepresentation>
    {
        string? SerialNumber;
    }
}
