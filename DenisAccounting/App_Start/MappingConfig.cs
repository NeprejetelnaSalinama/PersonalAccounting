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
                .ForMember(view => view.Amount, (IMemberConfigurationExpression<Operation> options) => options.MapFrom(entity => entity.Amount.ToString() + " " + entity.Currency.Code))
                .ForMember(view => view.CategoryName, (IMemberConfigurationExpression<Operation> options) => options.MapFrom(entity => entity.Category.Name))
                .ForMember(view => view.CurrencyCode , (IMemberConfigurationExpression<Operation> options) => options.MapFrom(entity => entity.Currency.Code));

            Mapper.CreateMap<CreateViewModel, Operation>();

        }
    }
}