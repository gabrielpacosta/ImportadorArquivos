using System;
using System.IO;
using ImportadorArquivos.DB;
using System.Windows.Forms;


namespace ImportadorArquivos.Controller
{
    public class CarteiraAtualController
    {
        private static readonly int MAX_BYTES = 100 * 1024 * 1024;
        public static void UploadCarteiraAtual(string file)
        {
            var size = new FileInfo(file).Length;
            if (file == null)
            {
                MessageBox.Show("Nenhum arquivo");
                return;
            }
            if (size == 0)
            {
                MessageBox.Show("Arquivo vazio");
                return;
            }
            if (size > MAX_BYTES)
            {
                MessageBox.Show("Arquivo muito grande");
                return;
            }

            // Le o arquivo na memoria
            string[] AllLines = null;
            AllLines = new string[500000]; //only allocate memory here
            // AllLines = System.IO.File.ReadAllLines(filePath, System.Text.Encoding.UTF8);
            var enc1252 =System.Text.Encoding.GetEncoding(1252);
            AllLines = System.IO.File.ReadAllLines(file, enc1252);

            DateTime start = DateTime.Now;
            DateTime end;


            CarteiraAtualDB.Insert(AllLines, file);

            end = DateTime.Now;
            Console.WriteLine("Finished at: " + end.ToLongTimeString());
            Console.WriteLine("Time: " + (end - start));
            Console.WriteLine();

            SuccessForm.linhasProcessadas = AllLines.Length.ToString("N0");
        }

    }


}
