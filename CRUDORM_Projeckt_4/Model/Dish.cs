using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRUDORM_Projeckt_4.Model
{
    public class Dish
    {
        public int DishId { get; set; }

        public string DishName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Weight { get; set; }

        public int DishTypeId { get; set; }
        public DishType DishTypes { get; set; }
    }
}
