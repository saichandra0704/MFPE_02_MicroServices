using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PolicyAdmin.ConsumerMS.API.Data;
using PolicyAdmin.ConsumerMS.API.Models;
using PolicyAdmin.ConsumerMS.API.Models.DAO;
using PolicyAdmin.ConsumerMS.API.Models.Enum;

namespace PolicyAdmin.ConsumerMS.API.DataLayer
{
    public class PropertyDataGenerator
    {
        public PropertyDataGenerator( ) { }
        public static void Initialize(ConsumerContext context)
        {
            List<Property> property = getPropertyData();
            for (int i = 0; i < property.Count; i++)
            {
                context.Properties.Add(property[i]);
            }
            context.SaveChanges();
                
            
        }
            private static List<Property> getPropertyData()
        {
            return new List<Property>() {
                new Property
                {
                    Id=100001,
                    BusinessId=100001,
                    PropertyType = PropertyType.Building,
                    BuildingSqFt = 1500,
                    Storeys = 10,
                    PropertyAge = 20,
                    CostOfAsset = 100000000,
                    SalvageValue = 80000000
                },

                 new Property
                {
                    Id=100002,
                    BusinessId=100002,
                    PropertyType = PropertyType.Building,
                    BuildingSqFt = 3500,
                    Storeys = 8,
                    PropertyAge = 22,
                    CostOfAsset = 135000000,
                    SalvageValue = 60000000
                }
            };
        }
    }

}

