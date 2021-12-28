using System;

namespace dotnet1
{
    class Program
    {
        static void Main(string[] args)
        {

            aluno[] alunos = new aluno[5]; //(Array) digitar essa linha depois de criado aluno.cs //o 5 é o número máximo de alunos que serão aceitos. 
            var indiceAluno = 0; // para assumir como inteiro e lançar na primeira posição.
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X") //"ToUpper" caso o usuário digite letra minúscula, ele vai ficar maiúscula. //"!=" se for diferente de X ele executa a parte abaixo:
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        var aluno = new aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informar a nota do aluno:");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;

                    case "2":
                        foreach(var a in alunos) // para cada aluno, faça:
                        {
                            if (!string.IsNullOrEmpty(a.Nome)) //vai listar somente os alunos digitados.
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                            }
                        }
                        
                        break;

                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO DA TURMA: {conceitoGeral}");

                        break;

                    default:
                        throw new ArgumentOutOfRangeException(); //disparar uma exceção que indica que o valor informado está fora das opções indicadas.
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral e conceito da turma");
            Console.WriteLine("X - Sair");
            Console.WriteLine(); //para ficar uma linha em branco.

            string opcaoUsuario = Console.ReadLine(); //para ler o que o usuário digitou.
            Console.WriteLine();
            return opcaoUsuario; // para aparecer o menu novamente na tela.
        }
    }
}
