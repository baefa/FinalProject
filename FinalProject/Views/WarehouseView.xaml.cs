using System;
using System.Collections.Generic;
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

            WarehousesDataGrid.Columns.Add(new DataGridTextColumn { Header = "Номер склада", Binding = new Binding("Id") });
            WarehousesDataGrid.Columns.Add(new DataGridTextColumn { Header = "Название", Binding = new Binding("Name") });
            WarehousesDataGrid.Columns.Add(new DataGridTextColumn { Header = "Адрес", Binding = new Binding("Address") });
        }
    }
}
