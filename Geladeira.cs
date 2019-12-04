using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Geladeira{

  List<ItemGeladeira> itensGeladeira = new List<ItemGeladeira>();

  public List<ItemGeladeira> AdicionarItens(){

    itensGeladeira.Clear();
    
    FileStream meuArq = new FileStream("itensGeladeira.txt", FileMode.Open, FileAccess.Read);

    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);

    FileStream meuArq2 = new FileStream("qtdAtualGeladeira.txt", FileMode.Open, FileAccess.Read);

    StreamReader sr2 = new StreamReader(meuArq2, Encoding.UTF8);

    FileStream meuArq3 = new FileStream("temperatura.txt", FileMode.Open, FileAccess.Read);

    StreamReader sr3 = new StreamReader(meuArq3, Encoding.UTF8);

    while(!sr.EndOfStream){

      string str = sr.ReadLine();
      string str2 = sr2.ReadLine();
      string str3 = sr3.ReadLine();
      string nomeAux;
      int temperatura;
      int qtdMinAux;
      int qtdAtualAux;

      nomeAux = String.Join("", System.Text.RegularExpressions.Regex.Split(str, @"[\d|-]"));

      qtdMinAux = int.Parse(String.Join("", System.Text.RegularExpressions.Regex.Split(str, @"[^\d]")));

      qtdAtualAux = int.Parse(str2);

      temperatura = int.Parse(str3);

      itensGeladeira.Add(new ItemGeladeira(nomeAux, qtdMinAux, qtdAtualAux, temperatura));
    }
      
    sr.Close();
    meuArq.Close();
    sr2.Close();
    meuArq2.Close();
    sr3.Close();
    meuArq3.Close();
    
    return itensGeladeira;
  }

  public void MostrarLista(){

    if(File.Exists("itensGeladeira.txt") && File.Exists("qtdAtualGeladeira.txt")){

      File.Delete("qtdAtualGeladeira.txt");

      StreamWriter sw = new StreamWriter("qtdAtualGeladeira.txt", true);
    
      List<Item> lis = new List<Item>();

      foreach (Item i in itensGeladeira){

        string resposta;
        int qtdMinAux;
        int qtdAtualAux;
        int qtdDesejada;

        qtdAtualAux = i.getQtdAtual();
        qtdMinAux = i.getQtdMin();

        if(qtdAtualAux > qtdMinAux){
          Console.WriteLine(i);
        }
        else{
          Console.WriteLine(i);
          Console.WriteLine("Esse item precisa de reposição!");
          Console.Write("Dejesa comprar esse item(S|N)? ");
          resposta = Console.ReadLine();
          if(resposta == "S" || resposta == "s"){

            Console.WriteLine("Digite a quantidade que deseja comprar:");
            qtdDesejada = int.Parse(Console.ReadLine());

            qtdAtualAux = qtdAtualAux + qtdDesejada;

            i.setQtdAtual(qtdAtualAux);
            sw.WriteLine(qtdAtualAux);
            lis.Add(new Item(i.getNome(), qtdMinAux, qtdAtualAux));
            Console.WriteLine("Quantidade comprada com sucesso!");
            Console.WriteLine(i);
          }
          else{
            sw.WriteLine(qtdAtualAux);
            lis.Add(new Item(i.getNome(), qtdMinAux, qtdAtualAux));
            Console.WriteLine("Esse item não tera reposição!");
          }
        }
      }
      if(lis.Count < itensGeladeira.Count){

        File.Delete("qtdAtualGeladeira.txt");

        StreamWriter sw2 = new StreamWriter("qtdAtualGeladeira.txt", true);
        
        foreach (Item i in itensGeladeira){

          sw2.WriteLine(i.getQtdAtual());
        }
        sw2.Close();
      }
      sw.Close();
    }
  }

  public void SaidaLista(){
    Console.WriteLine("\n║║║║║║║║║║║║║═>SUA GELADEIRA<═║║║║║║║║║║║║║║");
    MostrarLista();
    Console.WriteLine("\n------------------------------------------");
  }
}