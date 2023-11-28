using FinalProject.Context;
using FinalProject.Models;
using FinalProject.Views;
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
using System.Windows.Shapes;

namespace FinalProject.Controls
{
    /// <summary>
    /// Логика взаимодействия для CreateWindowProducer.xaml
    /// </summary>
    public partial class CreateWindowProducer : Window
    {
        private FinalProjectDbContext _context = new FinalProjectDbContext();
        private ProducerView _producerView;
        public CreateWindowProducer(ProducerView producerView)
        {
            InitializeComponent();
            _producerView = producerView;
        }

        private async void CreateButtonL_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Producer newProducer = new Producer()
                {
                    Name = NameProducerInput.Text,
                    Address = AddressProducerInput.Text,
                    Telephone = TelephoneProducerInput.Text,
                    BankDetails = BankDetailsProducerInput.Text,
                };

                _context.Producers.Add(newProducer);
                await _context.SaveChangesAsync();

                // Обновление UI в ProducerView
                if (_producerView != null)
                {
                    _producerView.Producers = await _context.Producers.ToListAsync();
                    _producerView.ProducerDataGrid.ItemsSource = _producerView.Producers;
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
