using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using FinalProject.Context;
using FinalProject.Controls;
using FinalProject.Controls.EditWindow;
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
            ProducerDataGrid.Columns.Add(new DataGridTextColumn { Header = "Банковские реквизиты", Binding = new Binding("BankDetails") });

        }
        private void CreateButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ProducerCreateWindow createWindow = new ProducerCreateWindow(this);
            createWindow.Show();
        }

        private async void DeleteButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Producer selectedProducer = ProducerDataGrid.SelectedItem as Producer;

            if (selectedProducer != null)
            {
                using (FinalProjectDbContext _context = new FinalProjectDbContext())
                {
                    _context.Producers.Attach(selectedProducer);
                    _context.Producers.Remove(selectedProducer);
                    await _context.SaveChangesAsync();


                    Producers = await _context.Producers.ToListAsync();
                    ProducerDataGrid.ItemsSource = Producers;
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления!");
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Producer selectedProducer = ProducerDataGrid.SelectedItem as Producer;

            if (selectedProducer != null)
            {
                ProducerEditWindow editWindow = new ProducerEditWindow(selectedProducer);
                editWindow.ShowDialog();

                if (editWindow.IsSaved)
                {
                    using (FinalProjectDbContext _context = new FinalProjectDbContext())
                    {
                        // Обновляем контекст данных
                        _context.Entry(selectedProducer).State = EntityState.Modified;
                        _context.SaveChanges();

                        // Обновляем список и DataGrid после изменения
                        Producers = _context.Producers.ToList();
                        ProducerDataGrid.ItemsSource = Producers;
                    }
                }
                else
                {
                    MessageBox.Show("Выберите строку для изменения!");
                }
            }
        }
    }
}
