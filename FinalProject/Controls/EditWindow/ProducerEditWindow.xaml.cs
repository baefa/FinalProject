using System.Data.Entity;
using System.Windows;
using FinalProject.Context;
using FinalProject.Models;

namespace FinalProject.Controls.EditWindow
{
    /// <summary>
    /// Логика взаимодействия для EditWindowProducer.xaml
    /// </summary>
    public partial class ProducerEditWindow : Window
    {
        private readonly Producer _selectedProducer;

        public bool IsSaved { get; private set; }

        public ProducerEditWindow(Producer producer)
        {
            InitializeComponent();

            _selectedProducer = producer;

            NameInput.Text = producer.Name;
            AddressInput.Text = producer.Address;
            TelephoneInput.Text = producer.Telephone;
            BankDetailsInput.Text = producer.BankDetails;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedProducer.Name = NameInput.Text;
            _selectedProducer.Address = AddressInput.Text;
            _selectedProducer.Telephone = TelephoneInput.Text;
            _selectedProducer.BankDetails = BankDetailsInput.Text;

            using (var context = new FinalProjectDbContext())
            {
                context.Entry(_selectedProducer).State = EntityState.Modified;
                context.SaveChanges();
            }

            IsSaved = true;

            Close();
        }
    }
}