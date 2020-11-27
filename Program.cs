using System;
using System.Linq;
using Jogo_da_Velha.Entites;
using Jogo_da_Velha.IA;

namespace Jogo_da_Velha
{
    class Program
    {
        static void Main(string[] args)
        {
            char programa = 's';//Repetição em caso de erros
            while (programa == 's')
            {
                try
                {
                    //Valores padrão:
                    bool tipo = true;
                    int VitoriasDoJogador1 = 0;
                    int VitoriasDoJogador2 = 0;
                    char jogador1 = 'X';
                    char jogador2 = 'O';
                    int Empates = 0;
                    char jogadorDaVez = 'X';//Primeiro a jogar é o X
                    char continuacao = 's';//Repetição enquanto quiser continuar jogando
                    Console.WriteLine("Teclas:");
                    Console.WriteLine(" 7 | 8 | 9 ");
                    Console.WriteLine("---+---+---");
                    Console.WriteLine(" 4 | 5 | 6 ");
                    Console.WriteLine("---+---+---");
                    Console.WriteLine(" 1 | 2 | 3 ");
                    char rIA = 'o';
                    while (rIA != 'n' && rIA != 's')//Se a resposta for diferente da esperada repita a pergunta
                    {
                        Console.Write("Quer jogar contra a IA(s/n)? ");
                        rIA = char.Parse(Console.ReadLine());
                        if (rIA == 's')
                        {
                            tipo = true;
                        }
                        else
                        {
                            tipo = false;
                        }
                    }

                    while (continuacao == 's')
                    {
                        jogadorDaVez = 'X';//Primeiro a jogar é o X
                        Partida partida = new Partida(tipo);//Inicia nova partida
                        InteligenciaArtificial jogadorIA = new InteligenciaArtificial(jogador2);//Cria um jogador artificial opcional 
                        while (!partida.Fim)//Enquanto a partida não acabar repita
                        {
                            int turno = partida.pecas.Where(p => p != 'N').Count() + 1;
                            //Para saber o turno: filtre as peças que foram colocadas e as conte
                            Console.Clear();
                            Console.WriteLine("Turno atual: " + turno);
                            Console.WriteLine("Placar:");
                            Console.WriteLine("Jogador 1: " + VitoriasDoJogador1);
                            Console.WriteLine("Jogador 2: " + VitoriasDoJogador2);
                            Console.WriteLine("Velhas: " + Empates);
                            Console.Write("Jogador 1:" + jogador1 + ", Jogador 2:" + jogador2);
                            Console.WriteLine();

                            partida.ImprimirPartida();//Imprime tabuleiro

                            Console.WriteLine("jogador dessa vez:" + jogadorDaVez);
                            //Bloco da jogada:
                            if (jogadorDaVez != jogadorIA.PecaDaIA || partida.TipoDePartida == false)
                                //Apenas peça a jogada se for a vez de um player 
                            {

                                if (jogador1 == jogadorDaVez)
                                {
                                    Console.Write($"Vez do jogador 1 de {jogadorDaVez}(digite 'desistir' para desistir) ");
                                }
                                else if (partida.TipoDePartida == false)
                                {
                                    Console.Write($"Vez do jogador 2 de {jogadorDaVez}(digite 'desistir' para desistir) ");
                                }
                                string resposta = Console.ReadLine();
                                if (resposta == "desistir")//Se houver desistencia finalize a partida
                                {
                                    Console.WriteLine("Desistencia");
                                    if (jogadorDaVez == 'O')
                                    {
                                        partida.Fim = true;
                                        partida.Vencedor = 'X';

                                    }
                                    if (jogadorDaVez == 'X')
                                    {
                                        partida.Fim = true;
                                        partida.Vencedor = 'O';

                                    }
                                }
                                else
                                {
                                    int r = int.Parse(resposta);
                                    bool exitoNaJogada = false;
                                    while (exitoNaJogada == false)//Se a jogada falhar repita
                                    {
                                        if (r <= 9 && r > 0 && r != 0 && partida.VerificarPosicao(r.Converter() - 1) == false)
                                        //Se a posição for valida e está vaga adicione a peça
                                        {
                                            partida.pecas[r.Converter() - 1] = jogadorDaVez;
                                            exitoNaJogada = true;

                                        }
                                        else
                                        {
                                            Console.WriteLine("Posição invalida, tente novamente!");
                                            if (jogador1 == jogadorDaVez)
                                            {
                                                Console.Write($"Vez do jogador 1 de {jogadorDaVez}(digite 'desistir' para desistir) ");
                                            }
                                            else if (partida.TipoDePartida == false)
                                            {
                                                Console.Write($"Vez do jogador 2 de {jogadorDaVez}(digite 'desistir' para desistir) ");
                                            }
                                            r = int.Parse(Console.ReadLine());
                                        }
                                    }
                                }
                            }
                            else if (partida.TipoDePartida == true)
                            {
                                if(jogadorIA.Jogada(partida) == false)
                                {
                                    throw new Exceptions.Excecoes("Falha na jogada da IA no turno:" + (turno - 1));
                                }
                            }

                            if (jogadorDaVez == 'X')
                            {
                                jogadorDaVez = 'O';//Alterna de jogador X para O
                            }
                            else
                            {
                                jogadorDaVez = 'X';//Alterna de jogador O para X
                            }
                            partida.VerificarPartida();//Verifica se a partida já acabou
                                                       //Fim do bloco de jogada
                        }
                        //Bloco de finalização:
                        Console.Clear();
                        Console.WriteLine("Placar:");//Mostre o placar
                        Console.WriteLine("Jogador 1: " + VitoriasDoJogador1);
                        Console.WriteLine("Jogador 2: " + VitoriasDoJogador2);
                        Console.WriteLine("Velhas: " + Empates);
                        Console.WriteLine();

                        partida.ImprimirPartida();//Mostre as posições finais da partida
                        Console.WriteLine("Fim de jogo!");
                        if (partida.Vencedor == 'X')//Imprimir qual foi o vencedor
                        {
                            if (jogador1 == 'X')
                            {
                                Console.WriteLine("Vitoria do Jogador 1!");
                                VitoriasDoJogador1 += 1;
                            }
                            else
                            {
                                Console.WriteLine("Vitoria do Jogador 2!");
                                VitoriasDoJogador2 += 1;
                            }
                        }
                        if (partida.Vencedor == 'O')
                        {
                            if (jogador1 == 'O')
                            {
                                Console.WriteLine("Vitoria do Jogador1!");
                                VitoriasDoJogador1 += 1;
                            }
                            else
                            {
                                Console.WriteLine("Vitoria do Jogador2!");
                                VitoriasDoJogador2 += 1;
                            }
                        }
                        if (partida.Vencedor == 'N')
                        {
                            Console.WriteLine("Velha!");
                            Empates += 1;
                        }
                        if (jogador1 == 'X')//Altera o tipo de peça de cada jogador
                        {
                            jogador1 = 'O';
                            jogador2 = 'X';
                            jogadorIA.PecaDaIA = jogador2;
                        }
                        else
                        {
                            jogador1 = 'X';
                            jogador2 = 'O';
                            jogadorIA.PecaDaIA = jogador2;
                        }
                        bool protecaoDeRepeticao = true;
                        while (protecaoDeRepeticao)
                        {
                            Console.Write("Deseja jogar novamente?(s/n) ");
                            continuacao = char.Parse(Console.ReadLine());
                            programa = continuacao;//Se o usuario já não quiser continuar apenas finalize o programa
                            if (continuacao != 'n' && continuacao != 's')//Se a resposta for diferente da esperada, repita a pergunta
                            {
                                Console.WriteLine("Resposta inesperada.Tente novamente");
                            }
                            else
                            {
                                protecaoDeRepeticao = false;//Se for esperada não repita
                            }
                        }
                        
                        Console.Clear();

                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine("Erro fatal: " + e.Message);
                    bool r = true;
                    while (r == true)
                    {
                        Console.Write("Deseja reiniciar o programa(s/n)? ");
                        char resposta = char.Parse(Console.ReadLine());
                        if (resposta != 's' && resposta != 'n')
                        {
                            Console.WriteLine("Valor não esperado! Tente novamente");
                        }
                        else
                        {
                            r = false;
                            programa = resposta;
                            Console.Clear();
                        }
                    }
                }
            }
        }
    }
}
