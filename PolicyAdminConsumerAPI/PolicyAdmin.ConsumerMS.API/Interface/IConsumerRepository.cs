using PolicyAdmin.ConsumerMS.API.Models;
using PolicyAdmin.ConsumerMS.API.Models.DAO;
using PolicyAdmin.ConsumerMS.API.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.ConsumerMS.API.Interface
{
    public interface IConsumerRepository
    {
        Task<Status> CreateConsumerBusiness(Consumer consumer);
        Task<Status> UpdateConsumerBusiness(Consumer Consumer);

        Task<Status> CreateBusinessProperty(Property Property);
        Task<Status> UpdateBusinessProperty(Property Property);

        Task<Consumer> ViewConsumerBusiness(int consumerId);
        Task<Property> ViewBusinessProperty(int propertyId);

    }
}
