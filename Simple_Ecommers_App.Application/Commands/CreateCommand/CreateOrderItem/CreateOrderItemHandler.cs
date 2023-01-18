using MediatR;
using Simple_Ecommers_App.Domain.Entities;
using Simple_Ecommers_App.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple_Ecommers_App.Application.Commands.CreateCommand.CreateOrderItem
{
    public class CreateOrderItemHandler : IRequestHandler<CreateOrderItemCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = new OrderItemEntity
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice
            };

            await _unitOfWork.OrderItemRepository.Add(orderItem);
            var response = await _unitOfWork.CommitAsync();
            if (response)
            {
                return orderItem.Id;
            }
            throw new Exception("Unable to create order item");
        }
    }
}
