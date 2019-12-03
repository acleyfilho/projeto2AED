using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Armario{

  List<Item> itens = new List<Item>();

  public List<Item> AdicionarItens(){

    itens.Clear();
    
    FileStream meuArq = new FileStream("itens.txt", FileMode.Open, FileAccess.Read);

    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);

    FileStream meuArq2 = new FileStream("qtdAtual.txt", FileMode.Open, FileAccess.Read);

    StreamReader sr2 = new StreamReader(meuArq2, Encoding.UTF8);

    while(!sr.EndOfStream){

      string str = sr.ReadLine();
      string str2 = sr2.ReadLine();
      string nomeAux;
      int qtdMinAux;
      int qtdAtualAux;

      nomeAux = String.Join("", System.Text.RegularExpressions.Regex.Split(str, @"[\d| -]"));

      qtdMinAux = int.Parse(String.Join("", System.Text.RegularExpressions.Regex.Split(str, @"[^\d]")));

      qtdAtualAux = int.Parse(str2);
      
      itens.Add(new Item(nomeAux, qtdMinAux, qtdAtualAux));
    }
      
    sr.Close();
    meuArq.Close();
    sr2.Close();
    meuArq2.Close();
    
    return itens;
  }

  public void MostrarLista(){

    if(File.Exists("itens.txt") && File.Exists("qtdAtual.txt")){

      File.Delete("qtdAtual.txt");

      StreamWriter sw = new StreamWriter("qtdAtual.txt", true);
    
      List<Item> lis = new List<Item>();

      foreach (Item i in itens){

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
      if(lis.Count < itens.Count){

        File.Delete("qtdAtual.txt");

        StreamWriter sw2 = new StreamWriter("qtdAtual.txt", true);
        
        foreach (Item i in itens){

          sw2.WriteLine(i.getQtdAtual());
        }
        sw2.Close();
      }
      sw.Close();
    }
  }

  public void SaidaLista(){
    Console.WriteLine("\n║║║║║║║║║║║║║═>SEU ARMARIO<═║║║║║║║║║║║║║║");
    MostrarLista();
    Console.WriteLine("\n------------------------------------------");
  }
}