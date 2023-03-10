using AutoMapper;
using MediatR;
using Simple_Ecommers_App.Application.Dtos;
using Simple_Ecommers_App.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple_Ecommers_App.Application.Queries.OrderQueries.GetOrdersByCustomerId
{
    public class GetOrdersByCustomerIdQueryHandler : IRequestHandler<GetOrdersByCustomerIdQuery, IEnumerable<OrderDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOrdersByCustomerIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetOrdersByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.OrderRepository.Find(order => order.CustomerId == request.CustomerId);
            //return _mapper.Map<IEnumerable<OrderDto>>(orders);
            var ordersDto = new List<OrderDto>();
            foreach (var item in orders)
            {
                ordersDto.Add(new OrderDto()
                {
                    Id = item.Id,
                    CustomerId = item.CustomerId,
                    OrderDate = item.OrderDate,
                    TotalAmount = item.TotalAmount,
                    Items = new List<OrderItemDto>(item.Items.Select(i => new OrderItemDto
                    {
                        Id = i.Id,
                        ProductId = i.ProductId,
                        Quantity = i.Quantity,
                        UnitPrice = i.UnitPrice
                    })),
                });
            }
            return ordersDto;
        }
    }
}
