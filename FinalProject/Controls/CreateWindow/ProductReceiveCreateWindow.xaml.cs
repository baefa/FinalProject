using System;
using System.Data.Entity;
using System.Windows;
using FinalProject.Context;
using FinalProject.Models;
using FinalProject.Views;

namespace FinalProject.Controls.CreateWindow
{
    public partial class ProductReceiveCreateWindow : Window
    {
        private readonly FinalProjectDbContext _context = new FinalProjectDbContext();
        private readonly ProductReceiveView _productReceiveView;
        
        public ProductReceiveCreateWindow(ProductReceiveView productReceiveViewView)
        {
            InitializeComponent();
            _productReceiveView = productReceiveViewView;
        }

        private async void CreateButtonL_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newProductReceive = new ProductReceive
                {
                
                };
                _context.ProductReceives.Add(newProductReceive);
                await _context.SaveChangesAsync();

                if (_productReceiveView != null)
                {
                    _productReceiveView.ProductsReceive = await _context.ProductReceives.ToListAsync();
                    _productReceiveView.ProductReceivesDataGrid.ItemsSource = _productReceiveView.ProductsReceive;
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}