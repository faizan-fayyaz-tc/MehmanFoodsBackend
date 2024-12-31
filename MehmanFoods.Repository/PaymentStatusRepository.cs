using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Repository
{
    public class PaymentStatusRepository : IPaymentStatusRepository
    {
        public Task<PaymentStatus> GetPaymentStatusAsync()
        {
            throw new NotImplementedException();
        }
    }
}
