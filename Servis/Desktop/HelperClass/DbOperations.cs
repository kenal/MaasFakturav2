using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Desktop.HelperClass
{
    internal static class DbOperations
    {

        #region General
        /// <summary>
        /// Used to define which table is used
        /// </summary>
        internal enum TableType
        {
            Traditional,
            FileStream
        }
        /// <summary>
        /// Opens and returns a connection to a database
        /// </summary>
        /// <returns>An open connection</returns>
        /// 

        private static System.Data.SqlClient.SqlConnection OpenConnection()
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection();

            connection.ConnectionString = "Data Source=MAAG\\SQLEXPRESS;Initial Catalog=SqlFileStreamMaas;Persist Security Info=True;User ID=test;Password=1234567";
            //+ SqlFileStream.Properties.Settings.Default["DataSource"].ToString()
            //+ SqlFileStream.Properties.Settings.Default["DatabaseName"].ToString();



            connection.Open();

            return connection;
        }
        /// <summary>
        /// Removes all rows from the tables
        /// </summary>
        /// <returns>Removed amount of rows</returns>
        internal static int DeleteContents(Guid id)
        {
            System.Data.SqlClient.SqlConnection connection = OpenConnection();
            System.Data.SqlClient.SqlCommand command = connection.CreateCommand();
            int rowsDeleted;

            command.CommandType = System.Data.CommandType.Text;



            command.CommandText = "DELETE FROM FileStreamTest WHERE Id = @GUID";
            command.Parameters.AddWithValue("@GUID", id);
            rowsDeleted = command.ExecuteNonQuery();

            command.CommandText = "CHECKPOINT";
            command.ExecuteNonQuery();

            connection.Close();

            return rowsDeleted;
        }
        /// <summary>
        /// Lists the data from a table
        /// </summary>
        /// <param name="tableType">Defines which table to list</param>
        /// <returns>A data table containing id's and names from the table in the database</returns>
        internal static System.Data.DataTable ListData(TableType tableType)
        {
            System.Data.SqlClient.SqlConnection connection = OpenConnection();
            System.Data.SqlClient.SqlCommand command = connection.CreateCommand();
            System.Data.DataSet data = new System.Data.DataSet();
            System.Data.SqlClient.SqlDataAdapter dataAdapter = new System.Data.SqlClient.SqlDataAdapter();

            command.CommandType = System.Data.CommandType.Text;

            command.CommandText = "SELECT [Name], [Id] FROM " + (tableType == TableType.Traditional ? "VarbinaryTest" : "FileStreamTest WHERE [Name] LIKE '%un%'");
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(data);

            connection.Close();

            return data.Tables[0];
        }

        internal static System.Data.DataTable ListDataUgovor(TableType tableType)
        {
            System.Data.SqlClient.SqlConnection connection = OpenConnection();
            System.Data.SqlClient.SqlCommand command = connection.CreateCommand();
            System.Data.DataSet data = new System.Data.DataSet();
            System.Data.SqlClient.SqlDataAdapter dataAdapter = new System.Data.SqlClient.SqlDataAdapter();

            command.CommandType = System.Data.CommandType.Text;

            command.CommandText = "SELECT [Name], [Id] FROM " + (tableType == TableType.Traditional ? "VarbinaryTest" : "FileStreamTest WHERE [Name] LIKE '%gov%'");
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(data);

            connection.Close();

            return data.Tables[0];
        }

        internal static System.Data.DataTable ListDataPonuda(TableType tableType)
        {
            System.Data.SqlClient.SqlConnection connection = OpenConnection();
            System.Data.SqlClient.SqlCommand command = connection.CreateCommand();
            System.Data.DataSet data = new System.Data.DataSet();
            System.Data.SqlClient.SqlDataAdapter dataAdapter = new System.Data.SqlClient.SqlDataAdapter();

            command.CommandType = System.Data.CommandType.Text;

            command.CommandText = "SELECT [Name], [Id] FROM " + (tableType == TableType.Traditional ? "VarbinaryTest" : "FileStreamTest WHERE [Name] LIKE '%onuda%'");
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(data);

            connection.Close();

            return data.Tables[0];
        }
        #endregion General

        #region Uploading
        /// <summary>
        /// Saves the file to the database using SqlParameter. The column type is either varbinary or filestream
        /// </summary>
        /// <param name="file">File to save</param>
        /// <param name="repeatCount">How many times to save</param>
        /// <param name="tableType">Target table type</param>
        /// <returns>Elapsed time</returns>
        internal static void StoreFileUsingSqlParameter(ImageSource slika, byte[] slika1, TableType tableType, int idKorisnik)
        {
            System.Data.SqlClient.SqlConnection connection = OpenConnection();
            System.Data.SqlClient.SqlCommand command = connection.CreateCommand();
            System.Data.SqlClient.SqlParameter parameter;
            int rowsInserted;
            

            if(IdKorisnika(idKorisnik) == true)
            {
                command.CommandText = "UPDATE Slika SET Name = @Name, Data = @Data WHERE IdKorisnik = @IdKorisnik";
                command.CommandType = System.Data.CommandType.Text;

                parameter = new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.NVarChar, 100);
                parameter.Value = slika.ToString();
                command.Parameters.Add(parameter);

                parameter = new System.Data.SqlClient.SqlParameter("@Data", System.Data.SqlDbType.VarBinary);
                parameter.Value = slika1;
                command.Parameters.Add(parameter);

                parameter = new System.Data.SqlClient.SqlParameter("@IdKorisnik", System.Data.SqlDbType.Int);
                parameter.Value = idKorisnik;
                command.Parameters.Add(parameter);

                command.Transaction = connection.BeginTransaction();

                //for (int counter = 0; counter < repeatCount; counter++) {
                rowsInserted = command.ExecuteNonQuery();
                //}

                command.Transaction.Commit();

                connection.Close();
            }
            else
            {
                command.CommandText = "INSERT INTO  Slika  ([Name], [Data],[IdKorisnik]) VALUES (@Name, @Data, @IdKorisnik)";
                command.CommandType = System.Data.CommandType.Text;

                parameter = new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.NVarChar, 100);
                parameter.Value = slika.ToString();
                command.Parameters.Add(parameter);

                parameter = new System.Data.SqlClient.SqlParameter("@Data", System.Data.SqlDbType.VarBinary);
                parameter.Value = slika1;
                command.Parameters.Add(parameter);

                parameter = new System.Data.SqlClient.SqlParameter("@IdKorisnik", System.Data.SqlDbType.Int);
                parameter.Value = idKorisnik;
                command.Parameters.Add(parameter);

                command.Transaction = connection.BeginTransaction();

                //for (int counter = 0; counter < repeatCount; counter++) {
                rowsInserted = command.ExecuteNonQuery();
                //}

                command.Transaction.Commit();

                connection.Close();

            }

            

            
        }
        /// <summary>
        /// Stores the file to the database using SqlFileStream
        /// </summary>
        /// <param name="file">File to save</param>
        /// <param name="repeatCount">How many times to save</param>
        /// <returns>Elapsed time</returns>
        internal static System.TimeSpan StoreFileUsingSqlFileStream(string file)
        {
            System.Data.SqlClient.SqlConnection connection = OpenConnection();
            System.Data.SqlClient.SqlCommand insertCommand = connection.CreateCommand();
            System.Data.SqlClient.SqlCommand helperCommand = connection.CreateCommand();
            object transactionContext;
            System.Data.SqlClient.SqlParameter parameter;
            System.Data.SqlTypes.SqlFileStream sqlFileStream;
            byte[] fileData;
            string filePathInServer;
            int rowsInserted;
            System.DateTime startTime;
            System.DateTime endTime;

            insertCommand.CommandText = "INSERT INTO FileStreamTest ([Id], [Name], [Data]) VALUES (@Id, @Name, (0x))";
            insertCommand.CommandType = System.Data.CommandType.Text;

            parameter = new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.UniqueIdentifier);
            insertCommand.Parameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.NVarChar, 100);
            parameter.Value = file.Substring(file.LastIndexOf('\\') + 1);
            insertCommand.Parameters.Add(parameter);

            insertCommand.Transaction = connection.BeginTransaction();
            helperCommand.Transaction = insertCommand.Transaction;

            helperCommand.CommandText = "SELECT GET_FILESTREAM_TRANSACTION_CONTEXT()";
            transactionContext = helperCommand.ExecuteScalar();

            helperCommand.CommandText = "SELECT Data.PathName() FROM FileStreamTest WHERE [Id] = @Id";
            parameter = new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.UniqueIdentifier);
            helperCommand.Parameters.Add(parameter);

            fileData = System.IO.File.ReadAllBytes(file);

            startTime = System.DateTime.Now;

            insertCommand.Parameters["@Id"].Value = System.Guid.NewGuid();
            rowsInserted = insertCommand.ExecuteNonQuery();

            helperCommand.Parameters["@Id"].Value = insertCommand.Parameters["@Id"].Value;
            filePathInServer = (string)helperCommand.ExecuteScalar();

            sqlFileStream = new System.Data.SqlTypes.SqlFileStream(filePathInServer, (byte[])transactionContext, System.IO.FileAccess.Write);
            sqlFileStream.Write(fileData, 0, fileData.Length);
            sqlFileStream.Close();

            endTime = System.DateTime.Now;
            insertCommand.Transaction.Commit();

            connection.Close();
            return endTime.Subtract(startTime);
        }

        internal static bool IdKorisnika(int idKorisnika)
        {
            System.Data.SqlClient.SqlConnection connection = OpenConnection();
            
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SELECT IdKorisnik FROM Slika WHERE IdKorisnik = @IdKorisnik";
                cmd.Connection = connection;
                try
                {
                    cmd.Parameters.AddWithValue("@IdKorisnik", idKorisnika);
                    
                    int a = Convert.ToInt32(cmd.ExecuteScalar());
                    connection.Close();
                    if (a > 0) { return true; }
                    else { return false; }
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
        }
        #endregion Uploading

        #region Downloading
        /// <summary>
        /// Fetches the file from database using SqlParameter
        /// </summary>
        /// <param name="guid">Identifier of the row</param>
        /// <param name="tableType">Source table type</param>
        /// <param name="name">Original name of the file</param>
        /// <param name="data">The data for the file</param>
        /// <returns>Elapsed time</returns>
        internal static System.TimeSpan FetchFileUsingSqlParameter(string guid, TableType tableType, out string name, out byte[] data)
        {
            System.Data.SqlClient.SqlConnection connection = OpenConnection();
            System.Data.SqlClient.SqlCommand command = connection.CreateCommand();
            System.Data.SqlClient.SqlParameter parameter;
            System.Data.SqlClient.SqlDataReader reader;
            System.DateTime startTime;
            System.DateTime endTime;

            command.CommandText = "SELECT [Name], [Data] FROM " + (tableType == TableType.Traditional ? "VarbinaryTest" : "FileStreamTest") + " WHERE [Id] = @Id";
            command.CommandType = System.Data.CommandType.Text;

            parameter = new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.UniqueIdentifier);
            parameter.Value = new System.Guid(guid);
            command.Parameters.Add(parameter);

            startTime = System.DateTime.Now;
            reader = command.ExecuteReader();
            reader.Read();
            endTime = System.DateTime.Now;

            name = (string)reader["Name"];
            data = (byte[])reader["Data"];

            connection.Close();

            return endTime.Subtract(startTime);
        }
        internal static System.TimeSpan FetchFileUsingSqlFileStream(string guid, out string name, out byte[] data)
        {
            System.Data.SqlClient.SqlConnection connection = OpenConnection();
            System.Data.SqlClient.SqlCommand command = connection.CreateCommand();
            System.Data.SqlClient.SqlParameter parameter;
            System.Data.SqlClient.SqlDataReader reader;
            System.Data.SqlTypes.SqlFileStream sqlFileStream;
            string filePathInServer;
            object transactionContext;
            System.DateTime startTime;
            System.DateTime endTime;
            int byteAmount;

            data = new byte[500000000];

            command.Transaction = connection.BeginTransaction();

            command.CommandText = "SELECT GET_FILESTREAM_TRANSACTION_CONTEXT()";
            command.CommandType = System.Data.CommandType.Text;
            transactionContext = command.ExecuteScalar();

            command.CommandText = "SELECT [Name], [Data].PathName() AS FilePath FROM FileStreamTest WHERE [Id] = @Id";
            command.CommandType = System.Data.CommandType.Text;

            parameter = new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.UniqueIdentifier);
            parameter.Value = new System.Guid(guid);
            command.Parameters.Add(parameter);

            startTime = System.DateTime.Now;
            reader = command.ExecuteReader();
            reader.Read();

            name = (string)reader["Name"];
            filePathInServer = (string)reader["FilePath"];
            reader.Close();

            sqlFileStream = new System.Data.SqlTypes.SqlFileStream(filePathInServer, (byte[])transactionContext, System.IO.FileAccess.Read);
            sqlFileStream.Seek(0L, System.IO.SeekOrigin.Begin);
            byteAmount = sqlFileStream.Read(data, 0, 500000000);
            sqlFileStream.Close();
            command.Transaction.Commit();

            endTime = System.DateTime.Now;
            connection.Close();

            System.Array.Resize<byte>(ref data, byteAmount);

            return endTime.Subtract(startTime);
        }
        #endregion Downloading

        internal static byte[] VratiSliku(int idKorisnika)
        {
            byte[] picData = null;
            System.Data.SqlClient.SqlConnection connection = OpenConnection();
            


            string query = "Select Data from Slika where IdKorisnik=@IdKorisnik";
            
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@IdKorisnik", idKorisnika);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                picData = reader["Data"] as byte[] ?? null;

            }
            connection.Close();
            return picData;

        }
    }
}
