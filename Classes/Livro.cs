using System;

namespace DIO.Livros
{
    public class Livro : EntidadeBase
    {
        //Esses são os atributos

        private Genero Genero { get; set;}
        private string Titulo { get; set;}
        private string Autor { get; set;}
        private string Descricao { get; set;}
        private string Editora { get; set;}
        private int Ano { get; set;}
        private bool Excluido { get; set;}

        //Esses são os métodos

        public Livro(int id, Genero genero, string titulo, string autor, string descricao, string editora, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Autor = autor;
            this.Descricao = descricao;
            this.Editora = editora;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero:" + this.Genero + Environment.NewLine;
            retorno += "Título:" + this.Titulo + Environment.NewLine;
            retorno += "Autor:"  + this.Autor + Environment.NewLine;
            retorno += "Descrição:" + this.Descricao + Environment.NewLine;
            retorno += "Editora:"  + this.Editora + Environment.NewLine;
            retorno += "Ano de Início:" + this.Ano + Environment.NewLine;
            retorno += "Excluido:" + this.Excluido;
            return retorno;

        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir(){
            this.Excluido = true;
        }

    }
}
