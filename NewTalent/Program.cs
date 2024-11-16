using System;
using NewTalent;

namespace TestNewTalent
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo à Calculadora!");
            Console.WriteLine("Data atual: 02/02/2024");

            Calculadora calc = new Calculadora("02/02/2024");

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\nEscolha uma operação:");
                Console.WriteLine("1. Somar");
                Console.WriteLine("2. Subtrair");
                Console.WriteLine("3. Multiplicar");
                Console.WriteLine("4. Dividir");
                Console.WriteLine("5. Ver histórico");
                Console.WriteLine("6. Sair");
                Console.Write("Opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ExecutarOperacao(calc, "somar");
                        break;
                    case "2":
                        ExecutarOperacao(calc, "subtrair");
                        break;
                    case "3":
                        ExecutarOperacao(calc, "multiplicar");
                        break;
                    case "4":
                        ExecutarOperacao(calc, "dividir");
                        break;
                    case "5":
                        ExibirHistorico(calc);
                        break;
                    case "6":
                        continuar = false;
                        Console.WriteLine("Encerrando a calculadora. Até mais!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }
            }
        }

        static void ExecutarOperacao(Calculadora calc, string operacao)
        {
            try
            {
                Console.Write("Digite o primeiro número: ");
                int val1 = int.Parse(Console.ReadLine());

                Console.Write("Digite o segundo número: ");
                int val2 = int.Parse(Console.ReadLine());

                int resultado = operacao switch
                {
                    "somar" => calc.Somar(val1, val2),
                    "subtrair" => calc.Subtrair(val1, val2),
                    "multiplicar" => calc.Multiplicar(val1, val2),
                    "dividir" => calc.Dividir(val1, val2),
                    _ => throw new InvalidOperationException("Operação inválida")
                };

                Console.WriteLine($"Resultado da {operacao}: {resultado}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Erro: Não é possível dividir por zero!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Entrada inválida! Digite números inteiros.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
        }

        static void ExibirHistorico(Calculadora calc)
        {
            Console.WriteLine("\nHistórico das últimas operações:");
            var historico = calc.historico();

            if (historico.Count == 0)
            {
                Console.WriteLine("Nenhuma operação registrada.");
            }
            else
            {
                foreach (var entrada in historico)
                {
                    Console.WriteLine(entrada);
                }
            }
        }
    }
}
