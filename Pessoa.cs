using System;

public class Pessoa{

  private string nome;
  private string senha;
  private string telefone;
  private string email;
  public static string username;
  
  public Pessoa(){

    nome = "Nome";
    senha = "Senha";
    telefone = "3000-5349";
    email = "email@ucl.br";
  }

  public Pessoa(string n, string s, string t, string e){

    nome = n;
    senha = s;
    telefone = t;
    email = e;
  }

  public string getNome(){
    return nome;
  }

  public void setNome(string n){
    nome = n;
  }

  public string getSenha(){
    return senha;
  }

  public void setSenha(string s){
    senha = s;
  }

  public string getTelefone(){
    return telefone;
  }

  public void setTelefone(string t){
    telefone = t;
  }

  public string getEmail(){
    return email;
  }

  public void setEmail(string e){
    email = e;
  }

  public override string ToString(){
    return string.Format("Nome: {0}\nSenha: {1}\nTelefone: {2}\nEmail: {3}",nome,senha,telefone,email);
  }

  public void SaidaCadastro(Pessoa cadastrada){
    Console.WriteLine("\n║║║║║║║║║║║║║═>SEU CADASTRO<═║║║║║║║║║║║║║\n");
    Console.WriteLine(cadastrada);
    Console.WriteLine("\n------------------------------------------");
  }
}