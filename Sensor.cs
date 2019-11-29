using System;

public class Sensor{

  public int leitorArmario(){
    Random randNum = new Random();

    return randNum.Next(6,19);
  }

  public int leitorLixeira(){
    Random randNum = new Random();

    return randNum.Next(1,4);
  }
  
}