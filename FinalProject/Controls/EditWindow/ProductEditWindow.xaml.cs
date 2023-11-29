using System;
using System.Data.Entity;
using System.Globalization;
using System.Windows;
using FinalProject.Context;
using FinalProject.Models;

namespace FinalProject.Controls.EditWindow
{
    public partial class ProductEditWindow : Window
    {
        private readonly Product _selectedProduct;

        public bool IsSaved { get; private set; }

        public ProductEditWindow(Product product)
        {
            InitializeComponent();

            _selectedProduct = product;

            NameInput.Text = product.Name;
            ArticleInput.Text = product.Article.ToString();
            CategoryInput.Text = product.Category;
            CostInput.Text = product.Cost.ToString(CultureInfo.InvariantCulture);
            ProducerIdInput.Text = product.ProducerId.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedProduct.Name = NameInput.Text;
            _selectedProduct.Article = Convert.ToInt32(ArticleInput.Text);
            _selectedProduct.Category = CategoryInput.Text;
            _selectedProduct.Cost = Convert.ToDouble(CostInput.Text);

            using (var context = new FinalProjectDbContext())
            {
                context.Entry(_selectedProduct).State = EntityState.Modified;
                context.SaveChanges();
            }

            IsSaved = true;

            Close();
        }
    }
}