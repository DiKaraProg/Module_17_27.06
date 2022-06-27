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
using System.Windows.Shapes;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace Module_17
{
    /// <summary>
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        SqlConnection sqlConnection;
        SqlDataAdapter Adapter;
        DataTable Table;
        DataRowView row;
        public void PreperingOrders()
        {
            //Data Source=DESKTOP-4P5JFR4\SQLEXPRESS;Initial Catalog=MySqlServer;Integrated Security=True;Pooling=False
            SqlConnectionStringBuilder strsql = new SqlConnectionStringBuilder()
            {
                DataSource = @"DESKTOP-4P5JFR4\SQLEXPRESS",
                InitialCatalog = @"MySqlServer",
                IntegratedSecurity = true,
                UserID = "Admin",
                Password = "qwerty"
            };
            sqlConnection = new SqlConnection(strsql.ConnectionString);
            Adapter = new SqlDataAdapter();
            Table = new DataTable();
            //Select
              var sql = @"SELECT
                        ClientOrder.id,
                        ClientOrder.IdOrder,
                        ClientOrder.ClientId,
                        ClientOrder.ProductId
                        FROM ClientOrder,Clients,Product
                        WHERE ClientOrder.ProductId= Product.Id and ClientOrder.ClientId= Clients.id";

            Adapter.SelectCommand = new SqlCommand(sql,sqlConnection);

            //Insert
            sql = @"INSERT INTO ClientOrder (IdOrder,  ClientId,  ProductId) 
                                 VALUES (@IdOrder,  @ClientId,  @ProductId); 
                     SET @id = @@IDENTITY;";

            Adapter.InsertCommand = new SqlCommand(sql, sqlConnection);

            Adapter.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").Direction = ParameterDirection.Output;
            Adapter.InsertCommand.Parameters.Add("@IdOrder", SqlDbType.Int, 4, "IdOrder");
            Adapter.InsertCommand.Parameters.Add("@ClientId", SqlDbType.Int, 4, "ClientId");
            Adapter.InsertCommand.Parameters.Add("@ProductId", SqlDbType.Int, 4, "idBoss");

            //Update
            sql = @"UPDATE ClientOrder SET 
                           IdOrder = @IdOrder,
                           ClientId = @ClientId, 
                           ProductId = @ProductId 
                    WHERE id = @id";

            Adapter.InsertCommand = new SqlCommand(sql, sqlConnection);

            Adapter.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").Direction = ParameterDirection.Output;
            Adapter.InsertCommand.Parameters.Add("@IdOrder", SqlDbType.Int, 4, "IdOrder");
            Adapter.InsertCommand.Parameters.Add("@ClientId", SqlDbType.Int, 4, "ClientId");
            Adapter.InsertCommand.Parameters.Add("@ProductId", SqlDbType.Int, 4, "idBoss");

            //Delete

            sql = @"DELETE FROM ClientOrder where id= @id";

            Adapter.DeleteCommand = new SqlCommand(sql, sqlConnection);
            Adapter.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");



            Adapter.Fill(Table);
            DataGrid.DataContext = Table.DefaultView;

        }
        public Orders()
        {
            InitializeComponent(); PreperingOrders();
        }

        private void AddButton1_Click(object sender, RoutedEventArgs e)
        {
            DataRow r = Table.NewRow();
            r["IdOrder"] = Order_id.Text;
            r["ClientId"] = Client_id.Text;
            r["ProductId"] = Product_id.Text;
            
            
            Table.Rows.Add(r);
            Adapter.Update(Table);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem == null) return;
            row = (DataRowView)DataGrid.SelectedItem;
            row.Row.Delete();
            Adapter.Update(Table);
        }
    }
}
