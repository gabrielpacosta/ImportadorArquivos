using System;

namespace ImportadorArquivos.Model
{
    public class CarteiraAtual
    {
        public static DateTime Data_Arquivo;
        public String CPF_CNPJ { get; set; }
        public String Nome { get; set; }
        public String UF_Resid { get; set; }
        public String CEP_Resid { get; set; }
        public String CIDADE_Resid { get; set; }
        public String UF_Comerc { get; set; }
        public String CEP_Comerc { get; set; }
        public String CIDADE_Comerc { get; set; }
        public String Codigo_Produto { get; set; }
        public String Produto_Recup { get; set; }
        public String Produto_BMG { get; set; }
        public String Contrato { get; set; }
        public DateTime? Distribuicao { get; set; }
        public String Cod_Distri_Grupo { get; set; }
        public Decimal Num_Fase { get; set; }
        public String Operador_Contrato { get; set; }
        public String COD_LOJA { get; set; }
        public String NOM_LOJA { get; set; }
        public Decimal Atraso { get; set; }
        public Decimal Parcela { get; set; }
        public Decimal PrincipalTotal { get; set; }
        public String Situacao_Codigo { get; set; }
        public String Situacao_Descricao { get; set; }
        public DateTime? Data_Expiracao { get; set; }
        public String Acordo { get; set; }
        public String Renegociado { get; set; }
        public String CodEntidade { get; set; }
        public String Entidade { get; set; }
        public DateTime? Safra { get; set; }
        public String Falecido { get; set; }
        public DateTime? Data_Carga { get; set; }
        public String Deposito { get; set; }
        public DateTime? Data_Acordo { get; set; }
        public Decimal TotalParcelas_Acordo { get; set; }
        public Decimal ValorParcela_Acordo { get; set; }
        public Decimal TotalParcelasPagas_Acordo { get; set; }
        public Decimal TotalParcelas_EmAberto { get; set; }
        public Decimal Valor_do_acordo { get; set; }
        public String Matricula { get; set; }
        public String Orgao { get; set; }
        public String SubOrgao { get; set; }
        public DateTime? Data_ultimo_desconto { get; set; }
        public DateTime? Data_ultimo_pagamento { get; set; }
        public Decimal Plano_parcelas { get; set; }
        public Decimal ValorParcelas_Vencido { get; set; }
        public Decimal ValorParcela { get; set; }
        public String Email_Cliente { get; set; }
        public DateTime? Data_Inicio_Contrato { get; set; }
        public String Promotora_SCH { get; set; }
        public Decimal linhaArquivo { get; set; }
        public string nomeArquivo { get; set; }
    }
}
