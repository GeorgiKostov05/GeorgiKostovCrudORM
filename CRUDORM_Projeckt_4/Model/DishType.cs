using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDORM_Projeckt_4.Model
{
    public class DishType
    {
        public int DishTypeId { get; set; }

        public string DishTypeName { get; set; }
        public ICollection<Dish> Dishes { get; set; }
    }
}
