using FinalProject.Context;
using FinalProject.Models;
using System.Data.Entity;
using System.Windows;


namespace FinalProject.Controls.EditWindow
{
    public partial class WarehouseEditWindow : Window
    {
        private readonly Warehouse _selectedWarehouse;
        public bool IsSaved { get; private set; }

        public WarehouseEditWindow(Warehouse warehouse)
        {
            InitializeComponent();

            _selectedWarehouse = warehouse;

            NameInput.Text = warehouse.Name;
            AddressInput.Text = warehouse.Address;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedWarehouse.Name = NameInput.Text;
            _selectedWarehouse.Address = AddressInput.Text;

            using (var context = new FinalProjectDbContext())
            {
                context.Entry(_selectedWarehouse).State = EntityState.Modified;
                context.SaveChanges();
            }

            IsSaved = true;

            Close();
        }
    }
}