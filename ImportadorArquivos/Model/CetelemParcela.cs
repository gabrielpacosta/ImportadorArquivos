using System;

namespace ImportadorArquivos.Model
{
    class CetelemParcela
    {
        public int id { get; set; }
        public DateTime? data_arquivo { get; set; }
        public String contrato { get; set; }
        public Decimal valor_original { get; set; }
        public DateTime data_vencimento { get; set; }
        public DateTime data_pagamento { get; set; }
        public Decimal valor_pagamento { get; set; }
        public String processo { get; set; }
        public DateTime data_ultimo_vencimento { get; set; }
        public Decimal valor_principal { get; set; }
        public int codigo_parcela { get; set; }

    }
}
