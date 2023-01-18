using MediatR;
using Simple_Ecommers_App.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Ecommers_App.Application.Queries.ProductQueries.SearchProduct
{
    public class SearchProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
        public string Name { get; set; }

        public SearchProductsQuery(string name)
        {
            Name = name;
        }
    }
}
