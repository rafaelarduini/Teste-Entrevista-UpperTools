using Database.Properties;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class AcessoDadosSqlServer
    {
        //Cria conexão
        private SqlConnection CriarConexao()
        {
            return new SqlConnection(Settings.Default.stringConexao);
        }

        //Parâmetros que vão para o Banco de Dadoa
        private SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameters;

        public void LimparParametros()
        {
            sqlParameterCollection.Clear();
        }

        public void AdicionarParametros(string nomeParametro, object valorParametro)
        {
            sqlParameterCollection.Add(new SqlParameter(nomeParametro, valorParametro));
        }

        //Método para adicionar e excluir
        public object ExecutarManipulcao(CommandType commandType, string nomeStoredProcedure)
        {
            try
            {
                SqlConnection sqlConnection = CriarConexao();

                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredProcedure;
                sqlCommand.CommandTimeout = 7200;

                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }

                return sqlCommand.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Método para buscar
        public DataTable ExecutarBusca(CommandType commandType, string nomeStoredProcedure)
        {
            try
            {
                SqlConnection sqlConnection = CriarConexao();

                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredProcedure;
                sqlCommand.CommandTimeout = 7200;

                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                DataTable dataTable = new DataTable();

                sqlDataAdapter.Fill(dataTable);

                return dataTable;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
