using System;

public class Sensor{

  public static int leitorArmario(){
    Random randNum = new Random();

    return randNum.Next(6,19);
  }

  public static int leitorLixeira(){
    Random randNum = new Random();

    return randNum.Next(1,4);
  }
  
}