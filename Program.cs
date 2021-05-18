using System;

namespace Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            int indice = 0;
            Aluno[] alunos = new Aluno[2];
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    Console.WriteLine("Informe o nome do Aluno:");
                    Aluno aluno =  new Aluno();
                    aluno.Nome = Console.ReadLine();


                    Console.WriteLine("Informe a nota:");
                    if(decimal.TryParse(Console.ReadLine(),out decimal nota))
                    {
                        aluno.Nota = nota;
                    }else{
                        throw new ArgumentException("O valor de nota não é decimal");
                    }

                    if(indice < 2)
                    {
                        alunos[indice] = aluno;
                        indice++;
                    }else{
                        Console.WriteLine("Sala cheia");
                    }
                        break;

                    case "2":
                        foreach(var listaAlunos in alunos)
                        {
                            if(!string.IsNullOrEmpty(listaAlunos.Nome))
                            {
                                Console.WriteLine($"Aluno: {listaAlunos.Nome} \n Nota: {listaAlunos.Nota}");    
                            }
                            
                        }
                        break;

                    case "3":
                        decimal valorTotal = 0;
                        decimal numeroAlunos = 0;

                        for(int i = 0; i < alunos.Length; i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                valorTotal = valorTotal + alunos[i].Nota;
                                numeroAlunos = numeroAlunos + 1;

                            }
                        }

                        var mediaGeral = valorTotal / numeroAlunos;
                        Conceito conceitoGeral;
                        
                        if(mediaGeral <= 2)
                        {
                                conceitoGeral = Conceito.E;

                        }else if(mediaGeral <= 4 )
                        {
                            conceitoGeral = Conceito.D;

                        }else if(mediaGeral <= 6)
                        {
                            conceitoGeral = Conceito.C;

                        }else if(mediaGeral <= 8)
                        {
                            conceitoGeral = Conceito.B;
                        }else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"\n A media geral e {mediaGeral}\n O conceito geral e {conceitoGeral}");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                
                opcaoUsuario = ObterOpcaoUsuario();

            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção:");
            Console.WriteLine("1 - inserir novo aluno");
            Console.WriteLine("2 - Listar Alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
