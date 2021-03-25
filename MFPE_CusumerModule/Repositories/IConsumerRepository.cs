using MFPE_CusumerModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFPE_CusumerModule.Repositories
{
    public interface IConsumerRepository
    {
        Task<bool> CreateConsumerBussiness(Consumer consumer);

        Task<bool> UpdateConsumerBussiness(Consumer consumer);

        Task<bool> CreateBussinessProperty(Property property);

        Task<bool> UpdateBussinessProperty(Property property);

        Task<Consumer> ViewConsumerBussiness(int consumerId);

        Task<Property> ViewBussinessProperty(int propertyId);

        Task<List<Consumer>> ViewAllConsumerBussiness();

        Task<List<Property>> ViewAllBussinessProperties();

        Task<Property> ViewConsumerProperty(int consumerId,int propertyId);


        Task<bool> CreateBussinessMaster(BusinessMaster businessMaster);

        Task<BusinessMaster> ViewBussinessMasterById(int bussinessMasterId);

    }
}
