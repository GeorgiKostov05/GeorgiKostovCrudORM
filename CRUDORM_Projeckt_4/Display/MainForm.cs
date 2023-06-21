using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDORM_Projeckt_4.Logic;
using CRUDORM_Projeckt_4.Model;

namespace CRUDORM_Projeckt_4
{
    public partial class MainForm : Form
    {
        private DishLogic dishLogic;
        public MainForm()
        {
            InitializeComponent();
            dishLogic = new DishLogic();
        }
        private void LoadDishes()
        {
            var dishes = dishLogic.GetAllDishes();
            dishesListView.Items.Clear();

            foreach (var dish in dishes)
            {
                ListViewItem item = new ListViewItem(dish.DishId.ToString());
                item.SubItems.Add(dish.DishName);
                dishesListView.Items.Add(item);
            }
        }

        private void LoadDishTypes()
        {
            var dishTypes = dishLogic.GetAllDishTypes();
            dishTypeComboBox.Items.Clear();

            foreach (var dishType in dishTypes)
            {
                dishTypeComboBox.Items.Add(dishType);
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadDishes();
            LoadDishTypes();
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            DishType selectedDishType = (DishType)dishTypeComboBox.SelectedItem;

            Dish newDish = new Dish()
            {
                DishName = dishNameTextBox.Text,
                Description = descriptionTextBox.Text,
                Price = decimal.Parse(priceTextBox.Text),
                Weight = decimal.Parse(weightTextBox.Text),
                DishTypeId = selectedDishType.DishTypeId
            };
            dishLogic.AddDish(newDish);

            LoadDishes();
        }
        private void dishesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dishesListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = dishesListView.SelectedItems[0];
                int dishId = int.Parse(selectedItem.Text);
                Dish selectedDish = dishLogic.GetDishById(dishId);

                dishNameTextBox.Text = selectedDish.DishName;
                descriptionTextBox.Text = selectedDish.Description;
                priceTextBox.Text = selectedDish.Price.ToString();
                weightTextBox.Text = selectedDish.Weight.ToString();
                dishTypeComboBox.SelectedItem = dishLogic.GetDishTypeById(selectedDish.DishTypeId);
            }
        }
        private void editButton_Click(object sender, EventArgs e)
        {
            if (dishesListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = dishesListView.SelectedItems[0];
                int dishId = int.Parse(selectedItem.Text);
                Dish selectedDish = dishLogic.GetDishById(dishId);

                selectedDish.DishName = dishNameTextBox.Text;
                selectedDish.Description = descriptionTextBox.Text;
                selectedDish.Price = decimal.Parse(priceTextBox.Text);
                selectedDish.Weight = decimal.Parse(weightTextBox.Text);
                selectedDish.DishTypeId = ((DishType)dishTypeComboBox.SelectedItem).DishTypeId;

                dishLogic.UpdateDish(selectedDish);

                LoadDishes();
            }
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dishesListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = dishesListView.SelectedItems[0];
                int dishId = int.Parse(selectedItem.Text);

                dishLogic.DeleteDish(dishId);

                LoadDishes();
            }
        }
    }
}
