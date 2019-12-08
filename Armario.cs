using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Armario{

  List<ItemArmario> itensArmario = new List<ItemArmario>();

  public List<ItemArmario> AdicionarItens(){

    itensArmario.Clear();
    
    FileStream meuArq = new FileStream("itensArmario.txt", FileMode.Open, FileAccess.Read);

    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);

    FileStream meuArq2 = new FileStream("qtdAtualArmario.txt", FileMode.Open, FileAccess.Read);

    StreamReader sr2 = new StreamReader(meuArq2, Encoding.UTF8);

    while(!sr.EndOfStream){

      string str = sr.ReadLine();
      string str2 = sr2.ReadLine();
      string nomeAux;
      int qtdMinAux;
      int qtdAtualAux;

      nomeAux = String.Join("", System.Text.RegularExpressions.Regex.Split(str, @"[\d|-]"));

      qtdMinAux = int.Parse(String.Join("", System.Text.RegularExpressions.Regex.Split(str, @"[^\d]")));

      qtdAtualAux = int.Parse(str2);
      
      itensArmario.Add(new ItemArmario(nomeAux, qtdMinAux, qtdAtualAux));
    }
      
    sr.Close();
    meuArq.Close();
    sr2.Close();
    meuArq2.Close();
    
    return itensArmario;
  }

  public void MostrarLista(){

    if(File.Exists("itensArmario.txt") && File.Exists("qtdAtualArmario.txt")){

      File.Delete("qtdAtualArmario.txt");

      StreamWriter sw = new StreamWriter("qtdAtualArmario.txt", true);
    
      List<Item> lis = new List<Item>();

      foreach (Item i in itensArmario){

        string resposta;
        int qtdMinAux;
        int qtdAtualAux;
        int qtdDesejada;

        qtdAtualAux = i.getQtdAtual();
        qtdMinAux = i.getQtdMin();

        if(qtdAtualAux > qtdMinAux){
          Console.WriteLine(i);
          Console.WriteLine("------------------------------------------");
        }
        else{
          Console.WriteLine(i);
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.WriteLine("\nEsse item precisa de reposição!");
          Console.ForegroundColor = ConsoleColor.White; 
          Console.Write("\nDejesa comprar esse item(S|N)? ");
          resposta = Console.ReadLine();
          if(resposta == "S" || resposta == "s"){

            Console.WriteLine("\nDigite a quantidade que deseja comprar:");
            qtdDesejada = int.Parse(Console.ReadLine());

            qtdAtualAux = qtdAtualAux + qtdDesejada;

            i.setQtdAtual(qtdAtualAux);
            sw.WriteLine(qtdAtualAux);
            lis.Add(new Item(i.getNome(), qtdMinAux, qtdAtualAux));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nQuantidade comprada com sucesso!");
            Console.ForegroundColor = ConsoleColor.White; 
            Console.WriteLine(i);
            Console.WriteLine("------------------------------------------");
          }
          else{
            sw.WriteLine(qtdAtualAux);
            lis.Add(new Item(i.getNome(), qtdMinAux, qtdAtualAux));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nEsse item não tera reposição!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------------"); 
          }
        }
      }
      if(lis.Count < itensArmario.Count){

        File.Delete("qtdAtualArmario.txt");

        StreamWriter sw2 = new StreamWriter("qtdAtualArmario.txt", true);
        
        foreach (Item i in itensArmario){

          sw2.WriteLine(i.getQtdAtual());
        }
        sw2.Close();
      }
      sw.Close();
    }
  }

  public void SaidaLista(){
    Console.WriteLine("\n║║║║║║║║║║║║║═>SEU ARMARIO<═║║║║║║║║║║║║║║");
    Console.WriteLine("\n------------------------------------------");
    MostrarLista();
  }
}