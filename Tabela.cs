namespace idata360
{
    public class Tabela
    {
        public List<string> Headers { get; set; }

        public List<Recruitment> Values{ get; set; }

        public Tabela()
        {
            Headers = new List<string>();
            Values = new List<Recruitment>();
        }

    }

    public class Recruitment
    {
        public int ID { get; set; }
        public string Exportador { get; set; }
        public string Importador { get; set; }
        public DateTime DataEmbarque { get; set; }
        public DateTime PrevisaoDeEmbarque { get; set; }
        public DateTime DataChegada { get; set; }
        public DateTime PrevisaoDeChegada { get; set; }
        public string DI { get; set; }
        public string Navio { get; set; }
        public string Master { get; set; }
        public string House { get; set; }
        public string Fatura { get; set; }
        public string FreteModo { get; set; }
        public string Container { get; set; }
        public string CanalParametrizacao { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public string LiberadoParaFaturamento { get; set; }




    }
}
