using System;
using System.IO;
using System.Text;

class MainClass {
  public static void Main (string[] args) {

     Console.Clear();

    //Menu de login 
    string menuLogin;
    bool telaLogin = true;

    while(telaLogin == true){

      Console.WriteLine(" ");

      Console.WriteLine("╔═════════════MENU DE OPÇÕES═════════════╗    ");

      Console.WriteLine("║ 1 - ENTRAR NO APP                      ║    ");

      Console.WriteLine("║                                        ║    ");

      Console.WriteLine("║ 2 - FAZER CADASTRO                     ║    ");

      Console.WriteLine("║                                        ║    ");

      Console.WriteLine("║ 3 - FECHAR                             ║    ");

      Console.WriteLine("╚════════════════════════════════════════╝    ");

      Console.WriteLine(" ");

      Console.Write("Escolha uma opção: ");

      menuLogin = Console.ReadLine();
      Console.Clear();
      Console.WriteLine(" ");

      //Opções do menu
      switch(menuLogin){

        //Fazer login
        case "1":
        break;

        //Cadastro da pessoa
        case "2":
        string nome;
        string nomeDeUsuario;
        string nomeDaPasta;
        string senha;
        string telefone;
        string email;
        string caminhoBD;

        Console.WriteLine("CADASTRO DE USUARIO\n");

        Console.WriteLine("Digite seu nome: ");
        nome = Console.ReadLine();

        Console.WriteLine("Digite o seu nome de usuario: ");
        nomeDeUsuario = Console.ReadLine();

        Console.WriteLine("Digite sua senha: ");
        senha = Console.ReadLine();

        Console.WriteLine("Digite seu telefone: ");
        telefone = Console.ReadLine();

        Console.WriteLine("Digite seu email: ");
        email = Console.ReadLine();

        nomeDaPasta = "BD " + nomeDeUsuario;

        caminhoBD = ".//"+ nomeDaPasta +"//";

        //Cria a pasta para salvar os arquivos da conta.
        DirectoryInfo di = Directory.CreateDirectory(nomeDaPasta);

        StreamWriter sw = new StreamWriter(caminhoBD + "dados.txt", true);

        sw.WriteLine(nome+"\n"+nomeDeUsuario+"\n"+senha+"\n"+telefone+"\n"+email+"\n"+caminhoBD);

        sw.Close();

        Pessoa cadastro = new Pessoa(nome, nomeDeUsuario, senha, telefone, email, caminhoBD);
        break;

        //Fecha o app
        case "3":
        telaLogin = false;
        break;

        //Caso não seja nenhuma das opções acima
        default:
        Console.WriteLine("Opção invalida...");
        break;
      }
    }  

    Console.Clear();

    //Menu do usuario
    string menu;
    bool repetir = true;

    
    Armario armario = new Armario();
    Item item = new Item();
    Lixeira lixeira = new Lixeira();

    while(repetir == true){

      Console.WriteLine(" ");

      Console.WriteLine("╔═════════════MENU DE OPÇÕES═════════════╗    ");

      Console.WriteLine("║ 1 - DADOS DO USUARIO                   ║    ");

      Console.WriteLine("║                                        ║    ");

      Console.WriteLine("║ 2 - CADASTRO DE ITENS                  ║    ");

      Console.WriteLine("║                                        ║    ");

      Console.WriteLine("║ 3 - CHECAR ARMARIO                     ║    ");

      Console.WriteLine("║                                        ║    ");

      Console.WriteLine("║ 4 - JOGAR ITEM NO LIXO                 ║    ");

      Console.WriteLine("║                                        ║    ");

      Console.WriteLine("║ 5 - LIMPAR CONSOLE                     ║    ");
      
      Console.WriteLine("║                                        ║    ");

      Console.WriteLine("║ 6 - SAIR                               ║    ");

      Console.WriteLine("╚════════════════════════════════════════╝    ");

      Console.WriteLine(" ");

      Console.Write("Escolha uma opção: ");

      menu = Console.ReadLine();
      Console.Clear();
      Console.WriteLine(" ");

      //Opções do menu
      switch(menu){

        //Mostra os dados de cadastro do usuario
        case "1":
        break;

        //Cadastro dos itens
        case "2":
        item.EscreverItem();
        break;

        //Lê uma lista de itens e adciona ao armario
        case "3":
        armario.AdicionarItens();
        armario.SaidaLista();
        break;

        //Simula itens que foram jogados para a lixeira
        case "4":
        lixeira.SaidaLixeira();
        break;

        //Limpa o console
        case "5":
        Console.Clear();
        break;

        //Sai do programa
        case "6":
        Console.WriteLine("Saindo...");
        repetir = false;
        break;

        //Caso não seja nenhuma das opções acima
        default:
        Console.WriteLine("Opção invalida...");
        break;
      }
    }  
  }
}