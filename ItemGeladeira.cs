using System;

public class ItemGeladeira: Item{

  private int temperatura;

  public ItemGeladeira(string n, int qm, int qa, int t):base(n, qm, qa){
    
    temperatura = t;
  }

  public override string ToString(){
    return "\nItem: " + nome + "\nQuantidade Minima: " + qtdMin + "\nQuantidade Atual: " + qtdAtual + "\nTemperatura Desejada: " + temperatura + "°";
  }
  
}