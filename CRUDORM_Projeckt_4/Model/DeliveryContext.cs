using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CRUDORM_Projeckt_4.Model
{
    public class DeliveryContext:DbContext
    {
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishType> DishTypes { get; set; }

        public DeliveryContext() : base("DeliveryContext")
        {
        }

    }
}
