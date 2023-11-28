using System.Data.Entity;
using System.Linq;
using System.Windows.Controls;
using FinalProject.Context;

namespace FinalProject.Views
{
    /// <summary>
    /// Логика взаимодействия для ProducerView.xaml
    /// </summary>
    public partial class ProducerView : UserControl
    {
        public ProducerView()
        {
            InitializeComponent();

            using (var dbcontext= new FinalProjectDbContext())
            {
                var producers = from producer in dbcontext.Producers select producer;
                
                var producerList = producers
                    .AsNoTracking()
                    .OrderBy(c => c.Id)
                    .Select(p =>new
                    {
                        p.Id ,
                        p.Name,
                        p.Address,
                        p.Telephone,
                        p.BankDetails
                    }).ToList();
                ProducerDataGrid.ItemsSource = producerList;

            }
        }
    }
}
