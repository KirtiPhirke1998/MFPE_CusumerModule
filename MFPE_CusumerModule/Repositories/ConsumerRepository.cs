using MFPE_CusumerModule.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFPE_CusumerModule.Repositories
{
    public class ConsumerRepository : IConsumerRepository
    {
        private readonly DemoContext Context;

        public ConsumerRepository(DemoContext Context)
        {
            this.Context = Context;
        }

        public async Task<bool> CreateConsumerBussiness(Consumer consumer)
        {
            //var businessMaster=Context.BusinessMasters.FindAsync(consumer.BussinessId);
            //if (businessMaster != null)
            //{
            Context.Consumers.Add(consumer);
            int count = await Context.SaveChangesAsync();
            return count > 0;
            //}
            //else
            //{
            //    return false;
            //}

            //throw new NotImplementedException();
        }

        public async Task<bool> CreateBussinessProperty(Property property)
        {
            Context.Properties.Add(property);
            int count = await Context.SaveChangesAsync();
            return count >= 0;
            //throw new NotImplementedException();
        }

        public async Task<bool> UpdateConsumerBussiness(Consumer consumer)
        {
            var con=await Context.Consumers.FindAsync(consumer.id);
            con.Name = consumer.Name;
            con.Email = consumer.Email;
            con.AgentId = consumer.AgentId;
            con.ValidityOfConsumer = consumer.ValidityOfConsumer;

            con.BussinessId = consumer.BussinessId;

            var count = await Context.SaveChangesAsync();
            return count > 0;
            //throw new NotImplementedException();
        }

       

        public async Task<bool> UpdateBussinessProperty(Property property)
        {
            var pro = await Context.Properties.FindAsync(property.id);
            pro.BussinessId = property.BussinessId;
            pro.BuildingAge = property.BuildingAge;
            pro.BuildingType = property.BuildingType;
            pro.PropertMasterId = property.PropertMasterId;
            //pro.PropertyMaster.CostofAsset = property.PropertyMaster.CostofAsset;
            //pro.PropertyMaster.SalvageValue = property.PropertyMaster.SalvageValue;
            //pro.PropertyMaster.UsefulLifeOfAsset = property.PropertyMaster.UsefulLifeOfAsset;

            int count = await Context.SaveChangesAsync();
            return count >= 0;

            //throw new NotImplementedException();
        }



        public async Task<Consumer> ViewConsumerBussiness(int consumerId)
        {
            //var business = Context.Businesses.Include(p => p.BusinessMaster);
            //var consumer = Context.Consumers.Include(t => t.Business).ThenInclude(t => t.BusinessMaster);
            //var consumer1 = await Context.Consumers.Include(t => t.Business).ThenInclude(b => b.BusinessMaster).Where(t=>t.id==consumerId).ToListAsync();

             var consumer1 = await Context.Consumers.Include(t => t.Business).ThenInclude(b=>b.BusinessMaster).FirstOrDefaultAsync(t => t.id == consumerId);
            //var consumer = await Context.Consumers.FindAsync(consumerId);

            //var consumer = Context.Consumers.FirstOrDefault(t=>t.id==consumerId);
            //var business = await Context.Businesses.Include(p => p.BusinessMaster).FirstOrDefaultAsync(b=>b.id==consumer.BussinessId);
          
            // var bussinessMaster = await Context.BusinessMasters.FindAsync(bussinessMasterId);

            return consumer1;
            // throw new NotImplementedException();
        }

        public async Task<Property> ViewConsumerProperty(int consumerId,int propertyId)
        {
            var Cons = await Context.Consumers.FindAsync(consumerId);
            var pros = await Context.Businesses.FindAsync(Cons.BussinessId);
            if (pros.id == propertyId)
            {
                var property = await Context.Properties.Include(t=>t.PropertyMaster).Include(p=>p.Business).ThenInclude(b=>b.BusinessMaster).FirstOrDefaultAsync(t=>t.id==propertyId);
                return property;
            }
            else
            {
                return null;
            }



            //throw new NotImplementedException();
        }

        

        public async Task<bool> CreateBussinessMaster(BusinessMaster businessMaster)
        {
            Context.BusinessMasters.Add(businessMaster);
            int count = await Context.SaveChangesAsync();
            return count >= 0;
        }

        public async Task<BusinessMaster> ViewBussinessMasterById(int bussinessMasterId)
        {
            var businessMaster = await Context.BusinessMasters.FindAsync(bussinessMasterId);

            return businessMaster;
        }

        public async Task<List<Consumer>> ViewAllConsumerBussiness()
        {
            var consumer1 = await Context.Consumers.Include(consumer => consumer.Business).ThenInclude(business => business.BusinessMaster).ToListAsync();
            return consumer1;
        }

        public async Task<List<Property>> ViewAllBussinessProperties()
        {
            var property1 = await Context.Properties.Include(t=>t.PropertyMaster).Include(prop => prop.Business).ThenInclude(business => business.BusinessMaster).ToListAsync();
            return property1;
        }

        public async Task<Property> ViewBussinessProperty(int propertyId)
        {
            var prop1 = await Context.Properties.Include(c=>c.PropertyMaster).Include(t => t.Business).ThenInclude(b => b.BusinessMaster).FirstOrDefaultAsync(t => t.id == propertyId);

            return prop1;
        }
    }
}
