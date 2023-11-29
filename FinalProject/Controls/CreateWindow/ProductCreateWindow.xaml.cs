using System.Windows;
using FinalProject.Context;
using FinalProject.Views;
using FinalProject.Models;
using System.Data.Entity;
using System;

namespace FinalProject.Controls.CreateWindow
{
    public partial class ProductCreateWindow : Window
    {
        private readonly FinalProjectDbContext _context = new FinalProjectDbContext();
        
        private readonly ProductView _productView;

        public ProductCreateWindow(ProductView productReceiveViewView)
        {
            InitializeComponent();
            _productView = productReceiveViewView;
        }

        private async void CreateButtonL_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newProduct = new Product
                {
                    Name = NameInput.Text,
                    Article = Convert.ToInt32(ArticleInput.Text),
                    Category = CategoryInput.Text,
                    Cost = Convert.ToDouble(CostInput.Text),
                    ProducerId = Convert.ToInt32(ProducerIdInput.Text)
                };

                _context.Products.Add(newProduct);

                await _context.SaveChangesAsync();

                if (_productView != null)
                {
                    _productView.Products = await _context.Products.ToListAsync();
                    _productView.ProductDataGrid.ItemsSource = _productView.Products;
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}