using System;

namespace Jogo_da_Velha.Entites
{
    class Partida
    {
        public char[] pecas { get; private set; }//Vetor de peças de 1 a 9
        public bool Fim { get; set; }//Bool para caso a partida acabe
        public bool TipoDePartida { get; set; }//True : PvP, False : PvIA
        public char Vencedor { get; set; }//O Vencedor da partida
        public Partida(bool tipo)
        {
            //Criar as posicoes com N sendo o valor vazio
            pecas = new char[9];
            pecas[0] = 'N';
            pecas[1] = 'N';  //Como a posição inicial do vetor é 0, fica da seguinte maneira:
            pecas[2] = 'N';  //  0  1  2
            pecas[3] = 'N';  //  3  4  5 
            pecas[4] = 'N';  //  7  8  9
            pecas[5] = 'N';
            pecas[6] = 'N';
            pecas[7] = 'N';
            pecas[8] = 'N';

            Fim = false;
            TipoDePartida = tipo;
        }
        public bool VerificarPosicao(int p1)
        {
            if (pecas[p1] == 'N')//Verifica se a posição já foi ocupada
            {
                return false;//Se estiver livre retorne falso
            }
            else
            {

                return true;//Se falhar retorne falso

            }
        }
        public bool VerificarPartida()
        {
            for (int i = 0; i < 3; i++)//Verifica as três linhas horizontais
            {
                if (pecas[3 * i] == pecas[(3 * i) + 1] && pecas[(3 * i)] == pecas[(3 * i) + 2] && pecas[(3 * i)] != 'N')
                /*Verifica da seguinte maneira:
                Se a peça nas posições forem do mesmo tipo houve uma combinação e o jogador daquele tipo venceu*/
                {
                    Fim = true;
                    Vencedor = pecas[3 * i];
                    return true;//Retorno apenas para cortar o metodo
                }

            }
            for (int i = 0; i < 3; i++)//Verifica as três linhas verticais
            {
                if (pecas[i] == pecas[i + 3] && pecas[i] == pecas[i + 6] && pecas[i] != 'N')
                /*Verifica da seguinte maneira:
                Se a peça nas posições forem do mesmo tipo houve uma combinação e o jogador daquele tipo venceu*/
                {
                    Fim = true;
                    Vencedor = pecas[i];
                    return true;//Retorno apenas para cortar o metodo
                }

            }
            if (pecas[0] == pecas[4] && pecas[0] == pecas[8] && pecas[0] != 'N')//Verifica a diagonal da esquerda para direita 
            {
                Fim = true;
                Vencedor = pecas[0];
                return true;//Retorno apenas para cortar o metodo
            }
            if (pecas[2] == pecas[4] && pecas[2] == pecas[6] && pecas[2] != 'N')//Verifica a diagonal da direita para esquerda
            {
                Fim = true;
                Vencedor = pecas[2];
                return true;//Retorno apenas para cortar o metodo
            }
            else if (pecas[0] != 'N' && pecas[1] != 'N' && pecas[2] != 'N' && pecas[3] != 'N' && pecas[4] != 'N' && pecas[5] != 'N' && pecas[6] != 'N' && pecas[7] != 'N' && pecas[8] != 'N')
            //Verifica se todas as posições já foram ocupadas
            {
                Fim = true;
                Vencedor = 'N';//Não houve vencedor
                return true;
            }
            else
            {
                return false;//Caso não aconteça nada retorne falso
            }
            public void ImprimirPartida()
            {
                for (int j = 0; j <= 2; j++)
                {
                    for (int i = 0; i <= 2; i++)//Imprimir cada linha
                    {
                        if (pecas[i + (j * 3)] == 'N')//Se não houver peça imprima um espaço vazio
                        {
                            if (i == 2)
                            {
                                Console.WriteLine("   ");//Se for o ultimo finalize a linha
                            }
                            else
                            {
                                Console.Write("   |");
                            }
                        }
                        else//Se houver imprima o char da peça
                        {
                            if (i == 2)//Se for o ultimo finalize a linha
                            {
                                Console.WriteLine($" {pecas[i + (j * 3)]}   ");
                            }
                            else
                            {
                                Console.Write($" {pecas[i + (j * 3)]} |");
                            }
                        }
                    }
                    if (j < 2)//Não faça na ultima linha
                    {
                        Console.WriteLine("---+---+---");
                    }

                }
            }
        }
    }