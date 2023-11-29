using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FinalProject.Context;
using FinalProject.Controls.CreateWindow;
using FinalProject.Controls.EditWindow;
using FinalProject.Models;

namespace FinalProject.Views
{
    /// <summary>
    /// Логика взаимодействия для WarehouseView.xaml
    /// </summary>
    public partial class WarehouseView : UserControl
    {
        public List<Warehouse> Warehouses { get; set; }

        public WarehouseView()
        {
            InitializeComponent();

            using (FinalProjectDbContext dbContext = new FinalProjectDbContext())
            {
                Warehouses = dbContext.Warehouses.ToList();
            }

            WarehousesDataGrid.ItemsSource = Warehouses;

            WarehousesDataGrid.Columns.Add(new DataGridTextColumn
                { Header = "Номер склада", Binding = new Binding("Id") });
            WarehousesDataGrid.Columns.Add(
                new DataGridTextColumn { Header = "Название", Binding = new Binding("Name") });
            WarehousesDataGrid.Columns.Add(
                new DataGridTextColumn { Header = "Адрес", Binding = new Binding("Address") });
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            var createWindow = new WarehouseCreateWindow(this);
            createWindow.Show();
        }

        private async void DeleteButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (WarehousesDataGrid.SelectedItem is Warehouse selectedWarehouse)
            {
                using (var context = new FinalProjectDbContext())
                {
                    context.Warehouses.Attach(selectedWarehouse);
                    context.Warehouses.Remove(selectedWarehouse);
                    await context.SaveChangesAsync();
                    Warehouses = await context.Warehouses.ToListAsync();
                    WarehousesDataGrid.ItemsSource = Warehouses;
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления!");
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (WarehousesDataGrid.SelectedItem is Warehouse selectedWarehouses)
            {
                var editWindow = new WarehouseEditWindow(selectedWarehouses);
                editWindow.ShowDialog();
                if (!editWindow.IsSaved) return;
                using (var context = new FinalProjectDbContext())
                {
                    // Обновляем контекст данных
                    context.Entry(selectedWarehouses).State = EntityState.Modified;
                    context.SaveChanges();

                    // Обновляем список и DataGrid после изменения
                    Warehouses = context.Warehouses.ToList();
                    WarehousesDataGrid.ItemsSource = Warehouses;
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для изменения!");
            }
        }
    }
}