using System;
using System.IO;
using System.Text;

public class Item{

  private string nome;
  private int qtdMin;
  private int qtdAtual;

  Sensor sensor = new Sensor();
  
  public Item(){

    nome = "Nome";
    qtdMin = 0;
    qtdAtual = 0;
  }

  public Item(string n, int qm, int qa){

    nome = n;
    qtdMin = qm;
    qtdAtual = qa;
  }

  public string getNome(){
    return nome;
  }

  public void setNome(string n){
    nome = n;
  }

  public int getQtdMin(){
    return qtdMin;
  }

  public void setQtdMin(int qm){
    qtdMin = qm;
  }

  public int getQtdAtual(){
    return qtdAtual;
  }

  public void setQtdAtual(int qa){
    qtdAtual = qa;
  }

  public override string ToString(){
    return "\nItem: " + nome + "\nQuantidade Minima: " + qtdMin + "\nQuantidade Atual: " + qtdAtual;
  }
  
  public void EscreverItem(){

    StreamWriter sw = new StreamWriter("itens.txt", true);
    StreamWriter sw2 = new StreamWriter("qtdAtual.txt", true);

    string str = string.Empty;
    string str2 = string.Empty;
    string resposta;
    bool repetir = true;
    int qtdAtualAux = sensor.leitorArmario();
    int i = 0;
    
    while(repetir == true){
      if(i == 0){
        Console.WriteLine("CADASTRO DE ITENS\n");
        Console.WriteLine("Escreva o item que deseja:");
        str = Console.ReadLine();
        Console.WriteLine("Escreva a quantidade minima que deseja:");
        str2 = Console.ReadLine();
        
        sw.WriteLine(str+" - "+str2);
        sw2.WriteLine(qtdAtualAux);
        i++;
      }else{
        Console.WriteLine("Deseja cadastrar mais algum item(S|N)?");
        resposta = Console.ReadLine();
        if(resposta == "S" || resposta == "s"){
          Console.WriteLine("Escreva o item que deseja:");
          str = Console.ReadLine();
          Console.WriteLine("Escreva a quantidade minima que deseja:");
          str2 = Console.ReadLine();
          
          sw.WriteLine(str+" - "+str2);
          sw2.WriteLine(qtdAtualAux);
        }else{
         Console.Clear();
         repetir = false;
       }
      } 
    }
    sw.Close();
    sw2.Close();
  }

  public void DeletarArquivos(){
    File.Delete("itens.txt");
    File.Delete("qtdAtual.txt");
  }
}