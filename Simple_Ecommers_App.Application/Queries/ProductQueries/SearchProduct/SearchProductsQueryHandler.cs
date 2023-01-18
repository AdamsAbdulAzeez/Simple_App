using AutoMapper;
using MediatR;
using Simple_Ecommers_App.Application.Dtos;
using Simple_Ecommers_App.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple_Ecommers_App.Application.Queries.ProductQueries.SearchProduct
{
    public class SearchProductsQueryHandler : IRequestHandler<SearchProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductDto>> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.ProductRepository.Find(x => x.Name.ToLower().Contains(request.Name.ToLower()));
            //return _mapper.Map<IEnumerable<ProductDto>>(products);
            var productsDto = new List<ProductDto>();
            foreach (var item in products)
            {
                productsDto.Add(new ProductDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity,
                });
            }
            return productsDto;
        }
    }
}
