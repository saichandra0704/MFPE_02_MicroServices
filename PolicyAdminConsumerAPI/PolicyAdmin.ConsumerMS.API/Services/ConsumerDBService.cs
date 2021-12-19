using Microsoft.EntityFrameworkCore;
using PolicyAdmin.ConsumerMS.API.Data;
using PolicyAdmin.ConsumerMS.API.Interface;
using PolicyAdmin.ConsumerMS.API.Models;
using PolicyAdmin.ConsumerMS.API.Models.DAO;
using PolicyAdmin.ConsumerMS.API.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.ConsumerMS.API.Provider
{
    public class ConsumerDBService : IConsumerDBService
    {
        private readonly ConsumerContext _context;

        public ConsumerDBService(ConsumerContext context)
        {
            _context = context;
        }
        public bool CreateConsumerBusiness(Consumer consumer)
        {
            _context.Consumers.Add(consumer);
            int val = _context.SaveChanges();
            if (val>0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateConsumerBusiness(Consumer consumer)
        {
            //Consumer consumer = _context.Consumers.FirstOrDefault(consumer => consumer.Id == new_consumer.Id);

            try
            {
                if (consumer.Business != null)
                {
                    Business business = consumer.Business;
                    business.Id = consumer.BusinessId;
                    if (!UpdateBusiness(business))
                        return false;
                }
                _context.Entry(consumer).State = EntityState.Modified;
                
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            
            return true;
            
        }

        public bool UpdateBusiness(Business business)
        {
            try
            {
                _context.Entry(business).State = EntityState.Modified;
               
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }


            return true;
        }


        public Consumer GetConsumerBusiness(int id)
        {
            Consumer consumer = _context.Consumers.Include(consumer=>consumer.Business).FirstOrDefault(consumer => consumer.Id == id);
            return consumer;
        }

        public bool CreateBusinessProperty(Property property)
        {
            _context.Properties.Add(property);
            int val = _context.SaveChanges();
            if (val > 0)
            {
                return true;
            }
            return false;
        }



        public bool UpdateBusinessProperty(Property property)
        {
            //Consumer consumer = _context.Consumers.FirstOrDefault(consumer => consumer.Id == new_consumer.Id);
            

            try
            {
                _context.Entry(property).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }




        public Property GetBusinessProperty(int id)
        {
            Property property = _context.Properties.FirstOrDefault(property => property.Id == id);
            return property;
        }

        public BusinessMaster GetBusinessMaster(BusinessType busniessType)
        {
            return  _context.BusinessesMaster.FirstOrDefault(businessMaster => businessMaster.BusinessType == busniessType);
        
        }
        public PropertyMaster GetPropertyMaster(PropertyType propertyType)
        {
            return  _context.PropertiesMaster.FirstOrDefault(propertyMaster => propertyMaster.PropertyType == propertyType);
        
        }
    }
}
