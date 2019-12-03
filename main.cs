using System;
using System.IO;
using System.Text;

class MainClass {
  public static void Main (string[] args) {
    
    Console.Clear();

    //Cadastro da pessoa
    string nome;
    string senha;
    string telefone;
    string email;

    Console.WriteLine("CADASTRO INICIAL\n");

    Console.WriteLine("Digite seu nome: ");
    nome = Console.ReadLine();
  
    Console.WriteLine("Digite sua senha: ");
    senha = Console.ReadLine();

    Console.WriteLine("Digite seu telefone: ");
    telefone = Console.ReadLine();

    Console.WriteLine("Digite seu email: ");
    email = Console.ReadLine();

    Pessoa cadastro = new Pessoa(nome, senha, telefone, email);
    Console.Clear();

    //Menu
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
        cadastro.SaidaCadastro(cadastro);
        break;

        //Cadastro dos itens
        case "2":
        item.EscreverItem();
        break;

        //Lê uma lista de itens e adciona ao armario
        case "3":
        try{
          armario.AdicionarItens();
          armario.SaidaLista();
        }
        catch(Exception){
          Console.WriteLine("SEU ARMARIO ESTA VAZIO!");
        }
        break;

        //Simula itens que foram jogados para a lixeira
        case "4":
        try{
          armario.AdicionarItens();
          lixeira.SaidaLixeira();
        }
        catch(Exception){
          Console.WriteLine("VOCÊ NÃO PODE FAZER ESTA AÇÃO, POIS SEU ARMARIO ESTA VAZIO!");
        }
        break;

        //Limpa o console
        case "5":
        Console.Clear();
        break;

        //Sai do programa
        case "6":
        Console.WriteLine("SAINDO...");
        item.DeletarArquivos();
        repetir = false;
        break;

        //Caso não seja nenhuma das opções acima
        default:
        Console.WriteLine("OPÇÃO INVALIDA...");
        break;
      }
    }  
  }
}