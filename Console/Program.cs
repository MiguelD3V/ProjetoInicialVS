using System.Text.RegularExpressions;
using System.Threading.Channels;
using ProjetoInicialVS.Controllers;
using ProjetoInicialVS.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Menu menu = new Menu();
        bool continuar = true;
    
       

        while (continuar)
        {
            Menu.limpaTela();
            menu.exibirMenu();
            menu.opcoesDoMenu();

            Console.WriteLine("Digite sua opção:");
            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    CadastrarPaciente.ExecutarCadastro();
                    break;
                case 2:
                    ExibirPaciente.ExecutarConsulta();
                    break;
                case 3:
                    DeletarPaciente.ExecutarDelecao();
                    break;
                case 4:
                    AlterarPaciente.ExecutarAlteracao();
                    break;
                case -1:
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção invalida...");
                    break;
            }
        
         if (continuar)
            {
                Console.WriteLine("Digite QUalquer tecla...");
                Console.ReadKey();
            }
        
        }    
    }
}

class Menu
{
    //Exibe o logo do sistema
    public void exibirMenu()
    {
        Console.WriteLine(" ______             _                        ______  _______  _____  \r\n(_____ \\           (_)             _        (_____ \\(_______)(_____) \r\n _____) )____  ____ _ _____ ____ _| |_ _____ _____) )______  _  __ _ \r\n|  ____(____ |/ ___) | ___ |  _ (_   _) ___ (_____ (|  ___ \\| |/ /| |\r\n| |    / ___ ( (___| | ____| | | || |_| ____|_____) ) |___) )   /_| |\r\n|_|    \\_____|\\____)_|_____)_| |_| \\__)_____|______/|______/ \\_____/ ");
        Console.WriteLine("*******************************************************************\n                 BEM VINDO(A) AO PACIENTE360\n*******************************************************************");
    }
    
    //Exibe as opções disponiveis
    public void opcoesDoMenu()
    {
        {

            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine("1 - Cadastrar paciente");
            Console.WriteLine("2 - Consultar paciente");
            Console.WriteLine("3 - Deletar paciente");
            Console.WriteLine("4 - Alterar paciente");
            Console.WriteLine("-1 - Sair");

        }
    }
    public static void limpaTela()
    {
        Console.Clear();
    }
}

