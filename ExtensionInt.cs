using Jogo_da_Velha.Exceptions;
namespace System
{
    static class ExtensionInt
    {
        /*
         Classe responsavel por converter o teclado numerico para um formato aceitavel do jogo  
         7 8 9    1 2 3
         4 5 6 => 4 5 6
         1 2 3    7 8 9  
         Teclado  Aceito
        */
        public static int Converter(this int n)
        {
            if (n != 0)
            {
                if (n == 4 || n == 5 || n == 6)//Como os 4,5,6 são comuns, não é necessario os mudar
                {
                    return n;
                }
                else if (n >= 7)
                {
                    return n - 6;
                }
                else if (n <= 3)
                {
                    return n + 6;
                }
                else//Se não se encaixar é porque o valor é fora do esperado
                {
                    throw new Excecoes("Valor fora do esperado!");
                }
            }
            else
            {
                throw new Excecoes("Valor fora do esperado!");
            }

        }

    }
}
