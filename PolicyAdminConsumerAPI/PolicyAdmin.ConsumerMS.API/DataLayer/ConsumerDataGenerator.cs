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
    public class ConsumerDataGenerator
    {
        public ConsumerDataGenerator( ) { }
        public static void Initialize(ConsumerContext context)
        {
            List<Consumer> consumer = getConsuemrData();
            for (int i = 0; i < consumer.Count; i++)
            {
                context.Consumers.Add(consumer[i]);
            }
            context.SaveChanges();
                
            
        }
            private static List<Consumer> getConsuemrData()
        {
            return new List<Consumer>() {
                new Consumer{Id=100001, ConsumerName="Himanshu", ConsumerDOB = new DateTime(1999,10,10),ConsumerEmail="himanshu@gmail.com",ConsumerPan="ABCDE1234F", AgentId="SaiChandra", BusinessId=100001},
                 new Consumer{Id=100002, ConsumerName="Anfal", ConsumerDOB = new DateTime(1990,04,08),ConsumerEmail="anfal@gmail.com",ConsumerPan="UVWXY6789Z", AgentId="AslamDegala", BusinessId=100002}

            };
        }
    }

}