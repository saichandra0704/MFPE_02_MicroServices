using PolicyAdmin.ConsumerMS.API.Interface;
using PolicyAdmin.ConsumerMS.API.Models;
using PolicyAdmin.ConsumerMS.API.Models.DAO;
using PolicyAdmin.ConsumerMS.API.Models.Response;
using PolicyAdmin.ConsumerMS.API.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.ConsumerMS.API.Repository
{
    public class ConsumerRepository : IConsumerRepository
    {
        private readonly IConsumerDBService _provider;

        public ConsumerRepository(IConsumerDBService provider)
        {
            _provider = provider;
        }

       public async Task<Status> CreateConsumerBusiness(Consumer consumer)
        {
            BusinessMaster businessMaster = _provider.GetBusinessMaster(consumer.Business.BusinessType);
            Status validation = ValidateBusinessData(consumer.Business, businessMaster);
            if (!validation.Success)
                return validation;

            if(_provider.CreateConsumerBusiness(consumer))
                return new Status { Success = true, Message = "Consumer Created Successfully", Data =new {Id = consumer.Id } };
            return new Status { Success = false, Message = "Database Error"};

        }

        public async Task<Status> UpdateConsumerBusiness(Consumer consumer)
        {
            BusinessMaster businessMaster = _provider.GetBusinessMaster(consumer.Business.BusinessType);
            Status validation = ValidateBusinessData(consumer.Business, businessMaster);

            if (!validation.Success)
                return validation;
            if (_provider.UpdateConsumerBusiness(consumer))
                return new Status { Success = true, Message = "Consumer Updated Successfully", Data = new { Id = consumer.Id } };
            return new Status { Success = false, Message = "Database Error" };
        }


        public async Task<Status> CreateBusinessProperty(Property property)
        {
            PropertyMaster propertyMaster = _provider.GetPropertyMaster(property.PropertyType);
            Status validation = ValidatePropertyData(property, propertyMaster);
            if (!validation.Success)
                return validation;
            if (_provider.CreateBusinessProperty(property))
                return new Status { Success = true, Message = "Property Created Successfully", Data = new { Id = property.Id } };
            return new Status { Success = false, Message = "Database Error" };
        }

        public async Task<Status> UpdateBusinessProperty(Property property)
        {
            PropertyMaster propertyMaster = _provider.GetPropertyMaster(property.PropertyType);
            Status validation = ValidatePropertyData(property, propertyMaster);
            if (!validation.Success)
                return validation;
            if( _provider.UpdateBusinessProperty(property))
                return new Status { Success = true, Message = "Property Updated Successfully", Data = new { Id = property.Id } };
            return new Status { Success = false, Message = "Database Error" };
        }

        public async Task<Consumer> ViewConsumerBusiness(int id)
        {
            return _provider.GetConsumerBusiness(id);
        }
        public async Task<Property> ViewBusinessProperty(int id)
        {
            return _provider.GetBusinessProperty(id);
        }

        

        



        private int Years(DateTime start, DateTime end)
        {
            return (end.Year - start.Year - 1) +
                (((end.Month > start.Month) ||
                ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
        }

        public Status ValidateBusinessData(Business business, BusinessMaster businessMaster)
        {
            if (business.AnnualTurnOver < businessMaster.MinimumAnnualTurnOver)
                return new Status { Success = false, Message = $"Minimum Annual Tunover should be {businessMaster.MinimumAnnualTurnOver}" };
            if (business.CapitalInvested < businessMaster.MinimumCapitalInvested)
                return new Status { Success = false, Message = $"Minimum Capital Investment should be { businessMaster.MinimumCapitalInvested}" };
            if (Years(business.BusinesIncorporation, DateTime.Now) < businessMaster.MinimumBusinessAgeInYears)
                return new Status { Success = false, Message = $"Minimum Business Age should be { businessMaster.MinimumBusinessAgeInYears}" };
            if (business.TotalEmployees < businessMaster.MinimumTotalEmployees)
                return new Status { Success = false, Message = $"Minimum Employees should be { businessMaster.MinimumTotalEmployees}" };
            return new Status { Success = true };
        }
        public Status ValidatePropertyData(Property property, PropertyMaster propertyMaster)
        {
            if (!( propertyMaster.MinimumCostOfAsset<=property.CostOfAsset && property.CostOfAsset <= propertyMaster.MaximumCostOfAsset))
                return new Status { Success = false, Message = $"Cost of Property should be between {propertyMaster.MinimumCostOfAsset} and {propertyMaster.MaximumCostOfAsset}" };
            
            if (!( propertyMaster.MinimumArea<=property.BuildingSqFt && property.BuildingSqFt <= propertyMaster.MaximumArea))
                return new Status { Success = false, Message = $"Area of Property should be between {propertyMaster.MinimumArea} and {propertyMaster.MaximumArea}" };
            
            
            if (!( propertyMaster.PropertyAgeMin <= property.PropertyAge && property.PropertyAge <= propertyMaster.PropertyAgeMax))
                return new Status { Success = false, Message = $"Age of Property should be between {propertyMaster.PropertyAgeMin} and {propertyMaster.PropertyAgeMax}" };

            return new Status { Success = true };
        }

    }
}
