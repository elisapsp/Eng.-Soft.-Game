using UnityEngine;
using System.Collections;

public class Cliente : MonoBehaviour {



    private softwareDesenvolvido softwarePlayer;
    
    //Contém os objetivos de cada pedaço de software que deve ser coletado.
    public string[][] objetivo = new string[4][];

    //contém o numero do objetivo corrente (0,1,2 ou 3).
    public int indiceObjetivo;

   
	// Use this for initialization
	void Start () {

        indiceObjetivo = 0;


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

        //Fará a contagem das cores entregues corretamente.
        int numCoresCorretas = 0;

        //Fará a contagem do numero de pedacos de software funcionando (dentro do numero de cores entregues corretamente).
        int numFuncionando = 0;

        //contém as informações do software desenvolvido.
        softwarePlayer = GameObject.Find("Player").GetComponent<softwareDesenvolvido>();

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
                    Debug.Log("A cor do pedaço de software do tipo " + (i + 1).ToString() + " está correta.");


                    if (softwarePlayer.funciona[i] == true)
                    {
                        numFuncionando++;
                    }


                }
                else
                {
                    Debug.Log("A cor do pedaço de software do tipo " + (i + 1).ToString() + " não está correta.");
                    Debug.Log("A cor deste tipo deve ser: " + objetivo[indiceObjetivo][i]);
                }





            }
            else
            {
                Debug.Log("Falta o pedaço de software do tipo " + (i + 1).ToString());
            }

        }

        //Se o jogador estiver com o software todo pronto e funcionando.
        if (numCoresCorretas == 4 && numFuncionando == 4)
        {
            //Pula para o próximo objetivo.
            indiceObjetivo++;

            //Se o jogador não tiver zerado o jogo.
            if (indiceObjetivo < 4)
            {
                //Muda o objetivo.
                Debug.Log("Pensando melhor, acho que o software ficará melhor de outro jeito. Aqui vai a minha nova preferência das cores de cada tipo que deve me entregar.");


                for (int i = 0; i < 4; i++)
                {
                    Debug.Log("Cor do pedaço de software tipo " + (i + 1).ToString() + ": " + objetivo[indiceObjetivo][i]);
                }
            }
            else
            {
                //O jogador zerou o jogo, porém, ele deve encontrar com o cliente para que o cliente use a ultima versão e fale que está bom.
                Debug.Log("Pelo que você está me falando, essas são as cores que especifiquei,porém, não consigo usá-lo por telefone. Me encontre para eu utilizar o software e ver se está funcionando.");
            }

        }
        else if (numCoresCorretas > 0)
        {
            
            Debug.Log("Pelo que você está me falando, algumas desses pedaços de software já estão com as cores que especifiquei,porém, não consigo usá-lo por telefone. Quando achar necessário, me encontre para eu utilizar esses pedaços de software com as cores corretas e ver se está funcionando.");

        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Se quem colidir for um player.
        if (collision.tag == "Player")
        {
            
        //Fará a contagem das cores entregues corretamente.
        int numCoresCorretas = 0;

        //Fará a contagem do numero de pedacos de software funcionando (dentro do numero de cores entregues corretamente).
        int numFuncionando = 0;

        //contém as informações do software desenvolvido.
        softwarePlayer = GameObject.Find("Player").GetComponent<softwareDesenvolvido>();

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
                    Debug.Log("A cor do pedaço de software do tipo " + (i + 1).ToString() + " está correta.");


                    if (softwarePlayer.funciona[i] == true)
                    {
                        numFuncionando++;
                    }


                }
                else
                {
                    Debug.Log("A cor do pedaço de software do tipo " + (i + 1).ToString() + " não está correta.");
                    Debug.Log("A cor deste tipo deve ser: " + objetivo[indiceObjetivo][i]);
                }

                



            }
            else
            {
                Debug.Log("Falta o pedaço de software do tipo " + (i + 1).ToString());
            }



        }

        if (numCoresCorretas > 0)
        {
            if (numCoresCorretas == numFuncionando)
            {
                Debug.Log("Acabei de usar as partes com cores corretas que você me entregou. Tudo está funcionando!");
            }
            else
            {
                Debug.Log("Acabei de usar as partes com cores corretas que você me entregou. Não está funcionando!");
            }
        }
        else
        {
            Debug.Log("Tudo que me entregou não está de acordo com o que eu pedi!");
        }

        if (numCoresCorretas == 4 && numFuncionando == 4)
        {
            indiceObjetivo++;

            //O jogador zerou o jogo.
            if (indiceObjetivo == 4)
            {
                Debug.Log("Muito obrigado! Esse software é exatamente o que eu imaginei! Muito obrigado pelo serviço!");
            }
            else
            {
                //Muda o objetivo.
                Debug.Log("Porém, pensando melhor, acho que o software ficará melhor de outro jeito. Aqui vai a minha nova preferência das cores de cada tipo que deve me entregar.");


                for (int i = 0; i < 4; i++)
                {
                    Debug.Log("Cor do pedaço de software tipo " + (i + 1).ToString() + ": " + objetivo[indiceObjetivo][i]);
                }
            }

            
        }
        }
    }
        /*
        Fazer:

        OnCollision: atualiza o softwarePlayer.

        função verificaSoftwarePorTelefone:
        função verificaSoftwarePresencialmente:

        */


        // Update is called once per frame
        void Update () {
      
        

    }



}
