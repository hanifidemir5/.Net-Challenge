using KargoApp.Data;
using KargoApp.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Runtime.CompilerServices;

namespace KargoApp
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Orders.Any())
            {
                var orders = new List<Orders>()
                {
                    new Orders ()
                    {
                        OrderTime = new DateTime(05/29/2015),
                        OrderDesi = 5,
                        OrderId = 1,
                        OrderCarrierCost = new decimal(2.5),
                    },
                    new Orders ()
                    {
                        OrderTime = new DateTime(09/25/2019),
                        OrderDesi = 7,
                        OrderId = 2,
                        OrderCarrierCost = new decimal(3.5),
                    },
                    
                };
                var carriers = new List<Carriers>()
                {
                    new Carriers()
                    {
                        CarrierIsActive = true,
                        CarrierName =  "PTT Kargo",
                        CarrierPlusDesiCost = 5,
                        CarrierId = 1,
                    },
                    new Carriers()
                    {
                        CarrierIsActive = true,
                        CarrierName =  "MNG Kargo",
                        CarrierPlusDesiCost = 7,
                        CarrierId = 2,
                    },
                };
                var carrierConfigurations = new List<CarrierConfigurations>()
                {
                    new CarrierConfigurations
                    {
                        CarrierCost = 5,
                        CarrierMaxDesi = 2,
                        CarrierMinDesi = 10,
                        CarrierConfigurationId = 1,
                    },
                    new CarrierConfigurations
                    {
                        CarrierCost = 17,
                        CarrierMaxDesi = 3,
                        CarrierMinDesi = 7,
                        CarrierConfigurationId = 2,
                    }
                };
                dataContext.Orders.AddRange(orders);
                dataContext.SaveChanges();
            }
        }

    }
}
