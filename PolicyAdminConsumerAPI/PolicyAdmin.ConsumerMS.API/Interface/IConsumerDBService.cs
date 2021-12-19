using PolicyAdmin.ConsumerMS.API.Models;
using PolicyAdmin.ConsumerMS.API.Models.DAO;
using PolicyAdmin.ConsumerMS.API.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.ConsumerMS.API.Interface
{
    public interface IConsumerDBService
    {
        bool CreateConsumerBusiness(Consumer Consumer);
        bool UpdateConsumerBusiness(Consumer Consumer);

        bool CreateBusinessProperty(Property Property);
        bool UpdateBusinessProperty(Property Property);

        Consumer GetConsumerBusiness(int consumerId);
        Property GetBusinessProperty(int propertyId);

        BusinessMaster GetBusinessMaster(BusinessType busniessType);
        PropertyMaster GetPropertyMaster(PropertyType propertyType);


    }
}
