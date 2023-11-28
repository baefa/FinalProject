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
using FinalProject.Models;

namespace FinalProject.Views
{
    /// <summary>
    /// Логика взаимодействия для ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl
    {
        public List<Product> Products { get; set; }

        public ProductView()
        {
            InitializeComponent();
            
            using (FinalProjectDbContext dbContext = new FinalProjectDbContext())
            {
                Products = dbContext.Products.ToList();
            }

            ProductDataGrid.ItemsSource = Products;

            ProductDataGrid.Columns.Add(new DataGridTextColumn { Header = "Номер товара", Binding = new Binding("Id") });
            ProductDataGrid.Columns.Add(new DataGridTextColumn { Header = "Наименование товара", Binding = new Binding("Name") });
            ProductDataGrid.Columns.Add(new DataGridTextColumn { Header = "Вид товара", Binding = new Binding("Category") });
            ProductDataGrid.Columns.Add(new DataGridTextColumn { Header = "Арктирук", Binding = new Binding("Article") });
            ProductDataGrid.Columns.Add(new DataGridTextColumn { Header = "Производитель", Binding = new Binding("Producer") });
            ProductDataGrid.Columns.Add(new DataGridTextColumn { Header = "Цена", Binding = new Binding("Cost") });

        }
    }
}
