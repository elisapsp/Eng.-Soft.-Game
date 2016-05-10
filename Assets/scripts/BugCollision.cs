using UnityEngine;
using System.Collections;

public class BugCollision : MonoBehaviour {

    

    //Tipo1, 2 ou 3.
    public int TipoBug;

    private Animator animator;
    private int direcao;
    private int lastdirecao;

    private GameObject Timer;
    private GameObject GerenciadorJogo;

    // Use this for initialization
    void Start () {
        GerenciadorJogo = GameObject.Find("GerenciadorJogo");
        Timer = GameObject.Find("Canvas/Timer/Panel/Text");

        if (TipoBug == 3)
        {
            GameObject.Find("GerenciadorJogo").gameObject.GetComponent<GerenciadorJogo>().numBugsCriticos++;
        }
       

        direcao = gameObject.GetComponent<movimentacaoObjeto>().direcao;

        animator = gameObject.GetComponentInChildren<Animator>();


        if (direcao == 1) { 
            animator.transform.Rotate(0, 180, 0);
        }
    }
	
	// Update is called once per frame
	void Update () {
        lastdirecao = direcao;
        direcao = gameObject.GetComponent<movimentacaoObjeto>().direcao;
        if (lastdirecao != direcao) { 
       
        animator.transform.Rotate(0, 180, 0);
        }
        
    }

    

    //Se colidir, então muda de direcao.
    void OnCollisionEnter2D(Collision2D colisor)
    {
            gameObject.GetComponent<movimentacaoObjeto>().direcao *= -1;
            gameObject.GetComponent<movimentacaoObjeto>().tempo = gameObject.GetComponent<movimentacaoObjeto>().duracaoPosicao - gameObject.GetComponent<movimentacaoObjeto>().tempo;

       
        if (colisor.gameObject.name == "Player")
        {
            //Se o player vier de cima, na colisão e o bug não for o do tipo 3.
            if (colisor.gameObject.GetComponent<Rigidbody2D>().velocity.y != 0 && TipoBug!= 3)
            {
                gameObject.GetComponentInChildren<vidaObjeto>().PerdeVida(10);
                colisor.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up*200f);

            }
            else
            {
                //reduz o tempo da fase em 5 segundos.
                Timer.GetComponent<Timer>().timer -= 5f;

                //deve voltar para o ultimo checkpoint salvo
                colisor.gameObject.GetComponent<Transform>().position = GerenciadorJogo.GetComponent<GerenciadorJogo>().posicaoSalva;
            }
            

        }

        
        
    }



}
