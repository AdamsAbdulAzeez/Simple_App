using MediatR;
using Simple_Ecommers_App.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple_Ecommers_App.Application.Commands.UpdateCommand.UpdateOrderItem
{
    public class UpdateOrderItemHandler : IRequestHandler<UpdateOrderItemCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrderItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = await _unitOfWork.OrderItemRepository.GetById(request.Id);
            if (orderItem == null)
                throw new Exception("Order item not found.");

            orderItem.ProductId = request.ProductId;
            orderItem.Quantity = request.Quantity;
            orderItem.UnitPrice = request.UnitPrice;

            await _unitOfWork.OrderItemRepository.Update(orderItem);
            var response = await _unitOfWork.CommitAsync();
            if (response)
            {
                return Unit.Value;
            }
            throw new Exception("Unable to update order item");
        }
    }
}
