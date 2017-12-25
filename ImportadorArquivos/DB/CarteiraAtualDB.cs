using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Text;
using ImportadorArquivos.Model;

namespace ImportadorArquivos.DB
{
    class CarteiraAtualDB
    {
        public static void Insert(string[] AllLines, string fileName)
        {
           
            for (int i = 0; i < AllLines.Length; i += 5000)
            {
                StringBuilder query = new StringBuilder("INSERT INTO carteira_atual " +
                            "(`CPF_CNPJ`,`Nome`,`UF_Resid`,`CEP_Resid`,`CIDADE_Resid`,`UF_Comerc`, " +
                            "`CEP_Comerc`,`CIDADE_Comerc`,`Codigo_Produto`,`Produto_Recup`,`Produto_BMG`," +
                            "`Contrato`,`Distribuicao` ,`Cod_Distri_Grupo`,`Num_Fase`,`Operador_Contrato`, " +
                            "`COD_LOJA`,`NOM_LOJA`,`Atraso`,`Parcela`,`PrincipalTotal`, `Situacao_Codigo`," +
                            "`Situacao_Descricao`,`Data_Expiracao`,`Acordo`,`Renegociado`,`CodEntidade`, " +
                            "`Entidade`,`Safra`,`Falecido`,`Data_Carga`,`Deposito`," +
                            "`Data_Acordo`,`TotalParcelas_Acordo`,`ValorParcela_Acordo`," +
                            "`TotalParcelasPagas_Acordo`,`TotalParcelas_EmAberto`,`Valor_do_acordo`," +
                            "`Matricula`,`Orgao`,`SubOrgao`,`Data_ultimo_desconto`,`Data_ultimo_pagamento`," +
                            "`Plano_parcelas`,`ValorParcelas_Vencido`,`ValorParcela`,`Email_Cliente`," +
                            "`Data_Inicio_Contrato`,`Promotora_SCH`, `Data_Arquivo`)" +
                            " VALUES ");

                using (MySqlConnection mConnection = new MySqlConnection(_Global.ConnectionString))
                {
                    List<string> Rows = new List<string>();
                    for (int j = 1; j <= 5000; j++)
                    {
                        if (i + j >= AllLines.Length)
                            break;

                        CarteiraAtual carteira = new CarteiraAtual();
                        carteira = ProcessaLinhaCarteira_atual(AllLines[i + j]);
                        carteira.linhaArquivo = i + j;
                        carteira.nomeArquivo = fileName;

                        Rows.Add(string.Format(@"({0},{1}, {2},{3}, {4},{5}, {6},{7}, {8},{9}, {10},{11}, {12},{13}, {14},{15}, {16},{17}, {18},{19}, {20},{21}, {22},{23}, {24},{25}, {26},{27}, {28},{29}, {30},{31}, {32},{33}, {34},{35}, {36},{37}, {38},{39}, {40},{41}, {42},{43}, {44},{45}, {46},{47}, {48}, {49})",
                        MySqlHelper.EscapeString(CheckStrNull(carteira.CPF_CNPJ)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.Nome)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.UF_Resid)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.CEP_Resid)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.CIDADE_Resid)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.UF_Comerc)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.CEP_Comerc)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.CIDADE_Comerc)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.Codigo_Produto)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.Produto_Recup)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.Produto_BMG)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.Contrato)),
                        MySqlHelper.EscapeString(CheckDateNull(carteira.Distribuicao)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.Cod_Distri_Grupo)),
                        MySqlHelper.EscapeString(carteira.Num_Fase.ToString("F0", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.Operador_Contrato)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.COD_LOJA)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.NOM_LOJA)),
                        MySqlHelper.EscapeString(carteira.Atraso.ToString("F0", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(carteira.Parcela.ToString("F0", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(carteira.PrincipalTotal.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.Situacao_Codigo)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.Situacao_Descricao)),
                        MySqlHelper.EscapeString(CheckDateNull(carteira.Data_Expiracao)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.Acordo.ToString())),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.Renegociado)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.CodEntidade)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.Entidade)),
                        MySqlHelper.EscapeString(CheckDateNull(carteira.Safra)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.Falecido)),
                        MySqlHelper.EscapeString(CheckDateNull(carteira.Data_Carga)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.Deposito)),
                        MySqlHelper.EscapeString(CheckDateNull(carteira.Data_Acordo)),
                        MySqlHelper.EscapeString(carteira.TotalParcelas_Acordo.ToString("F0", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(carteira.ValorParcela_Acordo.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(carteira.TotalParcelasPagas_Acordo.ToString("F0", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(carteira.TotalParcelas_EmAberto.ToString("F0", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(carteira.Valor_do_acordo.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.Matricula)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.Orgao)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.SubOrgao)),
                        MySqlHelper.EscapeString(CheckDateNull(carteira.Data_ultimo_desconto)),
                        MySqlHelper.EscapeString(CheckDateNull(carteira.Data_ultimo_pagamento)),
                        MySqlHelper.EscapeString(carteira.Plano_parcelas.ToString("F0", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(carteira.ValorParcelas_Vencido.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(carteira.ValorParcela.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.Email_Cliente)),
                        MySqlHelper.EscapeString(CheckDateNull(carteira.Data_Inicio_Contrato)),
                        MySqlHelper.EscapeString(CheckStrNull(carteira.Promotora_SCH)),
                        MySqlHelper.EscapeString(CheckDateNull(CarteiraAtual.Data_Arquivo))));

                    }

                    query.Append(string.Join(','.ToString(), Rows));
                    query.Replace(@"\", string.Empty);

                    try
                    {
                        mConnection.Open();
                        using (MySqlCommand myCmd = new MySqlCommand(query.ToString(), mConnection))
                        {
                            myCmd.ExecuteNonQuery();
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine($"**********ERRO: " + ex);
                        //Console.WriteLine($"**********ERRO: " + query.ToString());
                    }
                    finally
                    {
                        mConnection.Close();
                    }

                }
            }
        }


        private static CarteiraAtual ProcessaLinhaCarteira_atual(string linha)
        {
            var carteira_atual = new CarteiraAtual();
            decimal val;
            string[] campos;
            campos = linha.Split('|');
            carteira_atual.CPF_CNPJ = campos[2];
            carteira_atual.Nome = campos[3];
            carteira_atual.UF_Resid = campos[4];
            carteira_atual.CEP_Resid = campos[5];
            carteira_atual.CIDADE_Resid = campos[6];
            carteira_atual.UF_Comerc = campos[7];
            carteira_atual.CEP_Comerc = campos[8];
            carteira_atual.CIDADE_Comerc = campos[9];
            carteira_atual.Codigo_Produto = campos[11];
            carteira_atual.Produto_Recup = campos[12];
            carteira_atual.Produto_BMG = campos[13];
            carteira_atual.Contrato = campos[14];
            carteira_atual.Distribuicao = string.IsNullOrEmpty(campos[15]) ? DateTime.MinValue : DateTime.ParseExact(campos[15], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            carteira_atual.Cod_Distri_Grupo = campos[16];
            carteira_atual.Num_Fase = (Decimal.TryParse(campos[17].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out val) ? val : 0);
            carteira_atual.Operador_Contrato = campos[18];
            carteira_atual.COD_LOJA = campos[19];
            carteira_atual.NOM_LOJA = campos[20];
            carteira_atual.Atraso = (Decimal.TryParse(campos[21].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out val) ? val : 0);
            carteira_atual.Parcela = (Decimal.TryParse(campos[22].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out val) ? val : 0);
            carteira_atual.PrincipalTotal = (Decimal.TryParse(campos[23].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out val) ? val : 0);
            carteira_atual.Situacao_Codigo = campos[24];
            carteira_atual.Situacao_Descricao = campos[25];
            carteira_atual.Data_Expiracao = string.IsNullOrEmpty(campos[26]) ? DateTime.MinValue : DateTime.ParseExact(campos[26], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            carteira_atual.Acordo = campos[27];
            carteira_atual.Renegociado = campos[28];
            carteira_atual.CodEntidade = campos[29];
            carteira_atual.Entidade = campos[30];
            carteira_atual.Safra = string.IsNullOrEmpty(campos[31]) ? DateTime.MinValue : DateTime.ParseExact(campos[31], "MM/yyyy", CultureInfo.InvariantCulture);
            carteira_atual.Falecido = campos[32];
            carteira_atual.Data_Carga = string.IsNullOrEmpty(campos[33]) ? DateTime.MinValue : DateTime.ParseExact(campos[33], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            carteira_atual.Deposito = campos[34];
            carteira_atual.Data_Acordo = string.IsNullOrEmpty(campos[36]) ? DateTime.MinValue : DateTime.ParseExact(campos[36], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            carteira_atual.TotalParcelas_Acordo = (Decimal.TryParse(campos[37].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out val) ? val : 0);
            carteira_atual.ValorParcela_Acordo = (Decimal.TryParse(campos[38].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out val) ? val : 0);
            carteira_atual.TotalParcelasPagas_Acordo = (Decimal.TryParse(campos[39].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out val) ? val : 0);
            carteira_atual.TotalParcelas_EmAberto = (Decimal.TryParse(campos[40].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out val) ? val : 0);
            carteira_atual.Valor_do_acordo = (Decimal.TryParse(campos[41].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out val) ? val : 0);
            carteira_atual.Matricula = campos[42];
            carteira_atual.Orgao = campos[43];
            carteira_atual.SubOrgao = campos[44];
            carteira_atual.Data_ultimo_desconto = string.IsNullOrEmpty(campos[45]) ? DateTime.MinValue : DateTime.ParseExact(campos[45], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            carteira_atual.Data_ultimo_pagamento = string.IsNullOrEmpty(campos[46]) ? DateTime.MinValue : DateTime.ParseExact(campos[46], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            carteira_atual.Plano_parcelas = (Decimal.TryParse(campos[47].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out val) ? val : 0);
            carteira_atual.ValorParcelas_Vencido = (Decimal.TryParse(campos[48].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out val) ? val : 0);
            carteira_atual.ValorParcela = (Decimal.TryParse(campos[49].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out val) ? val : 0);
            carteira_atual.Email_Cliente = campos[50];
            carteira_atual.Data_Inicio_Contrato = string.IsNullOrEmpty(campos[51]) ? DateTime.MinValue : DateTime.ParseExact(campos[51], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            carteira_atual.Promotora_SCH = campos[52];
            return carteira_atual;
        }

        private static string CheckStrNull(string s)
        {
            return string.IsNullOrEmpty(s) ? "null" : @"'" + s+ @"'";
        }

        private static string CheckDateNull(DateTime? d)
        {
            return d.Value == DateTime.MinValue ? "null" : @"'" + d.Value.ToString("yyyy-MM-dd") + @"'";
        }

    }
}

