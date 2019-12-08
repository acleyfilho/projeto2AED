using System;
using System.IO;
using System.Text;

public class Item{

  protected string nome;
  protected int qtdMin;
  protected int qtdAtual;
  
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
  
  public void EscreverItem(){

    string str = string.Empty;
    string str2 = string.Empty;
    string str3 = string.Empty;
    int qtdAtualAux;
    string armazenar;
    string resposta;
    bool repetir = true;
    int i = 0;
    
    while(repetir == true){
      if(i == 0){
        Console.WriteLine("CADASTRO DE ITENS\n");
        Console.WriteLine("Escreva o item que deseja:");
        str = Console.ReadLine();
        Console.WriteLine("Escreva a quantidade minima que deseja:");
        str2 = Console.ReadLine();
        Console.WriteLine("Escolha onde vai armazenar(Armario|Geladeira):");
        armazenar = Console.ReadLine();
        if(armazenar == "Armario" || armazenar == "armario"){
          
          StreamWriter sw = new StreamWriter("itensArmario.txt", true);
          StreamWriter sw3 = new StreamWriter("qtdAtualArmario.txt", true);

          qtdAtualAux = Sensor.leitorArmario();
          sw.WriteLine(str+" - "+str2);
          sw3.WriteLine(qtdAtualAux);

          sw.Close();
          sw3.Close();

        }else
        if(armazenar == "Geladeira" || armazenar == "geladeira"){
          Console.WriteLine("Escolha a temperatura desejada para o item:");
          str3 = Console.ReadLine();

          StreamWriter sw2 = new StreamWriter("itensGeladeira.txt", true);
          StreamWriter sw4 = new StreamWriter("qtdAtualGeladeira.txt", true);
          StreamWriter sw5 = new StreamWriter("temperatura.txt", true);

          qtdAtualAux = Sensor.leitorGeladeira();
          sw2.WriteLine(str+" - "+str2);
          sw4.WriteLine(qtdAtualAux);
          sw5.WriteLine(str3);

          sw2.Close();
          sw4.Close();
          sw5.Close();
  
        }
        else{
          Console.WriteLine("Opção invalida!");
        }
        i++;
      }else{
        Console.WriteLine("Deseja cadastrar mais algum item(S|N)?");
        resposta = Console.ReadLine();
        if(resposta == "S" || resposta == "s"){
          Console.WriteLine("Escreva o item que deseja:");
          str = Console.ReadLine();
          Console.WriteLine("Escreva a quantidade minima que deseja:");
          str2 = Console.ReadLine();
          Console.WriteLine("Escolha onde vai armazenar(Armario|Geladeira):");
          armazenar = Console.ReadLine();
          if(armazenar == "Armario" || armazenar == "armario"){
          
            StreamWriter sw = new StreamWriter("itensArmario.txt", true);
            StreamWriter sw3 = new StreamWriter("qtdAtualArmario.txt", true);

            qtdAtualAux = Sensor.leitorArmario();
            sw.WriteLine(str+" - "+str2);
            sw3.WriteLine(qtdAtualAux);

            sw.Close();
            sw3.Close();

          }else
          if(armazenar == "Geladeira" || armazenar == "geladeira"){
            
            Console.WriteLine("Escolha a temperatura desejada para o item(Somente número):");
            str3 = Console.ReadLine();

            StreamWriter sw2 = new StreamWriter("itensGeladeira.txt", true);
            StreamWriter sw4 = new StreamWriter("qtdAtualGeladeira.txt", true);
            StreamWriter sw5 = new StreamWriter("temperatura.txt", true);

            qtdAtualAux = Sensor.leitorGeladeira();
            sw2.WriteLine(str+" - "+str2);
            sw4.WriteLine(qtdAtualAux);
            sw5.WriteLine(str3);

            sw2.Close();
            sw4.Close();
            sw5.Close();
          }
          else{
            Console.WriteLine("Opção invalida!");
          }
        }else{
         Console.Clear();
         repetir = false;
       }
      } 
    }
  }

  public void DeletarArquivos(){
    File.Delete("itensArmario.txt");
    File.Delete("qtdAtualArmario.txt");
    File.Delete("itensGeladeira.txt");
    File.Delete("qtdAtualGeladeira.txt");
    File.Delete("temperatura.txt");
  }
}