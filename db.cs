using System.Data;
using MySql.Data.MySqlClient;

namespace idata360
{
    public class Database
    {
        string connectionString = "server=localhost;port=3306;userid=root;password=p123;database=idata360"; // Informacoes necessarias para conectar ao banco de dados
        public List<Recruitment> GetData()
        {
             
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
        public bool InsertData(Recruitment recruitment)
        {
            using (MySqlConnection conexao = new MySqlConnection(connectionString))
            {   
                // Adicionando o comando de insercao de dados a tabela
                string comandoSQL = @"INSERT INTO recruitment  (Exportador,             
                                                                Importador, 
                                                                DataEmbarque, 
                                                                PrevisaoDeEmbarque, 
                                                                DataChegada, 
                                                                PrevisaoDeChegada, 
                                                                DI, 
                                                                Navio, 
                                                                Master, 
                                                                House, 
                                                                Fatura, 
                                                                FreteModo, 
                                                                Container, 
                                                                CanalParametrizacao, 
                                                                Origem, 
                                                                Destino, 
                                                                LiberadoParaFaturamento) 
                                                                VALUES (@Exportador, 
                                                                @Importador, 
                                                                @DataEmbarque, 
                                                                @PrevisaoDeEmbarque, 
                                                                @DataChegada,   
                                                                @PrevisaoDeChegada, 
                                                                @DI, 
                                                                @Navio, 
                                                                @Master,  
                                                                @House, 
                                                                @Fatura, 
                                                                @FreteModo, 
                                                                @Container, 
                                                                @CanalParametrizacao, 
                                                                @Origem, 
                                                                @Destino, 
                                                                @LiberadoParaFaturamento)";

                MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

                // Adiciona os parametros ao comando SQL
                comando.Parameters.AddWithValue("@Exportador", recruitment.Exportador);
                comando.Parameters.AddWithValue("@Importador", recruitment.Importador);
                comando.Parameters.AddWithValue("@DataEmbarque", recruitment.DataEmbarque);
                comando.Parameters.AddWithValue("@PrevisaoDeEmbarque", recruitment.PrevisaoDeEmbarque);
                comando.Parameters.AddWithValue("@DataChegada", recruitment.DataChegada);
                comando.Parameters.AddWithValue("@PrevisaoDeChegada", recruitment.PrevisaoDeChegada);
                comando.Parameters.AddWithValue("@DI", recruitment.DI);
                comando.Parameters.AddWithValue("@Navio", recruitment.Navio);
                comando.Parameters.AddWithValue("@Master", recruitment.Master);
                comando.Parameters.AddWithValue("@House", recruitment.House);
                comando.Parameters.AddWithValue("@Fatura", recruitment.Fatura);
                comando.Parameters.AddWithValue("@FreteModo", recruitment.FreteModo);
                comando.Parameters.AddWithValue("@Container", recruitment.Container);
                comando.Parameters.AddWithValue("@CanalParametrizacao", recruitment.CanalParametrizacao);
                comando.Parameters.AddWithValue("@Origem", recruitment.Origem);
                comando.Parameters.AddWithValue("@Destino", recruitment.Destino);
                comando.Parameters.AddWithValue("@LiberadoParaFaturamento", recruitment.LiberadoParaFaturamento);

                try
                {
                    conexao.Open();
                    int registrosAfetados = comando.ExecuteNonQuery();           // Retorna as linhas afetadas pelo metodo

                    return registrosAfetados > 0;                                // Retorna true caso registros forem afetados
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao inserir dados: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
