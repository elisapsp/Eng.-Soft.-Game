using UnityEngine;
using System.Collections;

public class BugCollision : MonoBehaviour {

    /*
     
        Falta implementar colisão. Algoritmo já está setado.

     */

    //Tipo1, 2 ou 3.
    public int TipoBug;

    private Animator animator;
    private int direcao;
    private int lastdirecao;

    // Use this for initialization
    void Start () {

       

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

    }



}
