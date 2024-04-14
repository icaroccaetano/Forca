using System.IO;

namespace Forca.Dominio
{
    public class JogoForca
    {
        private int tentativas;
        private String palavra;
        

        public void Menu()
        {
            int aux = 0;
            bool ctrl = true;
            int tema, pos=0;
            List<String> palavras = new List<String>();
            Random rnd = new Random();

            Console.WriteLine("Bem vindo a Forca!");

            while (ctrl)
            {
                Console.WriteLine("Escolha uma dificuldade:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" 1 - Facil (7 tentativas)");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" 2 - Normal (6 tentativas)");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" 3 - Dificil (5 tentativas)");

                aux = int.Parse(Console.ReadLine());

                if (aux == 1 || aux == 2 || aux == 3) ctrl = false;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO: Valor invalido!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            tentativas = aux;

            aux = 0;
            ctrl = true;


            while (ctrl)
            {
                Console.WriteLine("Escolha um tema:");
                Console.WriteLine(" 1 - Filmes");
                Console.WriteLine(" 2 - Carros");
                Console.WriteLine(" 3 - Paises");

                aux = int.Parse(Console.ReadLine());

                if (aux == 1 || aux == 2 || aux == 3) ctrl = false;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO: Valor invalido!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            tema = aux - 1;

            var csvPath = @"C:\Users\USER\source\repos\Forca\Forca.Dominio\palavras.csv";
            using (var reader = new StreamReader(csvPath))
            {
                while (reader.EndOfStream == false)
                {
                    var line = reader.ReadLine();
                    palavras.Add(line);
                }
            }
            for (int i = 0; i < palavras.Count; i++)
            {
                Console.WriteLine(palavras[i]);
            }

            ctrl = true;

            while ( ctrl )
            {
                pos = rnd.Next(0, palavras.Count);
                if (palavras[pos][palavras[pos].Length - 1] == tema) ctrl = false;
            }

            Console.WriteLine(palavra[pos]);


        }  

        private void RetirarTentativa ()
        {
            tentativas--;
        }
    }
}
