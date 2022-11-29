﻿using AutoMapper;
using Cimas.Models.Auth;
using Cimas.Models.From;
using Cimas.Service.Authorization.Descriptors;
using Cimas.Service.Companies.Descriptors;

namespace Cimas.Infrastructure.Mapper
{
    public class DescriptorMapper : Profile
    {
        public DescriptorMapper()
        {
            CreateMap<RegistrationModel, RegistrationDescriptor>();
            CreateMap<LoginModel, LoginDescriptor>();
            CreateMap<AreaAddModel, AreaAddDescriptor>();
        }
    }
}
