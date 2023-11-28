﻿using System;
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
using FinalProject.Models;

namespace FinalProject.Views
{
    /// <summary>
    /// Логика взаимодействия для ProductReceiveView.xaml
    /// </summary>
    public partial class ProductReceiveView : UserControl
    {
        public List<ProductReceive> ProductsReceive { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public ProductReceiveView()
        {
            InitializeComponent();
            
            using (FinalProjectDbContext _context = new FinalProjectDbContext())
            {
                ProductsReceive = _context.ProductReceives.ToList();
            }

            ProductReceivesDataGrid.ItemsSource = ProductsReceive;
            ProductReceivesDataGrid.Columns.Add(new DataGridTextColumn { Header = "Номер поступления", Binding = new Binding("Id") });
            ProductReceivesDataGrid.Columns.Add(new DataGridTextColumn { Header = "Поставщик", Binding = new Binding("SupplierId") });
            ProductReceivesDataGrid.Columns.Add(new DataGridTextColumn { Header = "Склад", Binding = new Binding("WarehouseId") });
            ProductReceivesDataGrid.Columns.Add(new DataGridTextColumn { Header = "Товар", Binding = new Binding("ProductId") });
            ProductReceivesDataGrid.Columns.Add(new DataGridTextColumn { Header = "Кол-во товара", Binding = new Binding("Quantity") });
            ProductReceivesDataGrid.Columns.Add(new DataGridTextColumn { Header = "Дата поступления", Binding = new Binding("DateOfReceive") });
        }
    }
}
