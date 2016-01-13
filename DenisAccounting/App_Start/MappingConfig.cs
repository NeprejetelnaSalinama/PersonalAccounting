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
            Mapper.CreateMap<Operation, Models.Operations.OperationViewModel>()
                .ForMember(view => view.Amount, (IMemberConfigurationExpression<Operation> options) => options.MapFrom(entity => $"{entity.Amount:0.00} {entity.Currency.Code}"))
                .ForMember(view => view.CategoryName, (IMemberConfigurationExpression<Operation> options) => options.MapFrom(entity => entity.Category.Name))
                .ForMember(view => view.Date, (IMemberConfigurationExpression<Operation> options) => options.MapFrom(entity => entity.Date.ToString(Constants.SharedConstants.DATE_FORMAT)))
                .ForMember(view => view.CurrencyCode, (IMemberConfigurationExpression<Operation> options) => options.MapFrom(entity => entity.Currency.Code));

            Mapper.CreateMap<CreateViewModel, Operation>()
                .ForMember(view => view.Amount, (IMemberConfigurationExpression<CreateViewModel> model) => model.MapFrom(entity => entity.CategoryType == Category.CategoryType.Income ? entity.Amount : -entity.Amount));

        }
    }
}