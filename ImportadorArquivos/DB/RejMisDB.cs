using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Text;
using ImportadorArquivos.Model;

namespace ImportadorArquivos.DB
{
    class RejMisDB
    {
        public static void Insert(string[] AllLines, string fileName)
        {
            for (int i = 0; i < AllLines.Length; i += 5000)
            {
                StringBuilder query = new StringBuilder("INSERT INTO `Itau.RejMis`" +
                      " (`cpf`, `contrato`, `descricao_produto`, `parcela`," +
                      " `data_pagamento`, `uf_resid`, `valor_prestacao`," +
                      " `erro`, `atraso`, `nomeArquivo`)" + 
                      " VALUES ");

                using (MySqlConnection mConnection = new MySqlConnection(_Global.ConnectionString))
                {
                    List<string> Rows = new List<string>();

                    for (int j = 1; j <= 5000; j++)
                    {
                        if (i + j >= AllLines.Length)
                            break;

                        RejMis rej_mis = new RejMis();
                        rej_mis =  ProcessaLinhaRejMis(AllLines[i+j]);
                        rej_mis.nomeArquivo = fileName;

                        Rows.Add(string.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9})",
                        MySqlHelper.EscapeString(CheckStrNull(rej_mis.cpf)),
                        MySqlHelper.EscapeString(CheckStrNull(rej_mis.contrato)),
                        MySqlHelper.EscapeString(CheckStrNull(rej_mis.descricao_produto)),
                        MySqlHelper.EscapeString(CheckStrNull(rej_mis.parcela)),
                        MySqlHelper.EscapeString(CheckDateNull(rej_mis.data_pagamento)),
                        MySqlHelper.EscapeString(CheckStrNull(rej_mis.uf_resid)),
                        MySqlHelper.EscapeString(rej_mis.valor_prestacao.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(CheckStrNull(rej_mis.erro)),
                        MySqlHelper.EscapeString(rej_mis.atraso.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(CheckStrNull(rej_mis.nomeArquivo))));
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
                    }
                    finally
                    {
                        mConnection.Close();
                    }

                }
            }
        }


        private static RejMis ProcessaLinhaRejMis(string linha)
        {
            var rej_mis = new RejMis();
            string[] campos;
            campos = linha.Split('|');
            rej_mis.cpf = campos[4];
            rej_mis.contrato = campos[6];
            rej_mis.descricao_produto = campos[10];
            rej_mis.parcela = campos[11];
            rej_mis.data_pagamento = string.IsNullOrEmpty(campos[13]) ? DateTime.MinValue : DateTime.ParseExact(campos[13], "dd/MM/yy", CultureInfo.InvariantCulture);
            rej_mis.uf_resid = campos[21];
            rej_mis.valor_prestacao = Decimal.Parse(campos[23].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture);
            rej_mis.erro = campos[24];
            rej_mis.atraso = Decimal.Parse(campos[27].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture);
            return rej_mis;
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

