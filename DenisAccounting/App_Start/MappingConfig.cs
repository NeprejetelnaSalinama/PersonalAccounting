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
            Mapper.CreateMap<Operation, Models.Operations.IndexViewModel>()
                .ForMember(view => view.Amount, (IMemberConfigurationExpression<Operation> options) => options.MapFrom(entity => entity.Amount.ToString()))
                .ForMember(view => view.CategoryName, (IMemberConfigurationExpression<Operation> options) => options.MapFrom(entity => entity.Category.Name))
                .ForMember(view => view.CurrencyCode , (IMemberConfigurationExpression<Operation> options) => options.MapFrom(entity => entity.Currency.Code));

            Mapper.CreateMap<Operation, Models.Operations.EditViewModel>()
                .ForMember(view => view.Amount, (IMemberConfigurationExpression<Operation> options) => options.MapFrom(entity => entity.Amount.ToString()))
                .ForMember(view => view.CategoryId, options => options.MapFrom(entity => entity.Category.Id.ToString()))
                .ForMember(view => view.CurrencyId, options => options.MapFrom(entity => entity.Currency.Id.ToString()));

            Mapper.CreateMap<Operation, Models.Operations.CreateViewModel>();
        }
    }
}