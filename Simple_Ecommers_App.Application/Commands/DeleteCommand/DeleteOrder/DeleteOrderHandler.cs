using MediatR;
using Simple_Ecommers_App.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple_Ecommers_App.Application.Commands.DeleteCommand.DeleteOrder
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.OrderRepository.GetById(request.Id);
            if (order != null)
            {
                await _unitOfWork.OrderRepository.Delete(order);
            }
            var response = await _unitOfWork.CommitAsync();
            if (response)
            {
                return Unit.Value;
            }
            throw new Exception("Unable to delete order");
        }
    }
}
