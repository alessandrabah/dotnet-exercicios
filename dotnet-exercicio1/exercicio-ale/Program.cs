using System;

namespace exercicio_ale
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[50];
            var indiceAluno = 0;
            string notaDigitada;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informar o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        
                        Console.WriteLine("Informar a nota do aluno:");
                        notaDigitada = Console.ReadLine();
                        
                        if (!decimal.TryParse(notaDigitada.Replace(".",","), out decimal nota))
                        {
                            Console.WriteLine("[ERRO!] Inclua uma nota válida.");
                        }
                        aluno.Nota = nota;

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;

                    case "2":
                        foreach(var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
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

                        var mediaGeral = notaTotal/ nrAlunos;
                        mediaGeral = decimal.Round(mediaGeral, 2);
                        Conceito conceitoGeral;

                        if (mediaGeral <= 2)
                        {
                            conceitoGeral = Conceito.E;   
                        }
                        else if (mediaGeral <= 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral <= 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral <= 8)
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
                        Console.WriteLine("[ERRO!] Digite uma opção válida.");
                        break;
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("INFORME A OPÇÃO DESEJADA:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média e conceito da turma");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}
