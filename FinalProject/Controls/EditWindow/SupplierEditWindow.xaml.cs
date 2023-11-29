using System.Data.Entity;
using System.Windows;
using FinalProject.Context;
using FinalProject.Models;

namespace FinalProject.Controls.EditWindow
{
    public partial class SupplierEditWindow : Window
    {
        private readonly Supplier _selectedSupplier;

        public bool IsSaved { get; private set; }

        public SupplierEditWindow(Supplier supplier)
        {
            InitializeComponent();
            _selectedSupplier = supplier;
            NameInput.Text = supplier.Name;
            AddressInput.Text = supplier.Address;
            TelephoneInput.Text = supplier.Telephone;
            BankDetailsInput.Text = supplier.BankDetails;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedSupplier.Name = NameInput.Text;
            _selectedSupplier.Address = AddressInput.Text;
            _selectedSupplier.Telephone = TelephoneInput.Text;
            _selectedSupplier.BankDetails = BankDetailsInput.Text;

            using (var context = new FinalProjectDbContext())
            {
                context.Entry(_selectedSupplier).State = EntityState.Modified;
                context.SaveChanges();
            }

            IsSaved = true;

            Close();
        }
    }
}