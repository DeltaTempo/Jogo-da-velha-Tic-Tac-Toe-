/*Como a posição inicial de vetor é 0, a partida fica da seguinte maneira:
    0   1   2 
    3   4   5
    6   7   8 
*/

using System.Linq;
using System;

namespace Jogo_da_Velha.Entites
{
    class Partida
    {
        public Peca[] pecas { get; private set; }//Vetor de peças de 1 a 9
        public bool Fim { get; private set; }//Bool para caso a partida acabe
        public bool TipoDePartida { get; set; }//True : PvP, False : PvIA
        public char Vencedor { get; private set; }//O Vencedor da partida
        
        public Partida() { }
        public Partida(bool tipo)
        {
            //Criar um vetor de pecas com o tamanho 9 (3x3)
            Fim = false;
            TipoDePartida = tipo;
        } 
        public void AdicionarPeca(Peca peca)
        {
            if (pecas[peca.Posicao-1] != null)//Verifica se a posição já foi ocupada
            {
                System.Console.WriteLine("Posição já ocupada!");
            }
            else 
            {
                pecas[peca.Posicao-1] = peca;//Adiciona uma peca na posição dela
            }
        }
        public bool VerificarPartida()
        {
            for (int i = 0; i < 2; i++)//Verifica as três linhas horizontais
            {
                if (pecas[0+3*i].Tipo == pecas[1+3*i].Tipo && pecas[0+3*i].Tipo == pecas[2+3*i].Tipo)
                /*Verifica da seguinte maneira:
                Se a peça nas posições forem do mesmo tipo houve uma combinação e o jogador daquele tipo venceu*/
                {
                    Fim = true;
                    Vencedor = pecas[0].Tipo;
                    return true;//Retorno apenas para cortar o metodo
                }
            }
            for (int i = 0; i < 2; i++)//Verifica as três linhas verticais
            {
                if (pecas[0+i].Tipo == pecas[3+i].Tipo && pecas[0+i].Tipo == pecas[6+i].Tipo)
                /*Verifica da seguinte maneira:
                Se a peça nas posições forem do mesmo tipo houve uma combinação e o jogador daquele tipo venceu*/
                {
                    Fim = true;
                    Vencedor = pecas[0].Tipo;
                    return true;//Retorno apenas para cortar o metodo
                }
            }
            if (pecas[0].Tipo == pecas[5].Tipo && pecas[0].Tipo == pecas[8].Tipo)//Verifica a diagonal da esquerda para direita 
            {
                Fim = true;
                Vencedor = pecas[0].Tipo;
                return true;//Retorno apenas para cortar o metodo
            }
            if (pecas[3].Tipo == pecas[5].Tipo && pecas[3].Tipo == pecas[6].Tipo)//Verifica a diagonal da direita para esquerda
            {
                Fim = true;
                Vencedor = pecas[0].Tipo;
                return true;//Retorno apenas para cortar o metodo
            }
            else
            {
                return false;//Caso não aconteça nada retorne falso
            }
        }
        public void ImprimirPartida()
        {
            for(int i = 0; i>2; i++)
            {
                if (pecas[i].Tipo != 'X' && pecas[i].Tipo != 'O')
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(pecas[1].Tipo);
                }
            }
        }
    }
}
