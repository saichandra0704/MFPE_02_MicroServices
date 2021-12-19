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
    public class businessMasterDataGenerator
    {
        public businessMasterDataGenerator( ) { }
        public static void Initialize(ConsumerContext context)
        {
            List<BusinessMaster> businessMaster = getBusinessMasterData();
            for (int i = 0; i < businessMaster.Count; i++)
            {
                context.BusinessesMaster.Add(businessMaster[i]);
            }
            context.SaveChanges();
                
            
        }
            private static List<BusinessMaster> getBusinessMasterData()
        {
            return new List<BusinessMaster>() {
                new BusinessMaster { Id=100001, BusinessType=BusinessType.SoleProprietorship, MinimumAnnualTurnOver=1200000, MinimumCapitalInvested=2000000, MinimumBusinessAgeInYears=2, MinimumTotalEmployees=10},
                new BusinessMaster { Id=100002, BusinessType=BusinessType.Partnership, MinimumAnnualTurnOver=1200000, MinimumCapitalInvested=2000000, MinimumBusinessAgeInYears=2, MinimumTotalEmployees=10},
                new BusinessMaster { Id=100003, BusinessType=BusinessType.LimitedPartnership, MinimumAnnualTurnOver=1200000, MinimumCapitalInvested=2000000, MinimumBusinessAgeInYears=2, MinimumTotalEmployees=10},
                new BusinessMaster { Id=100004, BusinessType=BusinessType.LimitedLiabilityCompany, MinimumAnnualTurnOver=1200000, MinimumCapitalInvested=2000000, MinimumBusinessAgeInYears=2, MinimumTotalEmployees=10},
                new BusinessMaster { Id=100005, BusinessType=BusinessType.Corporation,  MinimumAnnualTurnOver=1200000, MinimumCapitalInvested=2000000, MinimumBusinessAgeInYears=2, MinimumTotalEmployees=10},
                new BusinessMaster { Id=100006, BusinessType=BusinessType.NonProfit, MinimumAnnualTurnOver=1200000, MinimumCapitalInvested=2000000, MinimumBusinessAgeInYears=2, MinimumTotalEmployees=10},
                new BusinessMaster { Id=100007, BusinessType=BusinessType.Cooperative, MinimumAnnualTurnOver=1200000, MinimumCapitalInvested=2000000, MinimumBusinessAgeInYears=2, MinimumTotalEmployees=10},

            };
        }
    }

}
