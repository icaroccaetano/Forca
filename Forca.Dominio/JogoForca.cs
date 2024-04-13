using System.IO;

namespace Forca.Dominio
{
    public class JogoForca
    {
        private int tentativas;
        private String palavra;

        public void Menu () 
        {
            int aux = 0;
            bool ctrl = true;

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

            using (var reader = new StreamReader(@"C:\palavras.csv"))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    listA.Add(values[1]);
                    listB.Add(values[0]);
                }
            }

        }

        private void RetirarTentativa ()
        {
            tentativas--;
        }
    }
}
