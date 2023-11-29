using System;
using System.Linq;
using System.Windows;
using FinalProject.Context;
using FinalProject.Models;
using FinalProject.Views;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controls.CreateWindow
{
    public partial class WarehouseCreateWindow : Window
    {
        private readonly FinalProjectDbContext _context = new FinalProjectDbContext();
        private readonly WarehouseView _warehouseView;
        
        public WarehouseCreateWindow(WarehouseView warehouseView)
        {
            InitializeComponent();
            _warehouseView = warehouseView;
        }

        private async void CreateButtonL_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newWarehouse = new Warehouse
                {
                    Name = NameInput.Text,
                    Address = AddressInput.Text
                };
                _context.Warehouses.Add(newWarehouse);
                await _context.SaveChangesAsync();

                if (_warehouseView != null)
                {
                    _warehouseView.Warehouses =  _context.Warehouses.ToList();
                    _warehouseView.WarehousesDataGrid.ItemsSource = _warehouseView.Warehouses;
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