namespace dotnet1
{
    public struct aluno 
    //mudado de class para struct. O uso de structs em vez de classes para pequenas estruturas de dados podem fazer uma grande diferença no número de alocações de memória. Como as classes, as structs são estruturas de dados que podem conter membros de dados e membros de ação, mas diferentemente das classes, as structs são tipos de valor e não requerem alocação de heap. Uma variável de um tipo de struct armazena diretamente os dados da estrutura, enquanto uma variável de um tipo de classe armazena uma referência a um objeto alocado na memória.

    {
       public string Nome { get; set; } //digita prop que já vai criar essa linha de propriedade. Muda-se o "int" para a e "MyProperty" para o nome escolhido.
       public decimal Nota { get; set; }
    }
}