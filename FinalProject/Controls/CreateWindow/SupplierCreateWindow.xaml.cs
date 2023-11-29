using System;
using System.Data.Entity;
using System.Windows;
using FinalProject.Context;
using FinalProject.Models;
using FinalProject.Views;

namespace FinalProject.Controls.CreateWindow
{
    public partial class SupplierCreateWindow : Window
    {
        private readonly FinalProjectDbContext _context = new FinalProjectDbContext();
        private readonly SupplierView _supplierView;
        
        public SupplierCreateWindow(SupplierView supplierView)
        {
            InitializeComponent();
            _supplierView = supplierView;
        }

        private async void CreateButtonL_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newSupplier = new Supplier
                {
                    Name = NameInput.Text,
                    Address = AddressInput.Text,
                    Telephone = Telephone.Text,
                    BankDetails = BankDetails.Text
                };
                _context.Suppliers.Add(newSupplier);
                await _context.SaveChangesAsync();

                if (_supplierView != null)
                {
                    _supplierView.Suppliers = await _context.Suppliers.ToListAsync();
                    _supplierView.SuppliersDataGrid.ItemsSource = _supplierView.Suppliers;
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