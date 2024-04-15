using System.IO;
using System.Runtime.InteropServices;

namespace Forca.Dominio
{
    public class JogoForca
    {
        private int tentativas;
        private String palavra;


        public void Menu()
        {
            int aux = 0; // aux
            bool ctrl = true; // aux to whiles
            int tema; // theeme choosen 
            int pos = 0; // we will use to run inside strings
            List<String> palavras = new List<String>(); // where will we store the words of the csv file
            Random rnd = new Random(); // used to pick a random word

            Console.WriteLine("Bem vindo a Forca!");

            while (ctrl) // picking the value of tentatives
            {
                /*
                 * three options to attempts (int tentativas):
                 * easy -> 7 attempts (1)
                 * medium -> 6 attempts (2)
                 * hard -> 5 attempts  (3)
                 */
                Console.WriteLine("Escolha uma dificuldade:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" 1 - Facil (7 tentativas)");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" 2 - Normal (6 tentativas)");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" 3 - Dificil (5 tentativas)");
                Console.ForegroundColor = ConsoleColor.White;

                aux = int.Parse(Console.ReadLine());

                if (aux == 1 || aux == 2 || aux == 3) ctrl = false; // Testing if the number of attemps entered is valid
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO: Valor invalido!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            tentativas = aux; // Assigning the value to the attribute

            // resetting the auxiliares
            aux = 0;
            ctrl = true;


            while (ctrl) //Picking the value of theeme
            {
                /*
                 * Three options to theeme (int tema):
                 * Movies (1)
                 * Cars (2)
                 * Countries (3)  
                 */
                Console.WriteLine("Escolha um tema:");
                Console.WriteLine(" 1 - Filmes");
                Console.WriteLine(" 2 - Carros");
                Console.WriteLine(" 3 - Paises");

                aux = int.Parse(Console.ReadLine());

                if (aux == 1 || aux == 2 || aux == 3) ctrl = false; // Testing if the number entered is valid
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO: Valor invalido!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            tema = aux - 1; // Assigning the value to the attribute (-1 because in the csv file movie is 0, 6cars 1 and countries 2)

            // resetting the auxiliares
            aux = 0;
            ctrl = true;

            var csvPath = @"C:\Users\USER\source\repos\Forca\Forca.Dominio\palavras.csv"; // reading the csv file and adding the infos into a list
            using (var reader = new StreamReader(csvPath)) 
            {
                while (reader.EndOfStream == false)
                {
                    var line = reader.ReadLine();
                    palavras.Add(line);
                }
            }

            // the list of strings named "palavras" has the word a ";" and the number of the theeme (0, 1 or 2)

            while (ctrl) // choosing a random word
            {
                pos = rnd.Next(0, palavras.Count);
                if (palavras[pos][palavras[pos].Length - 1].ToString() == tema.ToString()) ctrl = false; // if the randon word has the samen theeme choosen we go out of the loop

            }

            palavra = palavras[pos]; //  Assigning the value to the attribute
        }

        public void Jogar ()
        {
            String revelacao = "";
            String usedwords = "";
            char letra;
            bool ctrl;

            for (int i = 0; palavra[i].ToString() != ";"; i++)
            {
                revelacao += "_ ";
            }

            Console.WriteLine("EXTRA: " + palavra);
            Console.WriteLine();

            while (tentativas > 1)
            {
                Console.WriteLine(revelacao);
                Console.WriteLine();
                Console.WriteLine("Erros restantes: " + tentativas);

                Console.WriteLine("Insira uma letra:");
                letra = char.Parse(Console.ReadLine());

                ctrl = true;
                for (int i = 0; i < usedwords.Length; i++)
                {
                    if (usedwords[i] == letra)
                    {
                        ctrl = false;
                        break;
                    }
                }

                if (ctrl == true)
                {
                    usedwords += letra;
                }
                else
                {
                    Console.WriteLine("Erro: Letra ja testada");
                }


            }
        }

        private void RetirarTentativa ()
        {
            tentativas--;
        }
    }
}
