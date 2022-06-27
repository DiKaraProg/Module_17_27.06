using System;
using System.Collections.Generic;
using System.Data;
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

namespace Module_17
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct()
        {
            InitializeComponent();
        }
        public AddProduct(DataRow row) : this()
        {
            CloseButton1.Click += delegate { this.DialogResult = false; };
            AddButton1.Click += delegate
            {
                row["Email"] = Email.Text;
                row["ProductId"] = Product_Id_add.Text;
                row["ProductName"] = Product_Name_add.Text;
                this.DialogResult = true;
            };
        }
    }
}
