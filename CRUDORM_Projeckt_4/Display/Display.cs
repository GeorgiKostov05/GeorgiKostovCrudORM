using CRUDORM_Projeckt_4.Logic;
using CRUDORM_Projeckt_4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDORM_Projeckt_4.Display
{
    public class Display
    {
        private DishLogic dishLogic;

        public Display()
        {
            dishLogic = new DishLogic();
        }

        public void ShowDishesList()
        {
            List<Dish> dishes = dishLogic.GetAllDishes();

            Console.WriteLine("Списък на продуктите:");

            foreach (Dish dish in dishes)
            {
                Console.WriteLine($"{dish.DishId} - {dish.DishName}");
            }
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Изберете опция:");
                Console.WriteLine("1. Визуализирай списък с продукти");
                Console.WriteLine("2. Изход");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ShowDishesList();
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("Невалидна опция. Моля, опитайте отново.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
