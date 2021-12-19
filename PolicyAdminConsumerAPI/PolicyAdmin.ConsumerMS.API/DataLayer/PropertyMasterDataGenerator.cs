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
    public class PropertyMasterDataGenerator
    {
        public PropertyMasterDataGenerator( ) { }
        public static void Initialize(ConsumerContext context)
        {
            List<PropertyMaster> propertyMaster = getPropertyMasterData();
            for (int i = 0; i < propertyMaster.Count; i++)
            {
                context.PropertiesMaster.Add(propertyMaster[i]);
            }
            context.SaveChanges();
                
            
        }
            private static List<PropertyMaster> getPropertyMasterData()
        {
            return new List<PropertyMaster>() {
                new PropertyMaster { 
                    Id=100001, 
                    PropertyType=PropertyType.Building, 
                    MinimumCostOfAsset=10000000, 
                    MaximumCostOfAsset=999999999, 
                    MinimumArea=1000, 
                    MaximumArea=99999999, 
                    PropertyAgeMin=2, 
                    PropertyAgeMax=100, 
                    EstimatedLife =50},

            };
        }
    }

}