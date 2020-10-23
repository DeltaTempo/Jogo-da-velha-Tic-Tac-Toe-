using System;
namespace Jogo_da_Velha.Entites
{
    class Peca
    {
        public int Posicao { get; set; }//Posição da peça de 1 a 9
        public char Tipo { get; set; }// 'O ou 'X'
        public Peca(int posicao,char tipo)
        {
           Posicao = posicao;
           Tipo = tipo; 
        }
    }
}
