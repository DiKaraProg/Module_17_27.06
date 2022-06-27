using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.OleDb;
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
using System.Data;
using System.Data.Common;

namespace Module_17
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SqlConnectionStringBuilder strSqlCon;
        public SqlConnection sqlConnection;
        public OleDbConnection oleDbConnection;

        public DataTable table;
        public DataTable tableOrders;

        public SqlDataAdapter adapter;
        public OleDbDataAdapter adapterOrders;

        public DataRowView row;
        public DataRowView rowOrders;


        public void PreperingSql_Orders()
        {
            //Provider=Microsoft.ACE.OLEDB.12.0;Data Source="C:\Users\Димас\Downloads\Обучение програмированию\Домашняя_Работа_Основные_Проекты\Module_17\bin\Debug\Database41.accdb"
            OleDbConnectionStringBuilder oleDbConnectionStringBuilder = new OleDbConnectionStringBuilder()
            {
                DataSource = @"Database41.accdb",
                Provider = @"Microsoft.ACE.OLEDB.12.0"
            };
            
            oleDbConnection = new OleDbConnection() { ConnectionString = oleDbConnectionStringBuilder.ConnectionString };
            tableOrders = new DataTable();
            adapterOrders = new OleDbDataAdapter();
            //select
            var OleDB = $"select * From Orders Order by Orders.Id";
            
            adapterOrders.SelectCommand = new OleDbCommand(OleDB, oleDbConnection);
            //INSERT
            OleDB = @"INSERT INTO Orders (Email, ProductId, ProductName)
                    VALUES (@Email, @ProductId, @ProductName);
                    SET Id = @@IDENTITY;";

            adapterOrders.InsertCommand = new OleDbCommand(OleDB, oleDbConnection);
            adapterOrders.InsertCommand.Parameters.Clear();
            adapterOrders.InsertCommand.Parameters.Add("@Id", OleDbType.Integer, 5, "Id");
            adapterOrders.InsertCommand.Parameters.Add("@Email", OleDbType.VarChar,25, "Email");
            adapterOrders.InsertCommand.Parameters.Add("@ProductId", OleDbType.Integer, 25, "ProductId");
            adapterOrders.InsertCommand.Parameters.Add("@ProductName", OleDbType.VarChar, 25, "ProductName");


            //Update

            OleDB = @"Update Orders Set
                Email = @Email,
                ProductId = @ProductId,
                ProductName = @ProductName
                where Id = @Id";
            adapterOrders.UpdateCommand = new OleDbCommand(OleDB, oleDbConnection);

            adapterOrders.UpdateCommand.Parameters.Clear();
            adapterOrders.UpdateCommand.Parameters.Add("@Id", OleDbType.Integer, 5, "Id");
            adapterOrders.UpdateCommand.Parameters.Add("@Email", OleDbType.VarChar, 25, "Email");
            adapterOrders.UpdateCommand.Parameters.Add("@ProductId", OleDbType.Integer, 25, "ProductId");
            adapterOrders.UpdateCommand.Parameters.Add("@ProductName", OleDbType.VarChar, 25, "ProductName");

            //Delete

            OleDB = @"Delete from Orders Where Id = @Id";
            adapterOrders.DeleteCommand = new OleDbCommand(OleDB, oleDbConnection);
            adapterOrders.DeleteCommand.Parameters.Clear();
            adapterOrders.DeleteCommand.Parameters.Add("@Id", OleDbType.Integer, 5, "Id");



            adapterOrders.Fill(tableOrders);
            DataGrid_Product.ItemsSource = tableOrders.DefaultView;

        }
        public void PreperingSql_Clients()
        {
            strSqlCon = new SqlConnectionStringBuilder()
            {
                DataSource = @"DESKTOP-4P5JFR4\SQLEXPRESS",
                InitialCatalog = @"MySqlServer",
                IntegratedSecurity = true,
                UserID = "Admin",
                Password = "qwerty"
            };
            sqlConnection = new SqlConnection() { ConnectionString = strSqlCon.ConnectionString };
            table = new DataTable();
            adapter =  new SqlDataAdapter();
            //select
            var sql = @"SELECT * FROM Clients Order by Clients.id";
            adapter.SelectCommand = new SqlCommand(sql, sqlConnection);

            
           
            //INSERT
            sql = @"INSERT INTO Clients (MiddleName, FirstName, FatherName, PhoneNumber, Email)
                            VALUES(@MiddleName, @FirstName, @FatherName, @PhoneNumber, @Email)
                            SET @id= @@IDENTITY";
            adapter.InsertCommand = new SqlCommand(sql,sqlConnection);
            adapter.InsertCommand.Parameters.Clear();
            adapter.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 5, "id").Direction = ParameterDirection.Output;
            adapter.InsertCommand.Parameters.Add("@MiddleName", SqlDbType.NVarChar, 20, "MiddleName");
            adapter.InsertCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 20, "FirstName");
            adapter.InsertCommand.Parameters.Add("@FatherName", SqlDbType.NVarChar, 20, "FatherName");
            adapter.InsertCommand.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar, 20, "PhoneNumber");
            adapter.InsertCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 20, "Email");

            sql = @"UPDATE Clients SET
                        MiddleName= @MiddleName,
                        FirstName= @FirstName,
                        FatherName = @FatherName,
                        PhoneNumber= @PhoneNumber,
                        Email= @Email
                    WHERE id = @id";

            adapter.UpdateCommand = new SqlCommand(sql, sqlConnection);
            adapter.UpdateCommand.Parameters.Clear();
            adapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 5, "id").SourceVersion= DataRowVersion.Original;
            adapter.UpdateCommand.Parameters.Add("@MiddleName", SqlDbType.NVarChar, 20, "MiddleName");
            adapter.UpdateCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 20, "FirstName");
            adapter.UpdateCommand.Parameters.Add("@FatherName", SqlDbType.NVarChar, 20, "FatherName");
            adapter.UpdateCommand.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar, 20, "PhoneNumber");
            adapter.UpdateCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 20, "Email");


            sql = @"Delete from Clients where id = @id";
            adapter.DeleteCommand = new SqlCommand(sql, sqlConnection);
            adapter.DeleteCommand.Parameters.Clear();
            adapter.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 5, "id");



            adapter.Fill(table);
            DataGrid.DataContext = table.DefaultView;
        }
       
        public MainWindow()
        {
            

            InitializeComponent(); PreperingSql_Clients(); PreperingSql_Orders();



        }

        private void MenuItem_Click_Add(object sender, RoutedEventArgs e)
        {
            DataRow r = table.NewRow();
            AddClients addClients = new AddClients(r);
            addClients.ShowDialog();
            if (addClients.DialogResult.Value)
            {
                table.Rows.Add(r);
                adapter.Update(table);
            }
        }

        private void MenuItem_Click_Delete(object sender, RoutedEventArgs e)
        {
            row = (DataRowView)DataGrid.SelectedItem;
            row.Row.Delete();
            adapter.Update(table);

        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            row = (DataRowView)DataGrid.SelectedItem;
            row.Row.BeginEdit();
            adapter.Update(table);
        }

        private void DataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            if (row == null) return;
            row.Row.EndEdit();
            adapter.Update(table);
        }

       
      

        private void MenuItem_Click_Delete_Orders(object sender, RoutedEventArgs e)
        {
            rowOrders = (DataRowView)DataGrid_Product.SelectedItem;
            rowOrders.Row.Delete();
            adapterOrders.Update(tableOrders);
        }

        private void MenuItem_Click_Add_Orders(object sender, RoutedEventArgs e)
        
        {
           
            DataRow rowOrders = tableOrders.NewRow();
            AddProduct addProduct = new AddProduct(rowOrders);
            addProduct.ShowDialog();

            if (addProduct.DialogResult.Value)
            {
                tableOrders.Rows.Add(rowOrders);
                adapterOrders.Update(tableOrders);
            }

        }

        private void OrdersWindow_Click(object sender, RoutedEventArgs e)
        {
            Orders orders = new Orders();
            orders.Show();

        }
    }
}
