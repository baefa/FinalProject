using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using FinalProject.Context;
using FinalProject.Controls.CreateWindow;
using FinalProject.Controls.EditWindow;
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

            using (var dbContext = new FinalProjectDbContext())
            {
                Products = dbContext.Products.ToList();
            }

            ProductDataGrid.ItemsSource = Products;

            ProductDataGrid.Columns.Add(new DataGridTextColumn
                { Header = "Номер товара", Binding = new Binding("Id") });
            ProductDataGrid.Columns.Add(new DataGridTextColumn
                { Header = "Наименование товара", Binding = new Binding("Name") });
            ProductDataGrid.Columns.Add(new DataGridTextColumn
                { Header = "Вид товара", Binding = new Binding("Category") });
            ProductDataGrid.Columns.Add(
                new DataGridTextColumn { Header = "Арктирук", Binding = new Binding("Article") });
            ProductDataGrid.Columns.Add(new DataGridTextColumn
                { Header = "Производитель", Binding = new Binding("ProducerId") });
            ProductDataGrid.Columns.Add(new DataGridTextColumn { Header = "Цена", Binding = new Binding("Cost") });
        }

        private void CreateButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var createWindow = new ProductCreateWindow(this);
            createWindow.Show();
        }

        private async void DeleteButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ProductDataGrid.SelectedItem is Product selectedProduct)
            {
                using (var context = new FinalProjectDbContext())
                {
                    context.Products.Attach(selectedProduct);
                    context.Products.Remove(selectedProduct);
                    await context.SaveChangesAsync();
                    Products = await context.Products.ToListAsync();
                    ProductDataGrid.ItemsSource = Products;
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления!");
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductDataGrid.SelectedItem is Product selectedProducer)
            {
                var editWindow = new ProductEditWindow(selectedProducer);
                editWindow.ShowDialog();

                if (!editWindow.IsSaved) return;

                using (var context = new FinalProjectDbContext())
                {
                    context.Entry(selectedProducer).State = EntityState.Modified;
                    context.SaveChanges();

                    Products = context.Products.ToList();
                    ProductDataGrid.ItemsSource = Products;
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для изменения!");
            }
        }
    }
}