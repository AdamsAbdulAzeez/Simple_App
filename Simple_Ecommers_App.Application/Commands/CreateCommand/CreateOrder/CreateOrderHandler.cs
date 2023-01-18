using AutoMapper;
using MediatR;
using Simple_Ecommers_App.Domain.Entities;
using Simple_Ecommers_App.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple_Ecommers_App.Application.Commands.CreateCommand.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new OrderEntity
            {
                CustomerId = request.CustomerId,
                Items = new List<OrderItemEntity>(request.Items.Select(i => new OrderItemEntity
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                })),
                TotalAmount = request.TotalAmount,
                OrderDate = request.OrderDate
            };
            
            await _unitOfWork.OrderRepository.Add(order);
            var response = await _unitOfWork.CommitAsync();
            if (response)
            {
                return order.Id;
            }
            throw new Exception("Unable to create order");
        }
    }
}
