using System;

namespace ImportadorArquivos.Model
{
    class CetelemContrato
    {
        public int id { get; set; }
        public DateTime? data_arquivo { get; set; }
        public String contrato { get; set; }
        public String processo { get; set; }
        public String nome_loja { get; set; }
        public DateTime? data_contrato { get; set; }
        public Decimal valor_financiado { get; set; }
        public Decimal valor_prestacao { get; set; }
        public String uf { get; set; }
        public String telefone { get; set; }
        public String nome_empresa { get; set; }
        public String telefone_com { get; set; }
        public String telefone1_res { get; set; }
        public String telefone2_res { get; set; }
        public String celular { get; set; }
        public String email { get; set; }
    }
}
