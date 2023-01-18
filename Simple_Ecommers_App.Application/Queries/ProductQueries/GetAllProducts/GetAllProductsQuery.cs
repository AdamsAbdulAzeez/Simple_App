using MediatR;
using Simple_Ecommers_App.Application.Dtos;
using System.Collections.Generic;

namespace Simple_Ecommers_App.Application.Queries.ProductQueries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>> { }
}
