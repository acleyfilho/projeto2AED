using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Lixeira{

  Armario armario = new Armario();
  Geladeira geladeira = new Geladeira();
  
  public void SimularLixeiraArmario(){

    List<Item> lista = new List<Item>();

    foreach (Item i in armario.AdicionarItens()){

      int qtdAtual = i.getQtdAtual();
      int qtdLixeira = Sensor.leitorLixeira();

      if(qtdAtual >= qtdLixeira){
        qtdAtual = qtdAtual - qtdLixeira;
        i.setQtdAtual(qtdAtual);

        Console.WriteLine("\nItem: " + i.getNome() + "\nQuantidade jogada no lixo: " + qtdLixeira +"\nQuantidade atual: " + qtdAtual);
        lista.Add(new Item(i.getNome(), i.getQtdMin(), qtdAtual));
      }
      else{
        qtdLixeira = qtdAtual;
        if(qtdAtual > 0){
          qtdAtual = qtdAtual - qtdLixeira;
          i.setQtdAtual(qtdAtual);

          Console.WriteLine("\nItem: " + i.getNome() + "\nQuantidade jogada no lixo: " + qtdLixeira +"\nQuantidade atual: " + qtdAtual);
          lista.Add(new Item(i.getNome(), i.getQtdMin(), qtdAtual = qtdAtual));
        }
        else{
          Console.WriteLine("\nItem: " + i.getNome() + "\nQuantidade jogada no lixo: " + qtdLixeira +"\nQuantidade atual: " + qtdAtual);
          lista.Add(new Item(i.getNome(), i.getQtdMin(), qtdAtual = qtdAtual));
        } 
      }
    }

    if(File.Exists("itensArmario.txt") && File.Exists("qtdAtualArmario.txt")){
      
      File.Delete("qtdAtualArmario.txt");

      StreamWriter sw = new StreamWriter("qtdAtualArmario.txt", true);

      int qtdAtualAux; 

      foreach (Item j in lista){
        qtdAtualAux = j.getQtdAtual();
        sw.WriteLine(qtdAtualAux);
      }
      sw.Close();
      lista.Clear();
    }
  }

  public void SimularLixeiraGeladeira(){

    List<Item> lista = new List<Item>();

    foreach (Item i in geladeira.AdicionarItens()){

      int qtdAtual = i.getQtdAtual();
      int qtdLixeira = Sensor.leitorLixeira();

      if(qtdAtual >= qtdLixeira){
        qtdAtual = qtdAtual - qtdLixeira;
        i.setQtdAtual(qtdAtual);

        Console.WriteLine("\nItem: " + i.getNome() + "\nQuantidade jogada no lixo: " + qtdLixeira +"\nQuantidade atual: " + qtdAtual);
        lista.Add(new Item(i.getNome(), i.getQtdMin(), qtdAtual));
      }
      else{
        qtdLixeira = qtdAtual;
        if(qtdAtual > 0){
          qtdAtual = qtdAtual - qtdLixeira;
          i.setQtdAtual(qtdAtual);

          Console.WriteLine("\nItem: " + i.getNome() + "\nQuantidade jogada no lixo: " + qtdLixeira +"\nQuantidade atual: " + qtdAtual);
          lista.Add(new Item(i.getNome(), i.getQtdMin(), qtdAtual = qtdAtual));
        }
        else{
          Console.WriteLine("\nItem: " + i.getNome() + "\nQuantidade jogada no lixo: " + qtdLixeira +"\nQuantidade atual: " + qtdAtual);
          lista.Add(new Item(i.getNome(), i.getQtdMin(), qtdAtual = qtdAtual));
        } 
      }
    }

    if(File.Exists("itensGeladeira.txt") && File.Exists("qtdAtualGeladeira.txt")){
      
      File.Delete("qtdAtualGeladeira.txt");

      StreamWriter sw = new StreamWriter("qtdAtualGeladeira.txt", true);

      int qtdAtualAux; 

      foreach (Item j in lista){
        qtdAtualAux = j.getQtdAtual();
        sw.WriteLine(qtdAtualAux);
      }
      sw.Close();
      lista.Clear();
    }
  }

  public void SaidaLixeira(){
    if(File.Exists("itensArmario.txt") && File.Exists("qtdAtualArmario.txt") && File.Exists("itensGeladeira.txt") && File.Exists("qtdAtualGeladeira.txt")){
     Console.WriteLine("\n║║║║║║║║║║║║║═>SUA LIXEIRA<═║║║║║║║║║║║║║║");
     SimularLixeiraArmario();
     SimularLixeiraGeladeira();
     Console.WriteLine("\n------------------------------------------");
    }else
    if(File.Exists("itensArmario.txt") && File.Exists("qtdAtualArmario.txt")){
      Console.WriteLine("\n║║║║║║║║║║║║║═>SUA LIXEIRA<═║║║║║║║║║║║║║║");
      SimularLixeiraArmario();
      Console.WriteLine("\n------------------------------------------");
    }else
    if(File.Exists("itensGeladeira.txt") && File.Exists("qtdAtualGeladeira.txt")){
      Console.WriteLine("\n║║║║║║║║║║║║║═>SUA LIXEIRA<═║║║║║║║║║║║║║║");
      SimularLixeiraGeladeira();
      Console.WriteLine("\n------------------------------------------");
    }else{
      Console.WriteLine("VOCÊ NÃO PODE FAZER ESTA AÇÃO, POIS VOCÊ NÃO TEM ITENS!");
    }
  }
}