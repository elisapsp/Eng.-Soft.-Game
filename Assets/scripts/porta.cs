using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class porta : MonoBehaviour
{
    private GameObject score;
    private GameObject player;
    private softwareDesenvolvido softwarePlayer;
    private GameObject cliente;
    private GameObject GerenciadorJogo;
    private bool locked;

    // Use this for initialization
    void Start()
    {
        
        player = GameObject.Find("Player");
        locked = true;
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("locked", locked);
        //gameObject.GetComponent<Animator>().SetBool("locked", locked);
        cliente = GameObject.FindGameObjectsWithTag("NPC")[0];
        GerenciadorJogo = GameObject.Find("GerenciadorJogo");
        score = GameObject.Find("score");

    }


    void OnTriggerEnter2D(Collider2D collision)
    {

        int corretoEfunciona = 0;

        //Se quem colidir for um player.
        if (collision.tag == "Player")
        {
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            if (GerenciadorJogo.GetComponent<GerenciadorJogo>().nomeFase == "test1")
            {
               
                int indiceObjetivo = cliente.GetComponent<Cliente>().indiceObjetivo;
                Debug.Log(indiceObjetivo);

                //Se estiver no ultimo objetivo
                if (indiceObjetivo == 3)
                {

                    //contém as informações do software desenvolvido.
                    softwarePlayer = GameObject.Find("Player").GetComponent<softwareDesenvolvido>();

                    //pra cada tipo de software coletado.
                    for (int i = 0; i < 4; i++)
                    {

                        //Se o pedaço de software foi coletado.
                        if (softwarePlayer.coletado[i] == true)
                        {

                            //Se a cor estiver correta.
                            if (softwarePlayer.cores[i] == cliente.GetComponent<Cliente>().objetivo[indiceObjetivo][i])
                            {


                                if (softwarePlayer.funciona[i] == true)
                                {
                                    corretoEfunciona++;
                                }


                            }


                        }




                    }

                    if (corretoEfunciona >= 3 && GerenciadorJogo.GetComponent<GerenciadorJogo>().numBugsCriticos == 0)
                    {

                        locked = false;

                        gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("locked", locked);
                        gameObject.GetComponentInChildren<Animator>().SetBool("locked", locked);

                        OnPressEnter();

                        Debug.Log(locked);
                    }
                    else
                    {
                        locked = true;
                        gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("locked", locked);
                        gameObject.GetComponentInChildren<Animator>().SetBool("locked", locked);
                        Debug.Log(locked);
                    }

                }
                else
                {
                    locked = true;
                    gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("locked", locked);
                    gameObject.GetComponentInChildren<Animator>().SetBool("locked", locked);
                    Debug.Log(locked);

                }
            }
            else if (GerenciadorJogo.GetComponent<GerenciadorJogo>().nomeFase == "test2")
            {
                if (GerenciadorJogo.GetComponent<GerenciadorJogo>().objetivoConcluido == false ||
                    !player.GetComponent<softwareDesenvolvido>().coletado[0] ||
                    !player.GetComponent<softwareDesenvolvido>().coletado[1] ||
                    !player.GetComponent<softwareDesenvolvido>().coletado[2] ||
                    !player.GetComponent<softwareDesenvolvido>().coletado[3])
                {
                    locked = true;
                    gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("locked", locked);
                    gameObject.GetComponentInChildren<Animator>().SetBool("locked", locked);
                    Debug.Log(locked);
                }
                else
                {
                    locked = false;

                    gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("locked", locked);
                    gameObject.GetComponentInChildren<Animator>().SetBool("locked", locked);

                    OnPressEnter();

                    Debug.Log(locked);
                }
            }
    }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.tag == "Player") { 
        if (locked == false) { 
        OnPressEnter();
        }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {

            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;

        }
    }


    public void OnPressEnter()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (score != null && GerenciadorJogo != null) { 
            score.GetComponent<readScore>().score = GerenciadorJogo.GetComponent<GerenciadorJogo>().countDiasTrabalhados;
            if (GerenciadorJogo.GetComponent<GerenciadorJogo>().nomeFase == "test1")
            {
                
                //Pula pra outra fase.
                SceneManager.LoadScene("test2");


            }
            else if (GerenciadorJogo.GetComponent<GerenciadorJogo>().nomeFase == "test2")
            {
            //Pula pra outra fase.
            SceneManager.LoadScene("test3");
            }
            }
        }
    }

}


        
