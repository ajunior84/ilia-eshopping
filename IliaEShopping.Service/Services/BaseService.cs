using AutoMapper;
using FluentValidation;
using IliaEShopping.Domain.Entities;
using IliaEShopping.Infrastructure.Interfaces;
using IliaEShopping.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IliaEShopping.Service.Services
{
    public abstract class BaseService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public BaseService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
    }
}
