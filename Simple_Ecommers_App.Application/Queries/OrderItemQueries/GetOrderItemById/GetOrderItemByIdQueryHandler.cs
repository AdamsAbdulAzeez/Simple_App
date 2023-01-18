using AutoMapper;
using MediatR;
using Simple_Ecommers_App.Application.Dtos;
using Simple_Ecommers_App.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple_Ecommers_App.Application.Queries.OrderItemQueries.GetOrderItemById
{
    public class GetOrderItemByIdQueryHandler : IRequestHandler<GetOrderItemByIdQuery, OrderItemDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOrderItemByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderItemDto> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
        {
            var orderItem = await _unitOfWork.OrderItemRepository.GetById(request.Id);
            if (orderItem == null)
                throw new Exception("Order item not found.");

            //return _mapper.Map<OrderItemDto>(orderItem);
            var orderItemDto = new OrderItemDto()
            {
                Id = orderItem.Id,
                ProductId = orderItem.ProductId,
                UnitPrice = orderItem.UnitPrice,
                Quantity = orderItem.Quantity,
            };
            return orderItemDto;
        }
    }
}
