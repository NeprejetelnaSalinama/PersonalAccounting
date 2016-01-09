using System;
using AutoMapper;
using DenisAccounting.Models;
using DenisAccounting.Database;
using DenisAccounting.Models.Home;
using DenisAccounting.Models.Operations;
using DenisAccounting.Constants;

namespace DenisAccounting
{
    public static class MappingConfig
    {
        public static void RegisterMappings()
        {
            RegisterOperationsMappings();
        }

        private static void RegisterOperationsMappings()
        {
            Mapper.CreateMap<Operation, OperationViewModel>()
                .ForMember(view => view.Id, options => options.MapFrom(entity => entity.Id))
                .ForMember(view => view.Amount, options => options.MapFrom(entity => entity.Amount.ToString()))
                .ForMember(view => view.Date, options => options.MapFrom(entity => entity.Date))
                .ForMember(view => view.Description, options => options.MapFrom(entity => entity.Description))
                .ForMember(view => view.CategoryName, options => options.MapFrom(entity => entity.Category.Name));
        }
    }
}