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
    /// Логика взаимодействия для SupplierView.xaml
    /// </summary>
    public partial class SupplierView : UserControl
    {
        public List<Supplier> Suppliers { get; set; }

        public SupplierView()
        {
            InitializeComponent();
            
            
            using (FinalProjectDbContext dbContext = new FinalProjectDbContext())
            {
                Suppliers = dbContext.Suppliers.ToList();
            }

            SuppliersDataGrid.ItemsSource = Suppliers;

            SuppliersDataGrid.Columns.Add(new DataGridTextColumn { Header = "Номер поставщика", Binding = new Binding("Id") });
            SuppliersDataGrid.Columns.Add(new DataGridTextColumn { Header = "Название организации", Binding = new Binding("Name") });
            SuppliersDataGrid.Columns.Add(new DataGridTextColumn { Header = "Адрес", Binding = new Binding("Address") });
            SuppliersDataGrid.Columns.Add(new DataGridTextColumn { Header = "Телефон", Binding = new Binding("Telephone") });
            SuppliersDataGrid.Columns.Add(new DataGridTextColumn { Header = "Банковские реквизиты", Binding = new Binding("BankDetails") });

        }
    }
}
