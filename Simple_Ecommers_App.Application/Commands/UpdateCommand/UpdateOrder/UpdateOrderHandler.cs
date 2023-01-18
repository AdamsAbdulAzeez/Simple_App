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

namespace Simple_Ecommers_App.Application.Commands.UpdateCommand.UpdateOrder
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.OrderRepository.GetById(request.Id);
            if (order == null)
                throw new Exception("Order not found.");

            order.CustomerId = request.CustomerId;
            order.Items = new List<OrderItemEntity>(request.Items.Select(i => new OrderItemEntity
            {
                Id = i.Id,
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }));
            order.TotalAmount = request.TotalAmount;
            order.OrderDate = request.OrderDate;


            //update the order
            await _unitOfWork.OrderRepository.Update(order);

            var response = await _unitOfWork.CommitAsync();
            if (response)
            {
                return Unit.Value;
            }
            throw new Exception("Unable to update order");
        }
    }
}
