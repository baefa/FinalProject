using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using FinalProject.Context;
using FinalProject.Models;
using FinalProject.Services;

namespace FinalProject.Views
{
    /// <summary>
    /// Логика взаимодействия для ProducerView.xaml
    /// </summary>
    public partial class ProducerView : UserControl
    {
        public List<Producer> Producers { get; set; }
        public ProducerView()
        {
            InitializeComponent();

            using (FinalProjectDbContext _context = new FinalProjectDbContext())
            {
                Producers = _context.Producers.ToList();
            }

            ProducerDataGrid.ItemsSource = Producers;

            ProducerDataGrid.Columns.Add(new DataGridTextColumn { Header = "Номер производителя", Binding = new Binding("Id") });
            ProducerDataGrid.Columns.Add(new DataGridTextColumn { Header = "Название организации", Binding = new Binding("Name") });
            ProducerDataGrid.Columns.Add(new DataGridTextColumn { Header = "Адрес", Binding = new Binding("Address") });
            ProducerDataGrid.Columns.Add(new DataGridTextColumn { Header = "Телефон", Binding = new Binding("Telephone") });
            ProducerDataGrid.Columns.Add(new DataGridTextColumn { Header = "Банковские реквизиты", Binding = new Binding("Name") });

        }
    }
}
