using System;
using Jogo_da_Velha.Entites;
namespace Jogo_da_Velha.IA
{
    class InteligenciaArtificial
    {
        //Metodo para a jogada da IA
        public char PecaDaIA { get; set; }
        public InteligenciaArtificial(char pecaIA)
        {
            PecaDaIA = pecaIA;
        }

        public bool Jogada(Partida p)
        {
            for (int i = 0; i < 3; i++)//Percorre as três linhas horizontais
            {
                if (p.pecas[3 * i] == p.pecas[3 * i + 1] && p.pecas[3 * i] != 'N' && p.pecas[3 * i + 2] == 'N')
                //Se já tiver duas peças iguais na mesma linha, cubra a vaga que resta
                {
                    p.pecas[3 * i + 2] = PecaDaIA;
                    return true;
                }
                else if (p.pecas[3 * i + 1] == p.pecas[3 * i + 2] && p.pecas[3 * i + 1] != 'N' && p.pecas[3 * i] == 'N')
                {

                    p.pecas[3 * i] = PecaDaIA;
                    return true;

                }
                else if (p.pecas[3 * i] == p.pecas[3 * i + 2] && p.pecas[3 * i] != 'N' && p.pecas[3 * i + 1] == 'N')
                {

                    p.pecas[3 * i + 1] = PecaDaIA;
                    return true;

                }

            }
            for (int i = 0; i < 3; i++)//Verifica as três linhas verticais
            {
                if (p.pecas[i] == p.pecas[i + 3] && p.pecas[i] != 'N' && p.pecas[i + 6] == 'N')
                {

                    p.pecas[i + 6] = PecaDaIA;
                    return true;


                }
                else if (p.pecas[i + 3] == p.pecas[i + 6] && p.pecas[i + 3] != 'N' && p.pecas[i] == 'N')
                {

                    p.pecas[i] = PecaDaIA;
                    return true;

                }
                else if (p.pecas[i] == p.pecas[i + 6] && p.pecas[i] != 'N' && p.pecas[i + 3] == 'N')
                {

                    p.pecas[i + 3] = PecaDaIA;
                    return true;

                }
            }
            if (p.pecas[0] == p.pecas[4] && p.pecas[0] != 'N' && p.pecas[8] == 'N')//Verifica as diagonais e cubra a que faltar
            {

                p.pecas[8] = PecaDaIA;
                return true;//Retorno apenas para cortar o metodo

            }
            else if (p.pecas[0] == p.pecas[8] && p.pecas[0] != 'N' && p.pecas[4] == 'N')//Verifica a diagonal da esquerda para direita 
            {

                p.pecas[4] = PecaDaIA;
                return true;//Retorno apenas para cortar o metodo

            }
            else if (p.pecas[4] == p.pecas[8] && p.pecas[4] != 'N' && p.pecas[0] == 'N')//Verifica a diagonal da esquerda para direita 
            {

                p.pecas[0] = PecaDaIA;
                return true;//Retorno apenas para cortar o metodo

            }
            else if (p.pecas[2] == p.pecas[4] && p.pecas[2] != 'N' && p.pecas[6] == 'N')//Verifica a diagonal da direita para esquerda
            {

                p.pecas[6] = PecaDaIA;
                return true;//Retorno apenas para cortar o metodo

            }
            else if (p.pecas[2] == p.pecas[6] && p.pecas[2] != 'N' && p.pecas[4] == 'N')//Verifica a diagonal da direita para esquerda
            {

                p.pecas[4] = PecaDaIA;
                return true;//Retorno apenas para cortar o metodo

            }
            else if (p.pecas[4] == p.pecas[6] && p.pecas[4] != 'N' && p.pecas[2] == 'N')//Verifica a diagonal da direita para esquerda
            {

                p.pecas[2] = PecaDaIA;
                return true;//Retorno apenas para cortar o metodo
            }
            else//De qualquer maneira, caso nenhuma das opções acima ocorra, jogue aleatoriamente
            {
                Random random = new Random();
                int nRandom = 4;
                for (int i = 0; p.pecas[nRandom] != 'N'; i++)
                {
                    nRandom = random.Next(8);
                }
                p.pecas[nRandom] = PecaDaIA;
                return true;
            }
        }
    }
}
