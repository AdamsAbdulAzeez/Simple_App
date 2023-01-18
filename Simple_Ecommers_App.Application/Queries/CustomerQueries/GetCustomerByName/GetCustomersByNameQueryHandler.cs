using AutoMapper;
using MediatR;
using Simple_Ecommers_App.Application.Dtos;
using Simple_Ecommers_App.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple_Ecommers_App.Application.Queries.CustomerQueries.GetCustomerByName
{
    public class GetCustomersByNameQueryHandler : IRequestHandler<GetCustomersByNameQuery, IEnumerable<CustomerDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCustomersByNameQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CustomerDto>> Handle(GetCustomersByNameQuery request, CancellationToken cancellationToken)
        {
            var customers = await _unitOfWork.CustomerRepository.Find(x => x.Name.ToLower().Contains(request.Name.ToLower()));
            //return _mapper.Map<IEnumerable<CustomerDto>>(customers);
            var customersDto = new List<CustomerDto>();
            foreach (var item in customers)
            {
                customersDto.Add(new CustomerDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    Email = item.Email,
                    Phone = item.Phone,
                });
            }
            return customersDto;
        }
    }
}
