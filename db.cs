using System.Data;
using MySql.Data.MySqlClient;
//using Mysqlx.Crud;


namespace idata360
{
    public class Database
    {
        public List<Recruitment> Get()
        {
            string connectionString = "server=localhost;port=3306;userid=root;password=p123;database=idata360"; // informacoes necessarias para conectar ao banco de dados

            using (MySqlConnection conexao = new MySqlConnection(connectionString)) // passa as informacoes de conexao ao metodo
            {

                MySqlCommand comando = new MySqlCommand("SELECT * FROM recruitment", conexao);  // estabelece um comando SQL, no caso deste, busca todas as informacoes da tabela recruitment

                DataTable tabela = new DataTable();     // instanciando a classe DataTable, funcoes necessarias para pegar informacoes da tabela
                
                try                                     
                {
                    conexao.Open();                     // Abre a conexao com o banco de dados
                                                        
                    using (MySqlDataReader reader = comando.ExecuteReader()) // executa o comando SQL estabelecido 
                    {
                        tabela.Load(reader);

                    }

                    Tabela dados = new Tabela();        // instanciando a classe Tabela
                    
                    //foreach (DataColumn column in tabela.Columns) // buscando as colunas da tabela
                    //{
                     //   dados.Headers.Add(column.ColumnName);     // adicionando os nomes das colunas a propriedade Headers
                    //}
                    foreach (DataRow row in tabela.Rows)          // buscando as linhas da tabela
                    {
                        Recruitment recruitment = new Recruitment // instanciando a classe recruitment e convertendo as propriedades
                        {
                            ID = Convert.ToInt32(row["ID"]),
                            Exportador = row["Exportador"].ToString(),
                            Importador = row["Importador"].ToString(),
                            DataEmbarque = Convert.ToDateTime(row["DataEmbarque"]),
                            PrevisaoDeEmbarque = Convert.ToDateTime(row["PrevisaoDeEmbarque"]),
                            DataChegada = Convert.ToDateTime(row["DataChegada"]),
                            PrevisaoDeChegada = Convert.ToDateTime(row["PrevisaoDeChegada"]),
                            DI = row["DI"].ToString(),
                            Navio = row["Navio"].ToString(),
                            Master = row["Master"].ToString(),
                            House = row["House"].ToString(),
                            Fatura = row["Fatura"].ToString(),
                            FreteModo = row["FreteModo"].ToString(),
                            Container = row["Container"].ToString(),
                            CanalParametrizacao = row["CanalParametrizacao"].ToString(),
                            Origem = row["Origem"].ToString(),
                            Destino = row["Destino"].ToString(),
                            LiberadoParaFaturamento = row["LiberadoParaFaturamento"].ToString()
                        };
                        dados.Values.Add(recruitment);           // adicionando os valores das linhas a propriedade Values
                    }

                    return dados.Values;
                }
                catch (Exception ex)   // capta uma excecao                             
                {
                    Console.WriteLine("Erro: " + ex.Message);    // escreve a excecao no console

                }
                return null;
            }
            
        }
    }
}
