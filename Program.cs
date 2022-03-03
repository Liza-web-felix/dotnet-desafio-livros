using System;

namespace DIO.Livros
{
    class Program
    {
        static LivroRepositorio repositorio = new LivroRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                         ListarLivros();
                         break;
                    case "2":
                         InserirLivro();
                         break;
                    case "3":
                         AtualizarLivro();
                         break;
                    case "4":
                         ExcluirLivro();
                         break;
                    case "5":
                         VisualizarLivro();
                         break;
                    case "C":
                         Console.Clear();
                         break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();   
        }

        private static void ExcluirLivro()
        {
            Console.Write("Digite o id do livro:");
            int indiceLivro = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceLivro);
        }

        private static void VisualizarLivro()
        {
            Console.Write("Digite o id do livro:");
            int indiceLivro = int.Parse(Console.ReadLine()); 

            var livro = repositorio.RetornaPorId(indiceLivro);

            Console.WriteLine(livro);
        }
          private static void AtualizarLivro()
        {
            Console.WriteLine("Digite o id do livro:");
            int indiceLivro = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima:");
            int entradaGenero =  int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Livro:");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Nome do Autor do Livro:");
            string entradaAutor = Console.ReadLine();

            Console.Write("Digite o Ano de Lançamento do Livro:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Livro:");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite a Editora do Livro:");
            string entradaEditora = Console.ReadLine();

            Livro AtualizarLivro = new Livro (id: indiceLivro,
                                         genero: (Genero)entradaGenero,
                                         titulo: entradaTitulo,
                                         autor: entradaAutor,
                                         ano: entradaAno,
                                         descricao: entradaDescricao,
                                         editora: entradaEditora);

            repositorio.Atualiza(indiceLivro, AtualizarLivro);
        }

        private static void ListarLivros()
        {
            Console.WriteLine("Listar livros");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
                return;
            }

            foreach (var livro in lista)
            {
                var excluido = livro.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", livro.retornaId(), livro.retornaTitulo(), excluido ? "+Excluido+" : "");
            }
        }

        private static void InserirLivro()
        {
            Console.WriteLine("Inserir novo livro");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima:");
            int entradaGenero =  int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Livro:");
            string entradaTitulo = Console.ReadLine();

            
            Console.Write("Digite o Nome do Autor do Livro:");
            string entradaAutor = Console.ReadLine();

            Console.Write("Digite o Ano de Lançamento do Livro:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Livro:");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite a Editora do Livro:");
            string entradaEditora = Console.ReadLine();

            Livro novoLivro = new Livro (id: repositorio.ProximoId(),
                                         genero: (Genero)entradaGenero,
                                         titulo: entradaTitulo,
                                         autor: entradaAutor,
                                         ano: entradaAno,
                                         descricao: entradaDescricao,
                                         editora: entradaEditora);

            repositorio.Insere(novoLivro);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Livros a seu dispor!!!");
            Console.WriteLine("Informe a opção desajada:");

            Console.WriteLine("1- Listar livros");
            Console.WriteLine("2- Inserir novo livro");
            Console.WriteLine("3- Atualizar livro");
            Console.WriteLine("4- Excluir livro");
            Console.WriteLine("5- Visualizar livro");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
