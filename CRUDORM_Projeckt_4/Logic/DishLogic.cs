using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDORM_Projeckt_4.Model;

namespace CRUDORM_Projeckt_4.Logic
{
    internal class DishLogic
    {
        private DeliveryContext context;

        public DishLogic()
        {
            context = new DeliveryContext();
        }

        public List<Dish> GetAllDishes()
        {
            return context.Dishes.ToList();
        }

        public void AddDish(Dish dish)
        {
            context.Dishes.Add(dish);
            context.SaveChanges();
        }

        public void UpdateDish(Dish dish)
        {
            Dish existingDish = context.Dishes.Find(dish.DishId);

            if (existingDish != null)
            {
                existingDish.DishName = dish.DishName;
                existingDish.Description = dish.Description;
                existingDish.Price = dish.Price;
                existingDish.Weight = dish.Weight;
                existingDish.DishTypeId = dish.DishTypeId;

                context.SaveChanges();
            }
        }

        public void DeleteDish(int dishId)
        {
            Dish dish = context.Dishes.Find(dishId);

            if (dish != null)
            {
                context.Dishes.Remove(dish);
                context.SaveChanges();
            }
        }

        public List<DishType> GetAllDishTypes()
        {
            return context.DishTypes.ToList();
        }
        public Dish GetDishById(int dishId)
        {
            return context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        }

        public DishType GetDishTypeById(int dishTypeId)
        {
            return context.DishTypes.FirstOrDefault(dt => dt.DishTypeId == dishTypeId);
        }
    }
}
