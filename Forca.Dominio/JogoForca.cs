using System.Diagnostics.Metrics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Forca.Dominio
{
    public class JogoForca
    {
        private int tentativas;
        private System.String palavra = "";



        public void Menu()
        {
            int aux = 0; // aux
            bool ctrl = true; // aux to whiles
            int tema; // theeme choosen 
            int pos = 0; // we will use to run inside strings
            List<System.String> palavras = []; // where will we store the words of the csv file
            Random rnd = new (); // used to pick a random word

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

                try
                {
                    aux = int.Parse(Console.ReadLine()!);
                }
                catch
                {

                }
                if (aux == 1 || aux == 2 || aux == 3) ctrl = false; // Testing if the number of attemps entered is valid
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO: Valor invalido!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            tentativas = (8 - aux); // Assigning the value to the attribute

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

                aux = int.Parse(Console.ReadLine()!);

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
            ctrl = true;

            var csvPath = @"C:\Users\USER\source\repos\Forca\Forca.Dominio\palavras.csv"; // reading the csv file and adding the infos into a list
            using (var reader = new StreamReader(csvPath)) 
            {
                while (reader.EndOfStream == false)
                {
                    var line = reader.ReadLine()!;
                    palavras.Add(line);
                }
            }

            // the list of strings named "palavras" has the word a ";" and the n5umber of the theeme (0, 1 or 2)

            while (ctrl) // choosing a random word
            {
                pos = rnd.Next(0, palavras.Count);
                if (palavras[pos][^1].ToString() == tema.ToString()) ctrl = false; // if the randon word has the samen theeme choosen we go out of the loop

            }

            palavra = palavras[pos]; //  Assigning the value to the attribute
        }

        public void Jogar ()
        {
            System.String revelacao = ""; // the word of the game
            List<char> usedletters = []; // store in a char list which letters have already been used
            char letra;
            bool ctrl;
            int aux = 0;

            for (int i = 0; palavra[i].ToString() != ";"; i++) // the word of the games starts just with underlines
            {
                revelacao += "_ ";
            }

            while (tentativas >= 1) // the game working, only end when the user win or the tentatives go to 0
            {
                Console.WriteLine(revelacao);
                Console.WriteLine();
                Console.WriteLine("Erros restantes: " + tentativas);

                Console.WriteLine("Insira uma letra:");
                letra = char.Parse(Console.ReadLine()!);

                ctrl = true;
                for (int i = 0; i < usedletters.Count; i++) // It will test if the letter has already been tested
                {
                    if (usedletters[i] == letra)
                    {
                        ctrl = false;
                        break;
                    }
                }

                if (ctrl == true) //the letter hasn't been used so lets see if it has in the word
                {
                    bool ctrl2 = false; ;
                    usedletters.Add(letra); //add to used letters

                    for (int i = 0; palavra[i].ToString() != ";"; i++) // covering the entire word
                    {
                        if (letra.ToString().Equals(palavra[i].ToString(), StringComparison.CurrentCultureIgnoreCase)) // if the letter is the same of the word[i]
                        {
                            ctrl2 = true;
                            // Now changing the underline by the letter
                            revelacao = "";
                            for (int j = 0; palavra[j].ToString() != ";"; j++) 
                            {
                                bool ctrl3 = true;
                                for (int k = 0; k < usedletters.Count; k++)
                                    if (usedletters[k].ToString().Equals(palavra[j].ToString(), StringComparison.CurrentCultureIgnoreCase)) // if the letter is the same of the word[j]
                                    {
                                        revelacao += usedletters[k];
                                        ctrl3 = false;
                                    }
                                if(ctrl3)
                                {
                                    revelacao += "_";
                                }
                                revelacao += " ";
                            }                            
                        }
                    }
                    if (ctrl2 == false) // if the letter is not the same as any position in the word
                    {
                        Console.WriteLine("Letra inexistente");
                        Console.WriteLine();
                        tentativas--;
                    }
                }
                else // if the letter has been already used go to the beggining of the loop again
                {
                    Console.WriteLine("Erro: Letra ja testada");
                    Console.WriteLine();
                }
                aux = 0;
                for (int i = 0; i < revelacao.Length; i++)
                {
                    if (revelacao[i].ToString() == "_")
                        aux++;
                }
                if (aux == 0) tentativas = -1;
            }
            for (int i = 0; i < revelacao.Length; i++)
            {
                if (revelacao[i].ToString() == "_")
                    aux++;
            }
            if (aux == 0)
            {
                for (int i = 0; palavra[i].ToString() != ";"; i++)
                {
                    Console.Write(palavra[i]);

                }
                Console.WriteLine();
                Console.WriteLine("Parabéns! Venceu!!");
            }
            else
            {
                Console.WriteLine("Fim das tentativas. Tente novamente!");
                Console.Write("Palavra: ");
                for (int i = 0; palavra[i].ToString() != ";"; i++)
                {
                    Console.Write(palavra[i]);

                }
                Console.WriteLine();
            }
        }
    }
}
