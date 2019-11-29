using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Lixeira{

  Armario armario = new Armario();

  List<Item> lista = new List<Item>();

  Sensor sensor = new Sensor();

  public void SimularLixeira(){

    foreach (Item i in armario.AdicionarItens()){

      int qtdAtual = i.getQtdAtual();
      int qtdLixeira = sensor.leitorLixeira();

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

    if(File.Exists("itens.txt") && File.Exists("qtdAtual.txt")){
      
      File.Delete("qtdAtual.txt");

      StreamWriter sw = new StreamWriter("qtdAtual.txt", true);

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
    Console.WriteLine("\n║║║║║║║║║║║║║═>SUA LIXEIRA<═║║║║║║║║║║║║║║");
    SimularLixeira();
    Console.WriteLine("\n------------------------------------------");
  }
}