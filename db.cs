using System.Data;
using MySql.Data.MySqlClient;

namespace idata360
{
    public class Database
    {
        public List<Recruitment> GetData()
        {
            string connectionString = "server=localhost;port=3306;userid=root;password=p123;database=idata360"; // Informacoes necessarias para conectar ao banco de dados

            using (MySqlConnection conexao = new MySqlConnection(connectionString)) // Repassa as informacoes de conexao 
            {

                MySqlCommand comando = new MySqlCommand("SELECT * FROM recruitment", conexao);  // Estabelece um comando SQL, no caso deste, busca todos valores da tabela Recruitment

                DataTable tabela = new DataTable();     // Instanciando a classe DataTable, funcoes necessarias para pegar informacoes da tabela
                
                try                                     
                {
                    conexao.Open();                     // Abre a conexao com o banco de dados
                                                        
                    using (MySqlDataReader reader = comando.ExecuteReader()) // Executa o comando SQL estabelecido 
                    {
                        tabela.Load(reader);

                    }

                    Tabela dados = new Tabela();        // Instanciando a classe Tabela
                    
                    foreach (DataRow row in tabela.Rows)          // Passa por todas as linhas da tabela
                    {
                        Recruitment recruitment = new Recruitment // Cria um novo objeto da classe recruitment para cada linha lida 
                        {   
                            // Preenchendo as propriedades com os valores correspondentes da tabela
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
                            LiberadoParaFaturamento = Convert.ToDateTime(row["LiberadoParaFaturamento"])
                        };
                        dados.Values.Add(recruitment);           // Adiciona os valores das linhas a lista Values
                    }

                    return dados.Values;
                }
                catch (Exception ex)   // Capta uma excecao                             
                {
                    Console.WriteLine("Erro: " + ex.Message);    // Escreve a excecao no console

                }
                return null;
            }
            
        }
    }
}
