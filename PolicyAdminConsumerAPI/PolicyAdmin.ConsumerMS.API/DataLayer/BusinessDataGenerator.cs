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
    public class BusinessDataGenerator
    {
        public BusinessDataGenerator( ) { }
        public static void Initialize(ConsumerContext context)
        {
            List<Business> business = getBusinessData();
            for (int i = 0; i < business.Count; i++)
            {
                context.Businesses.Add(business[i]);
            }
            context.SaveChanges();
                
            
        }
            private static List<Business> getBusinessData()
        {
            return new List<Business>() {
                new Business{ Id=100001, BusinessName="Profit Company",BusinessType=BusinessType.SoleProprietorship, AnnualTurnOver=1200000,CapitalInvested=2000000,TotalEmployees=50,BusinesIncorporation=new DateTime(2015,05,09,9,15,0)},
                new Business{ Id=100002, BusinessName="The Boring Company",BusinessType=BusinessType.NonProfit, AnnualTurnOver=2250000,CapitalInvested=3870000,TotalEmployees=160,BusinesIncorporation=new DateTime(2017,08,01,9,15,0)}

            };
        }
    }

}