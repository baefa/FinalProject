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
    /// Логика взаимодействия для ProductReceiveView.xaml
    /// </summary>
    public partial class ProductReceiveView : UserControl
    {
        public List<ProductReceive> ProductsReceive { get; set; }

        public ProductReceiveView()
        {
            InitializeComponent();

            using (var dbContext = new FinalProjectDbContext())
            {
                ProductsReceive = dbContext.ProductReceives
                    .ToList();
            }

            ProductReceivesDataGrid.ItemsSource = ProductsReceive;
            ProductReceivesDataGrid.Columns.Add(new DataGridTextColumn
                { Header = "Номер поступления", Binding = new Binding("Id") });
            ProductReceivesDataGrid.Columns.Add(new DataGridTextColumn
                { Header = "Поставщик", Binding = new Binding("Supplier") });
            ProductReceivesDataGrid.Columns.Add(new DataGridTextColumn
                { Header = "Склад", Binding = new Binding("WarehouseId") });
            ProductReceivesDataGrid.Columns.Add(new DataGridTextColumn
                { Header = "Товар", Binding = new Binding("ProductId") });
            ProductReceivesDataGrid.Columns.Add(new DataGridTextColumn
                { Header = "Кол-во товара", Binding = new Binding("Quantity") });
            ProductReceivesDataGrid.Columns.Add(new DataGridTextColumn
                { Header = "Дата поступления", Binding = new Binding("DateOfReceive") });
        }
        private void CreateButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var createWindow = new ProductReceiveCreateWindow(this);
            createWindow.Show();
        }

        private async void DeleteButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ProductReceivesDataGrid.SelectedItem is ProductReceive selectedProductReceive)
            {
                using (var context = new FinalProjectDbContext())
                {
                    context.ProductReceives.Attach(selectedProductReceive);
                    context.ProductReceives.Remove(selectedProductReceive);
                    await context.SaveChangesAsync();
                    ProductsReceive = await context.ProductReceives.ToListAsync();
                    ProductReceivesDataGrid.ItemsSource = ProductsReceive;
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления!");
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductReceivesDataGrid.SelectedItem is ProductReceive selectedProductReceive)
            {
                var editWindow = new ProductReceiveEditWindow(selectedProductReceive);
                editWindow.ShowDialog();

                if (!editWindow.IsSaved) return;

                using (var context = new FinalProjectDbContext())
                {
                    context.Entry(selectedProductReceive).State = EntityState.Modified;
                    context.SaveChanges();

                    ProductsReceive = context.ProductReceives.ToList();
                    ProductReceivesDataGrid.ItemsSource = ProductsReceive;
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для изменения!");
            }
        }
    }
}