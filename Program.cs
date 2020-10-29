using System;
using Jogo_da_Velha.Entites;

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
                    Console.WriteLine("Pressione qualquer tecla para começar...");
                    Console.ReadKey();
                    while (continuacao == 's')
                    {

                        jogadorDaVez = 'X';//Primeiro a jogar é o X
                        Partida partida = new Partida(tipo);//Inicia nova partida

                        while (!partida.Fim)//Enquanto a partida não acabar repita
                        {
                            Console.Clear();
                            Console.WriteLine("Placar:");
                            Console.WriteLine("Jogador 1: " + VitoriasDoJogador1);
                            Console.WriteLine("Jogador 2: " + VitoriasDoJogador2);
                            Console.WriteLine("Velhas: " + Empates);
                            Console.Write("Jogador 1:" + jogador1 + ", Jogador 2:" + jogador2);
                            Console.WriteLine();
                            Console.WriteLine();

                            partida.ImprimirPartida();//Imprime tabuleiro

                            Console.WriteLine();//Bloco da jogada
                            if (jogador1 == jogadorDaVez)
                            {
                                Console.Write($"Vez do jogador 1 de {jogadorDaVez}(digite 'desistir' para desistir) ");
                            }
                            else
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

                                        if (jogadorDaVez == 'X')
                                        {
                                            jogadorDaVez = 'O';//Alterna de jogador X para O
                                        }
                                        else
                                        {
                                            jogadorDaVez = 'X';//Alterna de jogador O para X
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Posição invalida, tente novamente!");
                                        if (jogador1 == jogadorDaVez)
                                        {
                                            Console.Write($"Vez do jogador 1 de {jogadorDaVez}(digite 'desistir' para desistir) ");
                                        }
                                        else
                                        {
                                            Console.Write($"Vez do jogador 2 de {jogadorDaVez}(digite 'desistir' para desistir) ");
                                        }
                                        r = int.Parse(Console.ReadLine());
                                    }
                                }
                            }
                            partida.VerificarPartida();//Verifica se a partida já acabou
                                                       //Fim do bloco de jogada
                        }
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
                        }
                        else
                        {
                            jogador1 = 'X';
                            jogador2 = 'O';
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
                        jogadorDaVez = 'X';
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
