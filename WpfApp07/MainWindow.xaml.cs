using System;
using System.Collections.Generic;
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
using Business;
using Entity;

namespace WpfApp07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    { 

            BProduct productManager;

            public MainWindow()
            {
                InitializeComponent();
                productManager = new BProduct();
            }

            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Product product = new Product
                {
                    productId = Convert.ToInt32(txtproductId.Text),
                    name = txtname.Text,
                    price = Convert.ToDecimal(txtprice.Text),
                    stock = Convert.ToInt32(txtstock.Text),
                    active = true
                };

                productManager.InsertarProduct(product);


            }


        private void ListarProduct_Click(object sender, RoutedEventArgs e)
        {
            ListarProduct listarCustomer = new ListarProduct();
            //customerManager.ListarCustomer();
        }

        
    }
}
