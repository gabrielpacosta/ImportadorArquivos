using System;

namespace ImportadorArquivos.Model
{
    public class RejMis
    {
        public int id { get; set; }
        public String cpf { get; set; }
        public String contrato { get; set; }
        public String descricao_produto { get; set; }
        public string parcela { get; set; }
        public DateTime data_pagamento { get; set; }
        public String uf_resid { get; set; }
        public Decimal valor_prestacao { get; set; }
        public String erro { get; set; }
        public Decimal atraso { get; set; }
        public string nomeArquivo { get; set; }
    }
}
