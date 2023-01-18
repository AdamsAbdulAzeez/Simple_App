using MediatR;
using Simple_Ecommers_App.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple_Ecommers_App.Application.Commands.DeleteCommand.DeleteOrderItem
{
    public class DeleteOrderItemHandler : IRequestHandler<DeleteOrderItemCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = await _unitOfWork.OrderItemRepository.GetById(request.Id);
            if (orderItem != null)
            {
                await _unitOfWork.OrderItemRepository.Delete(orderItem);
            }
            var response = await _unitOfWork.CommitAsync();
            if (response)
            {
                return Unit.Value;
            }
            throw new Exception("Unable to delete order item");
        }
    }
}
