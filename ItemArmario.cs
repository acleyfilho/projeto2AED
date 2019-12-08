using System;

public class ItemArmario: Item{

  
public ItemArmario(string n, int qm, int qa):base(n, qm, qa){

}

public override string ToString(){
    return "\nItem: " + nome + "\nQuantidade Minima: " + qtdMin + "\nQuantidade Atual: " + qtdAtual;
  } 
}