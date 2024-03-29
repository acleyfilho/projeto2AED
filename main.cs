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

    while(true){
      Console.WriteLine("Digite seu nome: ");
      nome = Console.ReadLine();

      try{
        if (nome.Length <= 3){
          throw new Exception("Nome inválido!");
        }
        else{
          break;
        }
      }
      catch(Exception){
        Console.WriteLine("Nome inválido!");
        continue;
      }
    }



    while(true){
      Console.WriteLine("Digite sua senha: ");
      senha = Console.ReadLine();

      try{
        if (senha.Length < 6){
          throw new Exception("Senha menor do que 6 dígitos!");
        }
        else{
          break;
        }
      }
      catch(Exception){
        Console.WriteLine("Senha menor do que 6 dígitos!");
        continue;
      }
    }



    while(true){
      Console.WriteLine("Digite seu telefone:");
      telefone = Console.ReadLine();

      try{
        if (telefone.Length < 8){
          throw new Exception("E-mail inválido!");
        }
        else{
          break;
        }
      }
      catch(Exception){
        Console.WriteLine("E-mail inválido!");
        continue;
      }
    }



    while(true){
      Console.WriteLine("Digite seu email: ");
      email = Console.ReadLine();

      try{
        int indexEmail = email.IndexOf('@');
        if (indexEmail == -1){
          throw new Exception("E-mail inválido!");
        }
        else{
          break;
        }
      }
      catch(Exception){
        Console.WriteLine("E-mail inválido!");
        continue;
      }
    }
  


    Pessoa cadastro = new Pessoa(nome, senha, telefone, email);
    Console.Clear();

    //Menu
    string menu;
    bool repetir = true;

    Armario armario = new Armario();
    Geladeira geladeira = new Geladeira();
    Item item = new Item();
    Lixeira lixeira = new Lixeira();

    while(repetir == true){
      //Mostra o username
      Console.WriteLine("\n══════════════════════════════════════════    ");

      Console.WriteLine(" Usuario: " + (Pessoa.username = nome));

      Console.WriteLine("══════════════════════════════════════════    ");

      Console.WriteLine(" ");

      Console.WriteLine("╔═════════════MENU DE OPÇÕES═════════════╗    ");

      Console.WriteLine("║ 1 - DADOS DO USUARIO                   ║    ");

      Console.WriteLine("║                                        ║    ");

      Console.WriteLine("║ 2 - CADASTRO DE ITENS                  ║    ");

      Console.WriteLine("║                                        ║    ");

      Console.WriteLine("║ 3 - CHECAR ARMARIO                     ║    ");

      Console.WriteLine("║                                        ║    ");

      Console.WriteLine("║ 4 - CHECAR GELADEIRA                   ║    ");

      Console.WriteLine("║                                        ║    ");

      Console.WriteLine("║ 5 - JOGAR ITEM NO LIXO                 ║    ");

      Console.WriteLine("║                                        ║    ");

      Console.WriteLine("║ 6 - LIMPAR CONSOLE                     ║    ");
      
      Console.WriteLine("║                                        ║    ");

      Console.WriteLine("║ 7 - SAIR                               ║    ");

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

        //Lê uma lista de itens e adciona a geladeira
        case "4":
        try{
          geladeira.AdicionarItens();
          geladeira.SaidaLista();
        }
        catch(Exception){
          Console.WriteLine("SUA GELADEIRA ESTA VAZIA!");
        }
        break;

        //Simula itens que foram jogados para a lixeira
        case "5":
        lixeira.SaidaLixeira();
        break;

        //Limpa o console
        case "6":
        Console.Clear();
        break;

        //Sai do programa
        case "7":
        Console.WriteLine("FINALIZADO COM SUCESSO!");
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