using System;
using System.IO;
using System.Text;

public class Pessoa{

  private string nome;
  private string nomeDeUsuario;
  private string senha;
  private string telefone;
  private string email;
  private string caminhoBD;
  
  public Pessoa(){

    nome = "Nome";
    nomeDeUsuario = "Nome de Usuario";
    senha = "Senha";
    telefone = "3000-5349";
    email = "email@ucl.br";
    caminhoBD = "Caminho BD"; 
  }

  public Pessoa(string n, string ndu, string s, string t, string e, string c){

    nome = n;
    nomeDeUsuario = ndu;
    senha = s;
    telefone = t;
    email = e;
    caminhoBD = c;
  }

  public string getNome(){
    return nome;
  }

  public void setNome(string n){
    nome = n;
  }

  public string getNomeDeUsuario(){
    return nomeDeUsuario;
  }

  public void setNomeDeUsuario(string ndu){
    nomeDeUsuario = ndu;
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

  public string getCaminhoBD(){
    return caminhoBD;
  }

   public override string ToString(){
    return string.Format("Nome: {0}\nSenha: {1}\nTelefone: {2}\nEmail: {3}",nome,senha,telefone,email);
  }

  public void LerDadosCadastro(){

    FileStream meuArq = new FileStream(".//BD Lucas//dados.txt", FileMode.Open, FileAccess.Read);

    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);

    while(!sr.EndOfStream){

      string str = sr.ReadLine();
          
    }

  } 

  public void SaidaCadastro(Pessoa cadastrada){
    Console.WriteLine("\n║║║║║║║║║║║║║═>SEU CADASTRO<═║║║║║║║║║║║║║\n");
    Console.WriteLine(cadastrada);
    Console.WriteLine("\n------------------------------------------");
  }
}