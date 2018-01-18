using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Text;
using ImportadorArquivos.Model;
using System.Windows.Forms;

namespace ImportadorArquivos.DB
{
    class CetelemDB
    {
        static DateTime dataArquivo;

        public static void Insert(string[] AllLines, string fileName)
        {
            List<CetelemContrato> contratos = new List<CetelemContrato>();
            List<CetelemParcela> parcelas = new List<CetelemParcela>();
            dataArquivo = DateTime.ParseExact(AllLines[0].Substring(21, 8), "ddMMyyyy", CultureInfo.InvariantCulture);

            for (int i = 0; i < AllLines.Length; i++)
            {
                if (AllLines[i].Substring(0, 1) == "1")
                {
                    contratos.Add(processaContrato(AllLines[i], AllLines[i+1]));
                    i++;
                }
                else if (AllLines[i].Substring(0, 1) == "4")
                    parcelas.Add(processaParcela(AllLines[i]));
            }


            InsertContrato(contratos);

            InsertParcela(parcelas);

        }

        private static string CheckStrNull(string s)
        {
            return string.IsNullOrEmpty(s) ? "null" : @"'" + s+ @"'";
        }

        private static string CheckDateNull(DateTime? d)
        {
            if ((d.HasValue == false) || (d.Value == DateTime.MinValue))
                return "null";
            else
                return @"'" + d.Value.ToString("yyyy-MM-dd") + @"'";
        }

        private static CetelemContrato processaContrato(string linha1, string linha2)
        {
            var cet_contrato = new CetelemContrato();

            cet_contrato.data_arquivo = dataArquivo;
            cet_contrato.contrato = linha1.Substring(3, 15);
            cet_contrato.processo = linha1.Substring(18, 2);
            cet_contrato.nome_loja = linha1.Substring(30, 40);
            cet_contrato.data_contrato = linha1.Substring(162, 8) == "00000000" ? DateTime.MinValue : DateTime.ParseExact(linha1.Substring(162, 8), "ddMMyyyy", CultureInfo.InvariantCulture);
            cet_contrato.valor_financiado = Decimal.Parse(linha1.Substring(221,18).Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture)/(decimal)100;
            cet_contrato.valor_prestacao = Decimal.Parse(linha1.Substring(239, 18).Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture)/(decimal)100;
            
            if (linha2.Substring(0,1) == "2")
            {
                cet_contrato.uf = linha2.Substring(315, 2);
                cet_contrato.telefone = linha2.Substring(317, 15);
                cet_contrato.nome_empresa = linha2.Substring(332, 40);
                cet_contrato.telefone_com = linha2.Substring(422,15);
                cet_contrato.telefone1_res = linha2.Substring(528,15);
                cet_contrato.telefone2_res = linha2.Substring(583, 15);
                cet_contrato.celular = linha2.Substring(598,15);
                cet_contrato.email = linha2.Substring(613, 50);
            }
            

            return cet_contrato;
        }

        private static CetelemParcela processaParcela(string linha)
        {
            var cet_parcela = new CetelemParcela();
            cet_parcela.contrato = linha.Substring(3,15);
            cet_parcela.valor_original = Decimal.Parse(linha.Substring(21,18).Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture)/ (decimal)100;
            cet_parcela.data_vencimento = linha.Substring(39, 8) == "00000000" ? DateTime.MinValue : DateTime.ParseExact(linha.Substring(39, 8), "ddMMyyyy", CultureInfo.InvariantCulture);
            cet_parcela.data_pagamento = linha.Substring(47, 8) == "00000000" ? DateTime.MinValue : DateTime.ParseExact(linha.Substring(47, 8), "ddMMyyyy", CultureInfo.InvariantCulture);
            cet_parcela.valor_pagamento = Decimal.Parse(linha.Substring(55, 18).Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture)/ (decimal)100;
            cet_parcela.processo = linha.Substring(82, 2);
            cet_parcela.data_ultimo_vencimento = linha.Substring(84, 8) == "00000000" ? DateTime.MinValue : DateTime.ParseExact(linha.Substring(84, 8), "ddMMyyyy", CultureInfo.InvariantCulture);
            cet_parcela.valor_principal = Decimal.Parse(linha.Substring(92, 18).Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture)/ (decimal)100;
            cet_parcela.codigo_parcela = int.Parse(linha.Substring(18, 3));
            return cet_parcela;
        }

        private static void InsertContrato(List<CetelemContrato> contratos)
        {

            for (int i = 0; i < contratos.Count; i += 5000)
            {
                StringBuilder query = new StringBuilder("INSERT INTO `itsp`.`cetelem_contrato`" +
                "(`data_arquivo`, `contrato`, `processo`, `nome_loja`," +
                "`data_contrato`, `valor_financiado`, `valor_prestacao`, `uf`, `telefone`," +
                "`nome_empresa`, `telefone_com`, `telefone1_res`, `telefone2_res`, " +
                "`celular`, `email`)" +
                " VALUES ");

                using (MySqlConnection mConnection = new MySqlConnection(_Global.ConnectionString))
                {

                    List<string> Rows = new List<string>();

                    for (int j = 0; j < 5000; j++)
                    {
                        if (i + j >= contratos.Count)
                            break;

                        Rows.Add(string.Format("({0},{1}, {2},{3}, {4},{5}, {6},{7}, {8},{9}, {10},{11}, {12},{13}, {14})",
                        MySqlHelper.EscapeString(CheckDateNull(contratos[j+i].data_arquivo)),
                        MySqlHelper.EscapeString(CheckStrNull(contratos[j+i].contrato)),
                        MySqlHelper.EscapeString(CheckStrNull(contratos[j+i].processo)),
                        MySqlHelper.EscapeString(CheckStrNull(contratos[j+i].nome_loja)),
                        MySqlHelper.EscapeString(CheckDateNull(contratos[j+i].data_contrato)),
                        MySqlHelper.EscapeString(contratos[j+i].valor_financiado.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(contratos[j+i].valor_prestacao.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(CheckStrNull(contratos[j+i].uf)),
                        MySqlHelper.EscapeString(CheckStrNull(contratos[j+i].telefone)),
                        MySqlHelper.EscapeString(CheckStrNull(contratos[j+i].nome_empresa)),
                        MySqlHelper.EscapeString(CheckStrNull(contratos[j+i].telefone_com)),
                        MySqlHelper.EscapeString(CheckStrNull(contratos[j+i].telefone1_res)),
                        MySqlHelper.EscapeString(CheckStrNull(contratos[j+i].telefone2_res)),
                        MySqlHelper.EscapeString(CheckStrNull(contratos[j+i].celular)),
                        MySqlHelper.EscapeString(CheckStrNull(contratos[j+i].email))));

                    }

                    query.Append(string.Join(','.ToString(), Rows));
                    query.Replace(@"\", string.Empty);
                    query.Append(" ON DUPLICATE KEY UPDATE processo = VALUES(processo), data_arquivo = VALUES(data_arquivo), data_contrato=VALUES(data_contrato), valor_financiado=VALUES(valor_financiado), valor_prestacao=VALUES(valor_prestacao)");

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
            //List<CetelemContrato> contratosInsert = new List<CetelemContrato>();
            //List<CetelemContrato> contratosUpdate = new List<CetelemContrato>();
            //for (int i = 0; i < contratos.Count; i ++)
            //{
            //    if (contratos[i].processo.Substring(0, 1) == "E")
            //        contratosInsert.Add(contratos[i]);
            //    else if (contratos[i].processo.Substring(0, 1) == "R")
            //        contratosUpdate.Add(contratos[i]);
            //}

            //for (int i = 0; i < contratosInsert.Count; i += 5000)
            //{
            //    StringBuilder query = new StringBuilder("INSERT INTO `itsp`.`cetelem_contrato`" +
            //    "(`data_arquivo`, `contrato`, `processo`, `nome_loja`," +
            //    "`data_contrato`, `valor_financiado`, `valor_prestacao`, `uf`, `telefone`," +
            //    "`nome_empresa`, `telefone_com`, `telefone1_res`, `telefone2_res`, " +
            //    "`celular`, `email`)" +
            //    " VALUES ");

            //    using (MySqlConnection mConnection = new MySqlConnection(_Global.ConnectionString))
            //    {

            //        List<string> Rows = new List<string>();

            //        for (int j = 0; j < 5000; j++)
            //        {
            //            if (i + j >= contratosInsert.Count)
            //                break;

            //            Rows.Add(string.Format("({0},{1}, {2},{3}, {4},{5}, {6},{7}, {8},{9}, {10},{11}, {12},{13}, {14})",
            //            MySqlHelper.EscapeString(CheckDateNull(contratosInsert[j+i].data_arquivo)),
            //            MySqlHelper.EscapeString(CheckStrNull(contratosInsert[j+i].contrato)),
            //            MySqlHelper.EscapeString(CheckStrNull(contratosInsert[j+i].processo)),
            //            MySqlHelper.EscapeString(CheckStrNull(contratosInsert[j+i].nome_loja)),
            //            MySqlHelper.EscapeString(CheckDateNull(contratosInsert[j+i].data_contrato)),
            //            MySqlHelper.EscapeString(contratosInsert[j+i].valor_financiado.ToString("F", CultureInfo.InvariantCulture)),
            //            MySqlHelper.EscapeString(contratosInsert[j+i].valor_prestacao.ToString("F", CultureInfo.InvariantCulture)),
            //            MySqlHelper.EscapeString(CheckStrNull(contratosInsert[j+i].uf)),
            //            MySqlHelper.EscapeString(CheckStrNull(contratosInsert[j+i].telefone)),
            //            MySqlHelper.EscapeString(CheckStrNull(contratosInsert[j+i].nome_empresa)),
            //            MySqlHelper.EscapeString(CheckStrNull(contratosInsert[j+i].telefone_com)),
            //            MySqlHelper.EscapeString(CheckStrNull(contratosInsert[j+i].telefone1_res)),
            //            MySqlHelper.EscapeString(CheckStrNull(contratosInsert[j+i].telefone2_res)),
            //            MySqlHelper.EscapeString(CheckStrNull(contratosInsert[j+i].celular)),
            //            MySqlHelper.EscapeString(CheckStrNull(contratosInsert[j+i].email))));

            //        }

            //        query.Append(string.Join(','.ToString(), Rows));
            //        query.Replace(@"\", string.Empty);
            //        //query.Append(" ON DUPLICATE KEY UPDATE processo='" + MySqlHelper.EscapeString(CheckStrNull(contratosInsert[j + i].processo)) + "'");

            //        try
            //        {
            //            mConnection.Open();
            //            using (MySqlCommand myCmd = new MySqlCommand(query.ToString(), mConnection))
            //            {
            //                myCmd.ExecuteNonQuery();
            //            }
            //        }
            //        catch (MySqlException ex)
            //        {
            //            Console.WriteLine($"**********ERRO: " + ex);
            //            //Console.WriteLine($"**********ERRO: " + query.ToString());
            //        }
            //        finally
            //        {
            //            mConnection.Close();
            //        }
            //    }
            //}



            //    for (int i = 0; i < contratosUpdate.Count; i += 5000)
            //    {
            //        StringBuilder query = new StringBuilder();

            //        using (MySqlConnection mConnection = new MySqlConnection(_Global.ConnectionString))
            //        {

            //            List<string> Rows = new List<string>();

            //            for (int j = 0; j < 5000; j++)
            //            {
            //                if (i + j >= contratosUpdate.Count)
            //                    break;


            //                Rows.Add(string.Format("UPDATE `itsp`.`cetelem_contrato` SET `data_arquivo`= {0}, `contrato` = {1}, `processo` = {2}, `nome_loja` = {3}, `data_contrato` =  {4}, `valor_financiado` = {5}, `valor_prestacao` = {6}, `uf` = {7}, `telefone` =  {8}, `nome_empresa` = {9}, `telefone_com` =  {10}, `telefone1_res` = {11}, `telefone2_res` =  {12}, `celular` = {13}, `email` =  {14} WHERE `contrato` = {1}; ",
            //                MySqlHelper.EscapeString(CheckDateNull(contratosUpdate[j+i].data_arquivo)),
            //                MySqlHelper.EscapeString(CheckStrNull(contratosUpdate[j+i].contrato)),
            //                MySqlHelper.EscapeString(CheckStrNull(contratosUpdate[j+i].processo)),
            //                MySqlHelper.EscapeString(CheckStrNull(contratosUpdate[j+i].nome_loja)),
            //                MySqlHelper.EscapeString(CheckDateNull(contratosUpdate[j+i].data_contrato)),
            //                MySqlHelper.EscapeString(contratosUpdate[j+i].valor_financiado.ToString("F", CultureInfo.InvariantCulture)),
            //                MySqlHelper.EscapeString(contratosUpdate[j+i].valor_prestacao.ToString("F", CultureInfo.InvariantCulture)),
            //                MySqlHelper.EscapeString(CheckStrNull(contratosUpdate[j+i].uf)),
            //                MySqlHelper.EscapeString(CheckStrNull(contratosUpdate[j+i].telefone)),
            //                MySqlHelper.EscapeString(CheckStrNull(contratosUpdate[j+i].nome_empresa)),
            //                MySqlHelper.EscapeString(CheckStrNull(contratosUpdate[j+i].telefone_com)),
            //                MySqlHelper.EscapeString(CheckStrNull(contratosUpdate[j+i].telefone1_res)),
            //                MySqlHelper.EscapeString(CheckStrNull(contratosUpdate[j+i].telefone2_res)),
            //                MySqlHelper.EscapeString(CheckStrNull(contratosUpdate[j+i].celular)),
            //                MySqlHelper.EscapeString(CheckStrNull(contratosUpdate[j+i].email))));

            //            }

            //            query.Append(string.Join("", Rows));
            //            query.Replace(@"\", string.Empty);

            //            try
            //            {
            //                mConnection.Open();
            //                using (MySqlCommand myCmd = new MySqlCommand(query.ToString(), mConnection))
            //                {
            //                    myCmd.ExecuteNonQuery();
            //                }
            //            }
            //            catch (MySqlException ex)
            //            {
            //                Console.WriteLine($"**********ERRO: " + ex);
            //                //Console.WriteLine($"**********ERRO: " + query.ToString());
            //            }
            //            finally
            //            {
            //                mConnection.Close();
            //            }
            //        }
            //    }
        }

        private static void InsertParcela(List<CetelemParcela> parcelas)
        {

            for (int i = 0; i < parcelas.Count; i += 5000)
            {
                StringBuilder query = new StringBuilder("INSERT INTO `itsp`.`cetelem_parcela`" +
                    "(`data_arquivo`, `contrato`, `valor_original`, `data_vencimento`,`data_pagamento`," +
                    "`valor_pagamento`, `processo`, `data_ultimo_vencimento`, `valor_principal`, `codigo_parcela`)" +
                    " VALUES ");

                using (MySqlConnection mConnection = new MySqlConnection(_Global.ConnectionString))
                {

                    List<string> Rows = new List<string>();

                    for (int j = 0; j < 5000; j++)
                    {
                        if (i + j >= parcelas.Count)
                            break;

                        Rows.Add(string.Format("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9})",
                        MySqlHelper.EscapeString(CheckDateNull(parcelas[j + i].data_arquivo)),
                        MySqlHelper.EscapeString(CheckStrNull(parcelas[j + i].contrato)),
                        MySqlHelper.EscapeString(parcelas[j + i].valor_original.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(CheckDateNull(parcelas[j + i].data_vencimento)),
                        MySqlHelper.EscapeString(CheckDateNull(parcelas[j + i].data_pagamento)),
                        MySqlHelper.EscapeString(parcelas[j + i].valor_pagamento.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(CheckStrNull(parcelas[j + i].processo)),
                        MySqlHelper.EscapeString(CheckDateNull(parcelas[j + i].data_ultimo_vencimento)),
                        MySqlHelper.EscapeString(parcelas[j + i].valor_principal.ToString("F", CultureInfo.InvariantCulture)),
                        MySqlHelper.EscapeString(parcelas[j + i].codigo_parcela.ToString())));

                    }

                    query.Append(string.Join(','.ToString(), Rows));
                    query.Replace(@"\", string.Empty);
                    query.Append(" ON DUPLICATE KEY UPDATE processo = VALUES(processo), data_arquivo = VALUES(data_arquivo), valor_original=VALUES(valor_original), data_vencimento=VALUES(data_vencimento), data_pagamento=VALUES(data_pagamento), valor_pagamento=VALUES(valor_pagamento), data_ultimo_vencimento=VALUES(data_ultimo_vencimento), valor_principal=VALUES(valor_principal)");

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

            //List<CetelemParcela> parcelasInsert = new List<CetelemParcela>();
            //List<CetelemParcela> parcelasUpdate = new List<CetelemParcela>();

            //for (int i = 0; i < parcelas.Count; i++)
            //{
            //    if (parcelas[i].processo.Substring(0, 1) == "E")
            //        parcelasInsert.Add(parcelas[i]);
            //    else if (parcelas[i].processo.Substring(0, 1) == "R")
            //        parcelasUpdate.Add(parcelas[i]);
            //}


            //for (int i = 0; i < parcelasInsert.Count; i += 5000)
            //{
            //    StringBuilder query = new StringBuilder("INSERT INTO `itsp`.`cetelem_parcela`" +
            //        "(`data_arquivo`, `contrato`, `valor_original`, `data_vencimento`,`data_pagamento`," +
            //        "`valor_pagamento`, `processo`, `data_ultimo_vencimento`, `valor_principal`, `codigo_parcela`)" +
            //        " VALUES ");

            //    using (MySqlConnection mConnection = new MySqlConnection(_Global.ConnectionString))
            //    {

            //        List<string> Rows = new List<string>();

            //        for (int j = 0; j < 5000; j++)
            //        {
            //            if (i + j >= parcelasInsert.Count)
            //                break;

            //            Rows.Add(string.Format("({0},{1}, {2},{3}, {4},{5}, {6},{7}, {8}, {9})",
            //            MySqlHelper.EscapeString(CheckDateNull(parcelasInsert[j+i].data_arquivo)),
            //            MySqlHelper.EscapeString(CheckStrNull(parcelasInsert[j+i].contrato)),
            //            MySqlHelper.EscapeString(parcelasInsert[j+i].valor_original.ToString("F", CultureInfo.InvariantCulture)),
            //            MySqlHelper.EscapeString(CheckDateNull(parcelasInsert[j+i].data_vencimento)),
            //            MySqlHelper.EscapeString(CheckDateNull(parcelasInsert[j+i].data_pagamento)),
            //            MySqlHelper.EscapeString(parcelasInsert[j+i].valor_pagamento.ToString("F", CultureInfo.InvariantCulture)),
            //            MySqlHelper.EscapeString(CheckStrNull(parcelasInsert[j+i].processo)),
            //            MySqlHelper.EscapeString(CheckDateNull(parcelasInsert[j+i].data_ultimo_vencimento)),
            //            MySqlHelper.EscapeString(parcelasInsert[j+i].valor_principal.ToString("F", CultureInfo.InvariantCulture)),
            //            MySqlHelper.EscapeString(parcelasInsert[j+i].codigo_parcela.ToString())));

            //        }

            //        query.Append(string.Join(','.ToString(), Rows));
            //        query.Replace(@"\", string.Empty);

            //        try
            //        {
            //            mConnection.Open();
            //            using (MySqlCommand myCmd = new MySqlCommand(query.ToString(), mConnection))
            //            {
            //                myCmd.ExecuteNonQuery();
            //            }
            //        }
            //        catch (MySqlException ex)
            //        {
            //            Console.WriteLine($"**********ERRO: " + ex);
            //            //Console.WriteLine($"**********ERRO: " + query.ToString());
            //        }
            //        finally
            //        {
            //            mConnection.Close();
            //        }
            //    }
            //}


            //    for (int i = 0; i < parcelasUpdate.Count; i += 5000)
            //    {
            //        StringBuilder query = new StringBuilder();

            //        using (MySqlConnection mConnection = new MySqlConnection(_Global.ConnectionString))
            //        {

            //            List<string> Rows = new List<string>();

            //            for (int j = 0; j < 5000; j++)
            //            {
            //                if (i + j >= parcelasUpdate.Count)
            //                    break;


            //                Rows.Add(string.Format("UPDATE `itsp`.`cetelem_parcela` SET `data_arquivo`= {0}, `contrato` = {1}, `valor_original` = {2}, `data_vencimento` = {3}, `data_pagamento` =  {4}, `valor_pagamento` = {5}, `processo` = {6}, `data_ultimo_vencimento` = {7}, `valor_principal` =  {8}, `codigo_parcela` = {9} WHERE `contrato` = {1} AND `codigo_parcela` = {9} ",
            //                MySqlHelper.EscapeString(CheckDateNull(parcelasUpdate[j+i].data_arquivo)),
            //                MySqlHelper.EscapeString(CheckStrNull(parcelasUpdate[j+i].contrato)),
            //                MySqlHelper.EscapeString(parcelasUpdate[j+i].valor_original.ToString("F", CultureInfo.InvariantCulture)),
            //                MySqlHelper.EscapeString(CheckDateNull(parcelasUpdate[j+i].data_vencimento)),
            //                MySqlHelper.EscapeString(CheckDateNull(parcelasUpdate[j+i].data_pagamento)),
            //                MySqlHelper.EscapeString(parcelasUpdate[j+i].valor_pagamento.ToString("F", CultureInfo.InvariantCulture)),
            //                MySqlHelper.EscapeString(CheckStrNull(parcelasUpdate[j+i].processo)),
            //                MySqlHelper.EscapeString(CheckDateNull(parcelasUpdate[j+i].data_ultimo_vencimento)),
            //                MySqlHelper.EscapeString(parcelasUpdate[j+i].valor_principal.ToString("F", CultureInfo.InvariantCulture)),
            //                MySqlHelper.EscapeString(parcelasUpdate[j+i].codigo_parcela.ToString())));

            //}

            //            query.Append(string.Join("", Rows));
            //            query.Replace(@"\", string.Empty);

            //            try
            //            {
            //                mConnection.Open();
            //                using (MySqlCommand myCmd = new MySqlCommand(query.ToString(), mConnection))
            //                {
            //                    myCmd.ExecuteNonQuery();
            //                }
            //            }
            //            catch (MySqlException ex)
            //            {
            //                Console.WriteLine($"**********ERRO: " + ex);
            //                //Console.WriteLine($"**********ERRO: " + query.ToString());
            //            }
            //            finally
            //            {
            //                mConnection.Close();
            //            }
            //        }
            //    }


        }

    }

}

