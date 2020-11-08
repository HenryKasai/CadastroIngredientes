using System;
using CadastroIngredientes.db;

namespace CadastroIngredientes
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new hamburgueriaContext())
            {
                bool finalizar = false;
                while (!finalizar)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Digite o nome do novo ingrediente: ");
                    string nome = Console.ReadLine();
                    Console.Write($"O ingrediente {nome} é do tipo 1, 2 ou 3? ");
                    int tipo = Convert.ToInt32(Console.ReadLine());

                    if (tipo != 1 && tipo != 2 && tipo != 3) 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Valor Inválido");
                    }
                    else
                    {
                        var novoIngrediente = new Ingrediente
                        {
                            Id = Guid.NewGuid().ToString(),
                            Nome = nome,
                            TipoIngredienteId = tipo,
                        };

                        db.Ingrediente.Add(novoIngrediente);
                        db.SaveChanges();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Ingrediente inserido no banco de dados, aperte uma tecla para encerrar o programa.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.ReadKey();
                        finalizar = true;
                    }
                }
            }
        }
    }
}
