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

namespace FinalProject.Views
{
    /// <summary>
    /// Логика взаимодействия для ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl
    {
        public ProductView()
        {
            InitializeComponent();
            
            using (var dbcontext= new FinalProjectDbContext())
            {
                /*var products = from product in dbcontext.Products select product;
                var productList = products
                    .AsNoTracking()
                    .OrderBy(c => c.Id)
                    .Select(p => new
                    {
                        p.Id,
                        p.Name,
                        p.Category,
                        p.Article,
                        p.Cost
                    }).ToList(); */
                var productList = dbcontext.Products.ToList();
                
                ProductDataGrid.ItemsSource = productList;

            }
        }
    }
}
