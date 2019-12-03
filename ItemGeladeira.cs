using System;

public class ItemGeladeira: Item{

  private int temperatura;

  public static void ItemGeladeira(string n, int qm, int qa, int t):base(n, qm, qa){
    
    temperatura = t;
  }
  
}