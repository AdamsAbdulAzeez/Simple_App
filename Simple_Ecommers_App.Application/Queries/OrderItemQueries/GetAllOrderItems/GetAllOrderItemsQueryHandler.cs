using AutoMapper;
using MediatR;
using Simple_Ecommers_App.Application.Dtos;
using Simple_Ecommers_App.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple_Ecommers_App.Application.Queries.OrderItemQueries.GetAllOrderItems
{
    public class GetAllOrderItemsQueryHandler : IRequestHandler<GetAllOrderItemsQuery, IEnumerable<OrderItemDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllOrderItemsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<OrderItemDto>> Handle(GetAllOrderItemsQuery request, CancellationToken cancellationToken)
        {
            var orderItems = await _unitOfWork.OrderItemRepository.GetAll();
            //return _mapper.Map<IEnumerable<OrderItemDto>>(orderItems);
            var orderItemsDto = new List<OrderItemDto>();
            foreach (var item in orderItems)
            {
                orderItemsDto.Add(new OrderItemDto()
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity,
                });
            }
            return orderItemsDto;
        }
    }
}
