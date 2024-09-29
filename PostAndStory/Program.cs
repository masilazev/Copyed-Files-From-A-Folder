using System;
using System.IO;

namespace PostAndStory
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Ler o caminho dos arquivos (da pasta) de origem
                string folder = @"C:\Users\mathe\Downloads\drive-download-20240927T180731Z-001";

                // Novo caminho  dos arquivos
                string newFolder = Path.Combine("C:\\Users\\mathe\\Downloads\\pasta formato story");

                // Verifica se existe a pasta que instanciamos anteriormente, caso exista lança um exceção
                if (Directory.Exists(newFolder))
                {
                    throw new IOException("A pasta 'pasta formato story' já existe.");
                }

                // Cria a nova pasta no caminho instanciado
                Directory.CreateDirectory(newFolder);
                Console.WriteLine("Pasta 'pasta formato story' criada!");

                // Vetor que pega os arquivos com qualquer nome (*) e com formato .png
                string[] files = Directory.GetFiles(folder, "*.png");

                // Ler todos os arquivos e seleciona aqueles  que tem 1080x1920 no nome (se refere ao tamanho da imagem)
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file); // Pega o nome do arquivo
                    if (fileName.Contains("1080x1920")) // Verifica os que contem 1080x1920 no nome do arquivo
                    {
                        string destFile = Path.Combine(newFolder, fileName); // Caminho de destino
                        File.Copy(file, destFile, true); // Copia o arquivo para a pasta nova
                        Console.WriteLine("Arquivo " + fileName + " copiado para 'pasta formato story'."); // Escreve
                    }
                }

                Console.WriteLine("Processo concluído."); // Escreve
            }
            catch (IOException exception) // Qualquer outra exceção
            {
                Console.WriteLine("Ocorreu um erro: " + exception.Message);
            }
        }
    }
}