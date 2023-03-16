using System;

namespace CalculadoraDeImc
{
    public class CalculadoraImc
    {

        int Opcao { get; set; }
        string Texto { get; set; }
        float Peso { get; set; }
        float Altura { get; set; }
        float Resultado { get; set; }

        public CalculadoraImc()
        {
            this.Texto = "";
            this.Peso = Peso;
            this.Altura = Altura;
            this.Resultado = Resultado;
        }

        public void Menu()
        {
            Console.Clear();

            Console.WriteLine("Calculadora de IMC");
            Console.WriteLine("Digite uma das opções abaixo: ");
            Console.WriteLine("1 - Criar novo arquivo");
            Console.WriteLine("2 - Abrir arquivo");
            Console.WriteLine("3 - Sair");
            Opcao = int.Parse(Console.ReadLine());

            switch(Opcao)
            {
                case 1: Criar(); break;
                case 2: Abrir();  break;
                case 3: System.Environment.Exit(0); break;
                default: Menu(); break;
            }

            Menu();
        }

        public void Criar()
        {
            Console.Clear();

            Console.WriteLine("Digite seu nome: ");
            Texto += "Nome: ";
            Texto += Console.ReadLine();
            Texto += Environment.NewLine;
            
            Console.WriteLine("Digite sua altura usando números e vírgula(ex: 1,75): ");
            Altura = float.Parse(Console.ReadLine());
            Texto += "Altura: " + Altura;
            Texto += Environment.NewLine;

            Console.WriteLine("Digite seu peso usando números e vírgula(ex: 56,7): ");
            Peso = float.Parse(Console.ReadLine());
            Texto += "Peso: " + Peso;
            Texto += Environment.NewLine;

            Resultado = Peso / (Altura * Altura);
            Texto += "IMC: " + Resultado;
            Texto += Environment.NewLine;

            TabelaImc(Resultado);

            Salvar(Texto);
        }

        public void Abrir()
        {
            Console.Clear();

            Console.WriteLine("Digite o caminho do arquivo que deseja abrir: ");
            var Caminho = Console.ReadLine();

            using(var Arquivo = new StreamReader(Caminho))
            {
                string Texto = Arquivo.ReadToEnd();
                Console.WriteLine(Texto);
            }

            Console.WriteLine("\nDigite ENTER para sair");
            Console.ReadKey();
        }

        public void Salvar(string Texto)
        {
            Console.Clear();

            Console.WriteLine("Digite o caminho que deseja salvar o arquivo: ");
            var Caminho = Console.ReadLine();

            using(var Arquivo = new StreamWriter(Caminho))
            {
                Arquivo.Write(Texto);
            }
        }

        public void TabelaImc(float Resultado)
        {
            Console.Clear();

            if(Resultado < 17)
            {
                Texto += "Muito abaixo do peso.";
            }
            else if(Resultado >= 17 && Resultado <= 18.49)
            {
                Texto += "Abaixo do peso.";
            }
            else if(Resultado >= 18.5 && Resultado <= 24.99)
            {
                Texto += "Peso normal";
            }
            else if(Resultado >= 25 && Resultado <= 29.99)
            {
                Texto += "Acima do peso";
            }
            else if(Resultado >= 30 && Resultado <= 34.99)
            {
                Texto += "Obesidade I";
            }
            else if(Resultado >= 35 && Resultado <= 39.99)
            {
                Texto += "Obesidade II";
            }
            else if(Resultado >= 40)
            {
                Texto += "Obesidade III";
            }
        }
    }
}
