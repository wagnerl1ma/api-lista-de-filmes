using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListaDeFilmes.Business.Models
{
    public class Filme : Entity
    {
        public string Nome { get; set; }

        public DateTime? DataCadastro { get; set; } = DateTime.Now;

        public string Classificacao { get; set; }

        public int? Ano { get; set; }

        public string Comentarios { get; set; }

        public string Imagem { get; set; }

        public decimal Valor { get; set; }

        public bool Ativo { get; set; }


        // Um Filme pode ter vários Atores (Relacionamneto muitos para muitos)
        public ICollection<FilmeAtor> FilmesAtores { get; set; }

        // Um Filme só pode ter um Genero (Relacionamento um para muitos)
        public Genero Genero { get; set; }                           
        public Guid GeneroId { get; set; }


        // Um Filme só pode ter um Diretor (Relacionamneto um para muitos)
        public Diretor Diretor { get; set; }
        public Guid? DiretorId { get; set; }    //TODO: RETIRAR A OPÇÃO DE ACEITAR NULO QUANDO TERMINAR O CRUD E A SERVICE


        // Um Filme só pode ter um Produtora (Relacionamneto um para muitos)
        public Produtora Produtora { get; set; }                    
        public Guid? ProdutoraId { get; set; }        //TODO: RETIRAR A OPÇÃO DE ACEITAR NULO QUANDO TERMINAR O CRUD E A SERVICE


        //public Filme()
        //{

        //}

        //public Filme(Guid id, string nome, string classificacao, int? ano, string comentarios, string imagem, decimal valor, bool ativo, Genero genero, Diretor diretor, Produtora produtora)
        //{
        //    Id = id;
        //    Nome = nome;
        //    Classificacao = classificacao;
        //    Ano = ano;
        //    Comentarios = comentarios;
        //    Genero = genero;
        //    Diretor = diretor;
        //    Produtora = produtora;
        //    Imagem = imagem;
        //    Valor = valor;
        //    Ativo = Ativo;
        //}

        //public Filme(string nome, string classificacao, int? ano, string comentarios, string imagem, decimal valor, bool ativo, Genero genero, Diretor diretor, Produtora produtora)
        //{
        //    Nome = nome;
        //    Classificacao = classificacao;
        //    Ano = ano;
        //    Comentarios = comentarios;
        //    Genero = genero;
        //    Diretor = diretor;
        //    Produtora = produtora;
        //    Imagem = imagem;
        //    Valor = valor;
        //    Ativo = Ativo;
        //}

        //public void AddFilmeAtores(FilmeAtor filmeAtor)
        //{
        //    FilmesAtores.Add(filmeAtor);
        //}

        //public void RemoverFilmeAtores(FilmeAtor filme)
        //{
        //    FilmesAtores.Remove(filme);
        //}


        ////Buscar ultimos cadastrados
        //public double UltimosCadastrados(DateTime inicio, DateTime final)
        //{
        //    return Genero.Filmes.Where(g => g.DataCadastro >= inicio && g.DataCadastro <= final).Sum(g => g.Genero.Filmes.Count());
        //}

        //Buscar por lançamentos  -- criar


        //Buscar por ano do filme   -- criar
    }
}
