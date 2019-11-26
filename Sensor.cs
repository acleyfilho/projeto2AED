using System;

public class Sensor{

  public int leitorArmario(){
    Random randNum = new Random();

    return randNum.Next(6,12);
  }

  public int leitorLixeira(){
    Random randNum = new Random();

    return randNum.Next(1,3);
  }
  
}