using System;
using System.Data.Entity;
using System.Windows;
using FinalProject.Context;
using FinalProject.Models;

namespace FinalProject.Controls.EditWindow
{
    public partial class ProductReceiveEditWindow : Window
    {
        private readonly ProductReceive _selectedProductReceive;

        public bool IsSaved { get; private set; }

        public ProductReceiveEditWindow(ProductReceive productReceive)
        {
            InitializeComponent();

            _selectedProductReceive = productReceive;

            Quantity.Text = productReceive.Quantity.ToString();
            ProductId.Text = productReceive.ProductId.ToString();
            SupplierId.Text = productReceive.SupplierId.ToString();
            WarehouseId.Text = productReceive.WarehouseId.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedProductReceive.Quantity = Convert.ToInt32(Quantity.Text);
            _selectedProductReceive.ProductId = Convert.ToInt32(ProductId.Text);
            _selectedProductReceive.SupplierId = Convert.ToInt32(SupplierId.Text);
            _selectedProductReceive.WarehouseId = Convert.ToInt32(WarehouseId.Text);

            using (var context = new FinalProjectDbContext())
            {
                context.Entry(_selectedProductReceive).State = EntityState.Modified;
                context.SaveChanges();
            }

            IsSaved = true;

            Close();
        }
    }
}