using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Text;
using ImportadorArquivos.Model;

namespace ImportadorArquivos.DB
{
    class RecAssDB
    {
        public static void Insert(string[] AllLines, string fileName)
        {
            for (int i = 0; i < AllLines.Length; i += 5000)
            {
                StringBuilder query = new StringBuilder("INSERT INTO rec_ass" +
                   " (`tipo_pagamento_ge`, `tipo_pagamento`, `processamento`," +
                    " `cod_receb`, `credor`, `cliente`, `cpf`," +
                    " `nome`, `cod_produto`, `produto`," +
                    " `contrato`, `vencimento_prestacao`, `numero_prestacao`, `data_pagamento`," +
                    " `valor_pago`, `bonificacao_maxima`, `bonificacao_a_receber`, `valor_honorarios`," +
                    " `valor_adicional`, `operador`, `cod_gerente`, `nome_gerente`, `uf_comer`," +
                    " `uf_resid`, `campanha_recebimento`, `campanha_cinco`, `campanha_restante`," +
                    " `indicador`, `assessoria`, `debito_nao_ajuizavel`, `qtde_parcela_do_acordo`," +
                    " `qtde_de_parcelas_em_aberto`, `parcela_do_acordo`, `cod_entidade`," +
                    " `valor_principal`, `desconto_aplicado`, `atraso`, `nivel_negociacao`," +
                    " `divida_atualizada`, `nomeArquivo`)" +
                    " VALUES ");

                using (MySqlConnection mConnection = new MySqlConnection(_Global.ConnectionString))
                {
                    List<string> Rows = new List<string>();

                    for (int j = 1; j <= 5000; j++)
                    {
                        if (i + j >= AllLines.Length)
                            break;

                        RecAss rec_ass = new RecAss();
                        rec_ass =  ProcessaLinhaRecAss(AllLines[i+j]);
                        rec_ass.linhaArquivo = i + j;
                        rec_ass.nomeArquivo = fileName;

                        Rows.Add(string.Format("({0},{1}, {2},{3}, {4},{5}, {6},{7}, {8},{9}, {10},{11}, {12},{13}, {14},{15}, {16},{17}, {18},{19}, {20},{21}, {22},{23}, {24},{25}, {26},{27}, {28},{29}, {30},{31}, {32},{33}, {34},{35}, {36},{37}, {38}, {39})",
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.tipo_pagamento_ge)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.tipo_pagamento)),
                        MySqlHelper.EscapeString(CheckDateNull(rec_ass.processamento)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.cod_receb)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.credor)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.cliente)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.cpf)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.nome)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.cod_produto)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.produto)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.contrato)),
                        MySqlHelper.EscapeString(CheckDateNull(rec_ass.vencimento_prestacao)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.numero_prestacao)),
                        MySqlHelper.EscapeString(CheckDateNull(rec_ass.data_pagamento)),
                        MySqlHelper.EscapeString(rec_ass.valor_pago.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(rec_ass.bonificacao_maxima.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(rec_ass.bonificacao_a_receber.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(rec_ass.valor_honorarios.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(rec_ass.valor_adicional.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.operador)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.cod_gerente)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.nome_gerente)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.uf_comer)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.uf_resid)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.campanha_recebimento)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.campanha_cinco)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.campanha_restante)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.indicador)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.assessoria)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.debito_nao_ajuizavel)),
                        MySqlHelper.EscapeString(rec_ass.qtde_parcela_do_acordo.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(rec_ass.qtde_de_parcelas_em_aberto.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(rec_ass.parcela_do_acordo.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.cod_entidade)),
                        MySqlHelper.EscapeString(rec_ass.valor_principal.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(rec_ass.desconto_aplicado.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(rec_ass.atraso.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(rec_ass.nivel_negociacao.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(rec_ass.divida_atualizada.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(CheckStrNull(rec_ass.nomeArquivo))));

                    }

                    query.Append(string.Join(','.ToString(), Rows));
                    query.Replace(@"\", string.Empty);
                    query.Append(" ON DUPLICATE KEY UPDATE id=id");

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
                        Console.WriteLine($"**********ERRO: " + ex.Message);
                        //Console.WriteLine($"**********ERRO: " + query.ToString());
                    }
                    finally
                    {
                        mConnection.Close();
                    }

                }
            }
        }


        private static RecAss ProcessaLinhaRecAss(string linha)
        {
            var rec_ass = new RecAss();
            decimal val;
            string[] campos;
            campos = linha.Split('|');
            rec_ass.tipo_pagamento_ge = campos[0];
            rec_ass.tipo_pagamento = campos[1];
            rec_ass.processamento = string.IsNullOrEmpty(campos[2]) ? DateTime.MinValue : DateTime.ParseExact(campos[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            rec_ass.cod_receb = campos[3];
            rec_ass.credor = campos[4];
            rec_ass.cliente = campos[5];
            rec_ass.cpf = campos[6];
            rec_ass.nome = campos[7];
            rec_ass.cod_produto = campos[8];
            rec_ass.produto = campos[9];
            rec_ass.contrato = campos[10];
            rec_ass.vencimento_prestacao = string.IsNullOrEmpty(campos[11]) ? DateTime.MinValue : DateTime.ParseExact(campos[11], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            rec_ass.numero_prestacao = campos[12];
            rec_ass.data_pagamento = string.IsNullOrEmpty(campos[13]) ? DateTime.MinValue : DateTime.ParseExact(campos[13], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            rec_ass.valor_pago = Decimal.Parse(campos[14].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture);
            rec_ass.bonificacao_maxima = Decimal.Parse(campos[15].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture);
            rec_ass.bonificacao_a_receber = Decimal.Parse(campos[16].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture);
            rec_ass.valor_honorarios = Decimal.Parse(campos[17].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture);
            rec_ass.valor_adicional = (Decimal.TryParse(campos[18].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out val) ? val : 0);
            rec_ass.operador = campos[19];
            rec_ass.cod_gerente = campos[20];
            rec_ass.nome_gerente = campos[21];
            rec_ass.uf_comer = campos[22];
            rec_ass.uf_resid = campos[23];
            rec_ass.campanha_recebimento = campos[24];
            rec_ass.campanha_cinco = campos[25];
            rec_ass.campanha_restante = campos[26];
            rec_ass.indicador = campos[27];
            rec_ass.assessoria = campos[28];
            rec_ass.debito_nao_ajuizavel = campos[29];
            rec_ass.qtde_parcela_do_acordo = (Decimal.TryParse(campos[30].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out val) ? val : 0);
            rec_ass.qtde_de_parcelas_em_aberto = (Decimal.TryParse(campos[31].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out val) ? val : 0);
            rec_ass.parcela_do_acordo = (Decimal.TryParse(campos[32].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out val) ? val : 0);
            rec_ass.cod_entidade = campos[33];
            rec_ass.valor_principal = Decimal.Parse(campos[34].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture);
            rec_ass.desconto_aplicado = Decimal.Parse(campos[35].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture);
            rec_ass.atraso = Decimal.Parse(campos[36].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture);
            rec_ass.nivel_negociacao = Decimal.Parse(campos[37].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture);
            rec_ass.divida_atualizada = Decimal.Parse(campos[38].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture);
            return rec_ass;
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

