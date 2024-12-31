using MehmanFoods.Core.Entities;
using MehmanFoods.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmanFoods.Service
{
    public class PaymentStatusService : IPaymentStatusService
    {
        public Task<PaymentStatus> GetPaymentStatusAsync(decimal paidAmount, decimal subTotalCost)
        {
            if (paidAmount == 0)
            {
                return Task.FromResult(new PaymentStatus { Status = "Pending" });
            }

            if (paidAmount > 0 && paidAmount < subTotalCost)
            {
                return Task.FromResult(new PaymentStatus { Status = "PartiallyPaid" });
            }

            if (paidAmount == subTotalCost)
            {
                return Task.FromResult(new PaymentStatus { Status = "Completed" });
            }

            if (paidAmount > subTotalCost)
            {
                return Task.FromResult(new PaymentStatus { Status = "Advance" });
            }

            return Task.FromResult(new PaymentStatus { Status = "UnknownPaymentStatus" });
        }
    }
}
