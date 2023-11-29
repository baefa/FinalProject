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
using FinalProject.Controls;
using FinalProject.Controls.CreateWindow;
using FinalProject.Controls.EditWindow;
using FinalProject.Models;

namespace FinalProject.Views
{
    /// <summary>
    /// Логика взаимодействия для SupplierView.xaml
    /// </summary>
    public partial class SupplierView : UserControl
    {
        public List<Supplier> Suppliers { get; set; }

        public SupplierView()
        {
            InitializeComponent();


            using (FinalProjectDbContext dbContext = new FinalProjectDbContext())
            {
                Suppliers = dbContext.Suppliers.ToList();
            }

            SuppliersDataGrid.ItemsSource = Suppliers;

            SuppliersDataGrid.Columns.Add(new DataGridTextColumn
                { Header = "Номер поставщика", Binding = new Binding("Id") });
            SuppliersDataGrid.Columns.Add(new DataGridTextColumn
                { Header = "Название организации", Binding = new Binding("Name") });
            SuppliersDataGrid.Columns.Add(new DataGridTextColumn
                { Header = "Адрес", Binding = new Binding("Address") });
            SuppliersDataGrid.Columns.Add(new DataGridTextColumn
                { Header = "Телефон", Binding = new Binding("Telephone") });
            SuppliersDataGrid.Columns.Add(new DataGridTextColumn
                { Header = "Банковские реквизиты", Binding = new Binding("BankDetails") });
        }
        
        private void CreateButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var createWindow = new SupplierCreateWindow(this);
            createWindow.Show();
        }

        private async void DeleteButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (SuppliersDataGrid.SelectedItem is Supplier selectedSupplier)
            {
                using (var context = new FinalProjectDbContext())
                {
                    context.Suppliers.Attach(selectedSupplier);
                    context.Suppliers.Remove(selectedSupplier);
                    await context.SaveChangesAsync();
                    Suppliers = await context.Suppliers.ToListAsync();
                    SuppliersDataGrid.ItemsSource = Suppliers;
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления!");
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (SuppliersDataGrid.SelectedItem is Supplier selectedSupplier)
            {
                var editWindow = new SupplierEditWindow(selectedSupplier);
                editWindow.ShowDialog();
                if (!editWindow.IsSaved) return;
                using (var context = new FinalProjectDbContext())
                {
                    // Обновляем контекст данных
                    context.Entry(selectedSupplier).State = EntityState.Modified;
                    context.SaveChanges();

                    // Обновляем список и DataGrid после изменения
                    Suppliers = context.Suppliers.ToList();
                    SuppliersDataGrid.ItemsSource = Suppliers;
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для изменения!");
            }
        }
    }
}