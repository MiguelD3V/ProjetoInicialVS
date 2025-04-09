using System.Threading.Channels;

internal class Program
{
    private static void Main(string[] args)
    {
        Menu menu = new Menu();
        bool continuar = true;
        /*
         Validar se as informações estão ok
         Verificar se o paciente está cadastrado
         Inserir no banco de dados
         */
       

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
 static class TbPaciente
{
    private static List<Paciente> _pacientes = [];
    public static void Inserir(Paciente paciente)
    {
        _pacientes.Add(paciente);
    }

    public static void Deletar(int id)
    {
        var indx = _pacientes.FindIndex(p => p.Id == id);
        _pacientes.RemoveRange(indx, 1);
    }

    public static void Atualizar(Paciente paciente)
    {
        var indx = _pacientes.FindIndex(p => p.Id == paciente.Id);
        _pacientes[indx] = paciente;
    }

    public static Paciente? Buscar(Predicate<Paciente> predicado)
    {
        return _pacientes.Find(predicado);

    }
}

class Paciente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public  int Idade { get; set; }
    public string Logradouro { get; set; }
    public int Numero { get; set; }
    public string Email { get; set; }

}


class Menu
{
    public void exibirMenu()
    {
        Console.WriteLine(" ______             _                        ______  _______  _____  \r\n(_____ \\           (_)             _        (_____ \\(_______)(_____) \r\n _____) )____  ____ _ _____ ____ _| |_ _____ _____) )______  _  __ _ \r\n|  ____(____ |/ ___) | ___ |  _ (_   _) ___ (_____ (|  ___ \\| |/ /| |\r\n| |    / ___ ( (___| | ____| | | || |_| ____|_____) ) |___) )   /_| |\r\n|_|    \\_____|\\____)_|_____)_| |_| \\__)_____|______/|______/ \\_____/ ");
        Console.WriteLine("*******************************************************************\n                 BEM VINDO(A) AO PACIENTE360\n*******************************************************************");
    }

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

class CadastrarPaciente : Menu
{
    public static void ValidaCadastro()
    {
        
    }

    public static void ExecutarCadastro()
    {
        limpaTela();
        Console.WriteLine("\n*** Cadastro de Paciente ***");

        Paciente paciente = new Paciente();

        Console.Write("ID: ");
        paciente.Id = int.Parse(Console.ReadLine());

        Console.Write("Nome: ");
        paciente.Nome = Console.ReadLine();

        Console.Write("Idade: ");
        paciente.Idade = int.Parse(Console.ReadLine());

        Console.Write("Logradouro: ");
        paciente.Logradouro = Console.ReadLine();

        Console.Write("Rua (número): ");
        paciente.Numero = int.Parse(Console.ReadLine());

        Console.Write("Email: ");
        paciente.Email = Console.ReadLine();

        TbPaciente.Inserir(paciente);

        Console.WriteLine("Paciente cadastrado com sucesso!");
    }
}

class ExibirPaciente : Menu
{
    public static void ExecutarConsulta()
    {
        limpaTela();
        Console.WriteLine("\n*** Cadastro de Paciente ***");

        Console.WriteLine("Digite o ID do Paciente Desejado:");
        int id = int.Parse(Console.ReadLine());

        var paciente =  TbPaciente.Buscar(p => p.Id == id);

        if(paciente != null)
        {
            Console.WriteLine($"Paciente: {paciente.Nome}");
            Console.WriteLine($"Idade: {paciente.Idade}");
            Console.WriteLine($"Endereço: {paciente.Logradouro}, {paciente.Numero}");
            Console.WriteLine($"Email: {paciente.Email}");
        }else
        {
            Console.WriteLine("Paciente não encontrado :(");
        }

    }
}

class DeletarPaciente : Menu
{
    public static void ExecutarDelecao()
    {
        limpaTela();
        Console.WriteLine("\n*** Cadastro de Paciente ***");

        Console.WriteLine("Digite o ID do Paciente Desejado:");
        int id = int.Parse(Console.ReadLine());

        TbPaciente.Deletar(id);

    }
}

class AlterarPaciente : Menu
{
    public static void ExecutarAlteracao()
    {
        limpaTela();
        Console.WriteLine("\n*** Alteração de Paciente ***");

        Console.WriteLine("Digite o ID do Paciente Desejado:");
        int id = int.Parse(Console.ReadLine());
        
        
        Paciente paciente = new Paciente();

        paciente.Id = id;

        Console.Write("Nome: ");
        paciente.Nome = Console.ReadLine();

        Console.Write("Idade: ");
        paciente.Idade = int.Parse(Console.ReadLine());

        Console.Write("Logradouro: ");
        paciente.Logradouro = Console.ReadLine();

        Console.Write("Rua (número): ");
        paciente.Numero = int.Parse(Console.ReadLine());

        Console.Write("Email: ");
        paciente.Email = Console.ReadLine();

        TbPaciente.Inserir(paciente);

        Console.WriteLine("Paciente Atualizado com sucesso!");

        TbPaciente.Atualizar(paciente);
    }
}
