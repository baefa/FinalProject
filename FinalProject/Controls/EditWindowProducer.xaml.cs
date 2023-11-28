using FinalProject.Context;
using FinalProject.Models;
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
    /// Логика взаимодействия для EditWindowProducer.xaml
    /// </summary>
    public partial class EditWindowProducer : Window
    {
        private Producer selectedProducer;

        public bool IsSaved { get; private set; }
        public EditWindowProducer(Producer producer)
        {
            InitializeComponent();
            selectedProducer = producer;

            NameProducerInput.Text = producer.Name;
            AddressProducerInput.Text=producer.Address;
            TelephoneProducerInput.Text=producer.Telephone;
            BankDetailsProducerInput.Text=producer.BankDetails;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            selectedProducer.Name = NameProducerInput.Text;
            selectedProducer.Address = AddressProducerInput.Text;
            selectedProducer.Telephone = TelephoneProducerInput.Text;
            selectedProducer.BankDetails = BankDetailsProducerInput.Text;

            using (FinalProjectDbContext _context = new FinalProjectDbContext())
            {
                _context.Entry(selectedProducer).State = EntityState.Modified;
                _context.SaveChanges();
            }

            IsSaved = true;

            Close();
        }
    }
}
