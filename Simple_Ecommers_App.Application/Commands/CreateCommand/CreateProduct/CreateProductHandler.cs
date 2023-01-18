using MediatR;
using Simple_Ecommers_App.Domain.Entities;
using Simple_Ecommers_App.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple_Ecommers_App.Application.Commands.CreateCommand.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new ProductEntity
            {
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity
            };

            await _unitOfWork.ProductRepository.Add(product);
            var response = await _unitOfWork.CommitAsync();
            if (response)
            {
                return product.Id;
            }
            throw new Exception("Unable to create product");
        }
    }
}
