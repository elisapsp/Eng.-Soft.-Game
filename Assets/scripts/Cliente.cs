﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

public class Cliente : MonoBehaviour {


    public GameObject ultimoPedacoSoftware;
    private bool CriouUltimoPedacoSoftware;

    public GameObject DialogBoxText;
    private GameObject tooltip;
    private GameObject GerenciadorJogo;
    private GameObject Timer;
    private Timer tempo;
    private softwareDesenvolvido softwarePlayer;

    private bool GameEND;

    public string[] FalasCliente = new string[3];

    //Contém os objetivos de cada pedaço de software que deve ser coletado.
    public string[][] objetivo = new string[4][];

    //contém o numero do objetivo corrente (0,1,2 ou 3).
    public int indiceObjetivo;

    public GameObject MenuObjetivo;
    private GameObject descricaoObjetivo;

    void limpaArrayFalas()
    {
        for (int i = 0; i < FalasCliente.Length; i++)
        {
            FalasCliente[i] = "";
        }
    }
	// Use this for initialization
	void Start () {

        GameEND = false;
        CriouUltimoPedacoSoftware = false;

        //Limpa o array das falas.
        limpaArrayFalas();
        
        GerenciadorJogo = GameObject.Find("GerenciadorJogo");


        Timer = GameObject.Find("Canvas/Timer/Panel/Text");
        descricaoObjetivo = MenuObjetivo.gameObject.transform.FindChild("Objetivo").gameObject;

        if (GerenciadorJogo.GetComponent<GerenciadorJogo>().nomeFase == "test1")
        {

            indiceObjetivo = 0;
        }
        else if(GerenciadorJogo.GetComponent<GerenciadorJogo>().nomeFase == "test2" || GerenciadorJogo.GetComponent<GerenciadorJogo>().nomeFase == "test3")
        {
            indiceObjetivo = 3;
        }

        if (GerenciadorJogo.GetComponent<GerenciadorJogo>().nomeFase == "test2")
        {
            tooltip = gameObject.transform.FindChild("tooltip").gameObject;
        }


        for (int i = 0; i < objetivo.Length; i++)
        {

                objetivo[i] = new string[4];
        }

        objetivo[0][0] = "red";
        objetivo[0][1] = "red";
        objetivo[0][2] = "green";
        objetivo[0][3] = "green";

        objetivo[1][0] = "red";
        objetivo[1][1] = "green";
        objetivo[1][2] = "blue";
        objetivo[1][3] = "gray";

        objetivo[2][0] = "red";
        objetivo[2][1] = "green";
        objetivo[2][2] = "yellow";
        objetivo[2][3] = "gray";

        objetivo[3][0] = "red";
        objetivo[3][1] = "green";
        objetivo[3][2] = "yellow";
        objetivo[3][3] = "purple";

 
    }

    public void ligacao()
    {
        //Guarda o index da fala no array, para saber onde colocar.
        int indexFala = 0;
        //Limpa as falas antigas.
        limpaArrayFalas();
        
        //Script do tempo da fase.
        tempo = Timer.GetComponent<Timer>();
        //Custo da ligação: 5 segundos do tempo da fase.
        tempo.timer -= 5.0f;

        int corretoEfunciona = 0;

        //Fará a contagem das cores entregues corretamente.
        int numCoresCorretas = 0;

        //Fará a contagem do numero de pedacos de software funcionando (dentro do numero de cores entregues corretamente).
        int numFuncionando = 0;

        //contém as informações do software desenvolvido.
        softwarePlayer = GameObject.Find("Player").GetComponent<softwareDesenvolvido>();

        if (indiceObjetivo > 3)
        {
            indiceObjetivo = 3;
        }

        if (GerenciadorJogo.GetComponent<GerenciadorJogo>().nomeFase == "test1" || GerenciadorJogo.GetComponent<GerenciadorJogo>().nomeFase == "test3")
        {

            //pra cada tipo de software coletado.
            for (int i = 0; i < 4; i++)
            {

                //Se o pedaço de software foi coletado.
                if (softwarePlayer.coletado[i] == true)
                {

                    //Se a cor estiver correta.
                    if (softwarePlayer.cores[i] == objetivo[indiceObjetivo][i])
                    {
                        FalasCliente[indexFala] = FalasCliente[indexFala] + "A cor do pedaço de software do tipo " + (i + 1).ToString() + " está correta." + "\n";
                        numCoresCorretas++;
                        Debug.Log("A cor do pedaço de software do tipo " + (i + 1).ToString() + " está correta.");


                        if (softwarePlayer.funciona[i] == true)
                        {
                            numFuncionando++;
                            corretoEfunciona++;
                        }


                    }
                    else
                    {
                        FalasCliente[indexFala] = FalasCliente[indexFala] + "A cor do pedaço de software do tipo " + (i + 1).ToString() + " não está correta. " + "A cor deste tipo deve ser: " + objetivo[indiceObjetivo][i] + ".\n";
                        Debug.Log("A cor do pedaço de software do tipo " + (i + 1).ToString() + " não está correta.");
                        Debug.Log("A cor deste tipo deve ser: " + objetivo[indiceObjetivo][i]);
                    }





                }
                else
                {
                    FalasCliente[indexFala] = FalasCliente[indexFala] + "Falta o pedaço de software do tipo " + (i + 1).ToString() + "\n";
                    Debug.Log("Falta o pedaço de software do tipo " + (i + 1).ToString());
                }

            }

            indexFala++;

            //no objetivo 1 ou 2.
            if (indiceObjetivo == 1 || indiceObjetivo == 2)
            {
                //Se o jogador tiver pelo menos tres pedaços de software corretos e funcionando.
                if (corretoEfunciona >= 3)
                {
                    //Pula para o próximo objetivo.
                    indiceObjetivo++;
                    FalasCliente[indexFala] = FalasCliente[indexFala] + "Pensando melhor, acho que o software ficará melhor de outro jeito. Aqui vai a minha nova preferência das cores de cada tipo que deve me entregar.\n";
                    for (int i = 0; i < 4; i++)
                    {
                        FalasCliente[indexFala] = FalasCliente[indexFala] + "Cor do pedaço de software tipo " + (i + 1).ToString() + ": " + objetivo[indiceObjetivo][i] + ".\n";
                    }
                    FalasCliente[indexFala] = FalasCliente[indexFala] + "Eliminar os " + GerenciadorJogo.GetComponent<GerenciadorJogo>().numBugsCriticos.ToString() + " bugs críticos restantes.";
                }
            }
            //Se o jogador estiver com o software todo pronto e funcionando.
            else if (numCoresCorretas == 4 && numFuncionando == 4)
            {
                //Pula para o próximo objetivo.
                indiceObjetivo++;

                //Se o jogador não tiver zerado o jogo.
                if (indiceObjetivo < 4)
                {
                    FalasCliente[indexFala] = FalasCliente[indexFala] + "Pensando melhor, acho que o software ficará melhor de outro jeito. Aqui vai a minha nova preferência das cores de cada tipo que deve me entregar.\n";
                    //Muda o objetivo.
                    Debug.Log("Pensando melhor, acho que o software ficará melhor de outro jeito. Aqui vai a minha nova preferência das cores de cada tipo que deve me entregar.");


                    for (int i = 0; i < 4; i++)
                    {
                        FalasCliente[indexFala] = FalasCliente[indexFala] + "Cor do pedaço de software tipo " + (i + 1).ToString() + ": " + objetivo[indiceObjetivo][i] + ".\n";
                        Debug.Log("Cor do pedaço de software tipo " + (i + 1).ToString() + ": " + objetivo[indiceObjetivo][i]);
                    }

                }
                else
                {
                    FalasCliente[indexFala] = FalasCliente[indexFala] + "Pelo que você está me falando, essas são as cores que especifiquei,porém, não consigo usá-lo por telefone. Me encontre para eu utilizar o software e ver se está funcionando.\n";
                    //O jogador zerou o jogo, porém, ele deve encontrar com o cliente para que o cliente use a ultima versão e fale que está bom.
                    Debug.Log("Pelo que você está me falando, essas são as cores que especifiquei,porém, não consigo usá-lo por telefone. Me encontre para eu utilizar o software e ver se está funcionando.");
                }

            }
            else if (numCoresCorretas > 0)
            {
                FalasCliente[indexFala] = FalasCliente[indexFala] + "Pelo que você está me falando, algumas desses pedaços de software já estão com as cores que especifiquei,porém, não consigo usá-lo por telefone. Quando achar necessário, me encontre para eu utilizar esses pedaços de software com as cores corretas e ver se está funcionando.\n";
                Debug.Log("Pelo que você está me falando, algumas desses pedaços de software já estão com as cores que especifiquei,porém, não consigo usá-lo por telefone. Quando achar necessário, me encontre para eu utilizar esses pedaços de software com as cores corretas e ver se está funcionando.");

            }
            else
            {
                FalasCliente[indexFala] = FalasCliente[indexFala] + "Nada está de acordo com o que eu pedi!";
            }

        }
        else if (GerenciadorJogo.GetComponent<GerenciadorJogo>().nomeFase == "test2")
        {
         

        }
        //DialogBoxText.transform.parent.gameObject.SetActive(true);

        DialogBoxText.GetComponent<ImportText>().text = FalasCliente;
        
    
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        
            int corretoEfunciona = 0;
        //Se quem colidir for um player.

        if (collision.tag == "Player")
        {

            //Limpa as falas antigas.
            limpaArrayFalas();

            //Guarda o index da fala no array, para saber onde colocar.
            int indexFala = 0;


            //Fará a contagem das cores entregues corretamente.
            int numCoresCorretas = 0;

            //Fará a contagem do numero de pedacos de software funcionando (dentro do numero de cores entregues corretamente).
            int numFuncionando = 0;

            //contém as informações do software desenvolvido.
            softwarePlayer = GameObject.Find("Player").GetComponent<softwareDesenvolvido>();

            if (indiceObjetivo > 3)
            {
                indiceObjetivo = 3;
            }

            if (GerenciadorJogo.GetComponent<GerenciadorJogo>().nomeFase == "test1" || GerenciadorJogo.GetComponent<GerenciadorJogo>().nomeFase == "test3")
            {

                //pra cada tipo de software coletado.
                for (int i = 0; i < 4; i++)
                {

                    //Se o pedaço de software foi coletado.
                    if (softwarePlayer.coletado[i] == true)
                    {

                        //Se a cor estiver correta.
                        if (softwarePlayer.cores[i] == objetivo[indiceObjetivo][i])
                        {
                            numCoresCorretas++;
                            //Debug.Log("A cor do pedaço de software do tipo " + (i + 1).ToString() + " está correta.\n");

                            FalasCliente[indexFala] = FalasCliente[indexFala] + "A cor do pedaço de software do tipo " + (i + 1).ToString() + " está correta.\n";

                            if (softwarePlayer.funciona[i] == true)
                            {
                                numFuncionando++;
                                corretoEfunciona++;
                            }


                        }
                        else
                        {
                            FalasCliente[indexFala] = FalasCliente[indexFala] + "A cor do pedaço de software do tipo " + (i + 1).ToString() + " não está correta." + "A cor deste tipo deve ser: " + objetivo[indiceObjetivo][i] + ".\n";
                            //Debug.Log("A cor do pedaço de software do tipo " + (i + 1).ToString() + " não está correta.");
                            //Debug.Log("A cor deste tipo deve ser: " + objetivo[indiceObjetivo][i]);
                        }





                    }
                    else
                    {
                        FalasCliente[indexFala] = FalasCliente[indexFala] + "Falta o pedaço de software do tipo " + (i + 1).ToString() + ".\n";
                        //Debug.Log("Falta o pedaço de software do tipo " + (i + 1).ToString());
                    }



                }

                indexFala++;

                if (numCoresCorretas > 0)
                {
                    if (numCoresCorretas == numFuncionando)
                    {
                        FalasCliente[indexFala] = FalasCliente[indexFala] + "Acabei de usar as partes com cores corretas que você me entregou. Tudo está funcionando!\n";
                        //Debug.Log("Acabei de usar as partes com cores corretas que você me entregou. Tudo está funcionando!");
                    }
                    else
                    {
                        FalasCliente[indexFala] = FalasCliente[indexFala] + "Acabei de usar as partes com cores corretas que você me entregou. Não está funcionando!";
                        //Debug.Log("Acabei de usar as partes com cores corretas que você me entregou. Não está funcionando!");
                    }
                }
                else
                {
                    FalasCliente[indexFala] = FalasCliente[indexFala] + "Nada está de acordo com o que eu pedi!";
                    //Debug.Log("Tudo que me entregou não está de acordo com o que eu pedi!");
                }

                indexFala++;

                //no objetivo 1 ou 2.
                if (indiceObjetivo == 1 || indiceObjetivo == 2)
                {
                    //Se o jogador tiver pelo menos tres pedaços de software corretos e funcionando.
                    if (corretoEfunciona >= 3)
                    {
                        //Pula para o próximo objetivo.
                        indiceObjetivo++;
                        FalasCliente[indexFala] = FalasCliente[indexFala] + "Pensando melhor, acho que o software ficará melhor de outro jeito. Aqui vai a minha nova preferência das cores de cada tipo que deve me entregar.\n";
                        for (int i = 0; i < 4; i++)
                        {
                            FalasCliente[indexFala] = FalasCliente[indexFala] + "Cor do pedaço de software tipo " + (i + 1).ToString() + ": " + objetivo[indiceObjetivo][i] + ".\n";
                        }
                        FalasCliente[indexFala] = FalasCliente[indexFala] + "Eliminar os " + GerenciadorJogo.GetComponent<GerenciadorJogo>().numBugsCriticos.ToString() + " bugs críticos restantes.";
                    }
                }
                //Se o jogador estiver com o software todo pronto e funcionando.
                else if (numCoresCorretas == 4 && numFuncionando == 4)
                {
                    indiceObjetivo++;

                    //O jogador zerou o jogo.
                    if (indiceObjetivo == 4)
                    {
                        if (GerenciadorJogo.GetComponent<GerenciadorJogo>().numBugsCriticos == 0)
                        {
                            GerenciadorJogo.GetComponent<GerenciadorJogo>().objetivoConcluido = true;
                            FalasCliente[indexFala] = FalasCliente[indexFala] + "Muito obrigado! Esse software é exatamente o que eu imaginei! Muito obrigado pelo serviço!\n";
                            //Debug.Log("Muito obrigado! Esse software é exatamente o que eu imaginei! Muito obrigado pelo serviço!");
                        }
                        else
                        {
                            FalasCliente[indexFala] = FalasCliente[indexFala] + "Tudo parece correto, porém ao utilizar o software, percebo alguns bugs criticos nele. Elimine todos os bugs críticos antes de me entregar o produto final.";
                            //Debug.Log("Tudo parece correto, porém ao utilizar o software, percebo alguns bugs criticos nele. Elimine todos os bugs críticos antes de me entregar o produto final.");
                        }
                    }
                    else
                    {

                        FalasCliente[indexFala] = FalasCliente[indexFala] + "Porém, pensando melhor, acho que o software ficará melhor de outro jeito. Aqui vai a minha nova preferência das cores de cada tipo que deve me entregar.\n";
                        //Muda o objetivo.
                        //Debug.Log("Porém, pensando melhor, acho que o software ficará melhor de outro jeito. Aqui vai a minha nova preferência das cores de cada tipo que deve me entregar.");


                        for (int i = 0; i < 4; i++)
                        {
                            FalasCliente[indexFala] = FalasCliente[indexFala] + "Cor do pedaço de software tipo " + (i + 1).ToString() + ": " + objetivo[indiceObjetivo][i] + "\n";
                            //Debug.Log("Cor do pedaço de software tipo " + (i + 1).ToString() + ": " + objetivo[indiceObjetivo][i]);
                        }
                        FalasCliente[indexFala] = FalasCliente[indexFala] + "Eliminar os " + GerenciadorJogo.GetComponent<GerenciadorJogo>().numBugsCriticos.ToString() + " bugs críticos restantes.";
                        //Debug.Log("Eliminar os " + GerenciadorJogo.GetComponent<GerenciadorJogo>().numBugsCriticos.ToString() + " bugs críticos restantes.");
                    }


                }
            }
            else if (GerenciadorJogo.GetComponent<GerenciadorJogo>().nomeFase == "test2")
            {
                if (GerenciadorJogo.GetComponent<GerenciadorJogo>().objetivoConcluido == false)
                {
                    FalasCliente[indexFala] = FalasCliente[indexFala] + "Olá desenvolvedor, eu estou com o seu ultimo pedaço de software. Posso lhe entregar caso responda as minhas 5 perguntas. ";
                    indexFala++;
                    FalasCliente[indexFala] += "Não serão perguntas fáceis, então caso queira estudar antes, temos todo o conteúdo para ser estudado ao redor desta fase.";
                    indexFala++;
                    FalasCliente[indexFala] += "Quando quiser responder as perguntas, venha até mim e aperte enter para iniciar. Caso erre alguma pergunta, o número de dias trabalhados será aumentado em 1! Boa sorte!";

                    tooltip.GetComponent<SpriteRenderer>().enabled = true;
                    OnPressEnter();
                }
                else
                {
                    FalasCliente[indexFala] = FalasCliente[indexFala] + "Parabéns, você se mostrou um profissional muito capacitado. Não irei interferir mais na sua demanda. Está aqui o seu pedaço de software.";
                }


                
                
            }

           


        }

        
        /*
        Debug.Log("Fala do cliente: " + FalasCliente[0]);
        Debug.Log("Fala do cliente: " + FalasCliente[1]);
        Debug.Log("Fala do cliente: " + FalasCliente[2]);
        */
        //Timer.GetComponent<Timer>().freeze = true;

        GerenciadorJogo.GetComponent<OnePanelAtOnce>().cleanAllPanels();

        DialogBoxText.transform.parent.gameObject.SetActive(true);
        
        DialogBoxText.GetComponent<ImportText>().text = FalasCliente;
    }

    private void criaUltimoPedacoSoftware()
    {
        if (GerenciadorJogo.GetComponent<GerenciadorJogo>().nomeFase == "test2") { 
            if (CriouUltimoPedacoSoftware == false && GerenciadorJogo.GetComponent<GerenciadorJogo>().objetivoConcluido)
        {
            ultimoPedacoSoftware.gameObject.SetActive(true);
            CriouUltimoPedacoSoftware = true;
        }
        }
    }

    public void descreveObjetivo()
    {

       
        
        descricaoObjetivo.GetComponent<Text>().text = "";

        

            if (indiceObjetivo > 3)
            {
                indiceObjetivo = 3;
            }

      
        if (GerenciadorJogo.GetComponent<GerenciadorJogo>().objetivoConcluido == false)
        {
            if (GerenciadorJogo.GetComponent<GerenciadorJogo>().nomeFase == "test1" || GerenciadorJogo.GetComponent<GerenciadorJogo>().nomeFase == "test3")
            {
                for (int i = 0; i < 4; i++)
                {
                    descricaoObjetivo.GetComponent<Text>().text += "Cor do pedaço de software tipo " + (i + 1).ToString() + ": " + objetivo[indiceObjetivo][i] + "\n";
                    //Debug.Log("Cor do pedaço de software tipo " + (i + 1).ToString() + ": " + objetivo[indiceObjetivo][i]);
                }
                descricaoObjetivo.GetComponent<Text>().text += "Eliminar os " + GerenciadorJogo.GetComponent<GerenciadorJogo>().numBugsCriticos.ToString() + " bugs críticos restantes." + "\n";
                //Debug.Log("Eliminar os " + GerenciadorJogo.GetComponent<GerenciadorJogo>().numBugsCriticos.ToString() + " bugs críticos restantes.");

            }
            else if(GerenciadorJogo.GetComponent<GerenciadorJogo>().nomeFase == "test2")
            {
                descricaoObjetivo.GetComponent<Text>().text += "Responder todas as 5 perguntas do seu chefe sem errar.";
            }
        }
        else
        {
            descricaoObjetivo.GetComponent<Text>().text += "Objetivos concluídos com sucesso!";
            Debug.Log("Objetivos concluídos com sucesso!");

        }
    }


        // Update is called once per frame
    void Update () {

        criaUltimoPedacoSoftware();
        goToGameEnd();
    }

    private void goToGameEnd()
    {
        if (GerenciadorJogo.GetComponent<GerenciadorJogo>().nomeFase == "test3")
        {
            GameObject[] PopUpMenus = GameObject.FindGameObjectsWithTag("PopUpMenu");
            if (PopUpMenus.Length == 0 && GerenciadorJogo.GetComponent<GerenciadorJogo>().objetivoConcluido)
            {
               
                    GameEND = true;
               
            }

            if (GameEND)
            {
                SceneManager.LoadScene("test1");
            }
        }

       
    }

    void OnTriggerExit2D(Collider2D collision)
    {

        //Se quem colidir for um player.
        if (collision.tag == "Player")
        {
            if (GerenciadorJogo.GetComponent<GerenciadorJogo>().nomeFase == "test2") { 
                tooltip.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (GerenciadorJogo.GetComponent<GerenciadorJogo>().nomeFase == "test2") { 
                OnPressEnter();
            }
        }
    }

    //Função OnPressEnter chamará o jogo de perguntas e respostas. Caso o jogador conclua 
    //com sucesso, a variável GerenciadorJogo.GetComponent<GerenciadorJogo>().objetivoConcluido deve ser setada como true.
    public void OnPressEnter()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {



        }

    }

}
