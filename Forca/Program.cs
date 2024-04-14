using Forca.Dominio;
using System;

namespace App // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JogoForca forca = new JogoForca();
            forca.Menu();
            forca.Jogar();  
        }
    }
}