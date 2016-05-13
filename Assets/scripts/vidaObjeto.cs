using UnityEngine;
using System.Collections;

public class vidaObjeto : MonoBehaviour {


    private GameObject GerenciadorJogo;
    public int maxVida;
    private int vidaAtual;
    private Animator animator;

    // Use this for initialization
    void Start () {

        GerenciadorJogo = GameObject.Find("GerenciadorJogo").gameObject;
        //Vida
        vidaAtual = maxVida;
        animator = gameObject.GetComponent<Animator>();
        animator.SetInteger("lifeSprite",12);
    }

    // Update is called once per frame
    void Update () {
	
	}

    //barraVida.GetComponent<GUIText>().
    public void PerdeVida(int dano)
    {
        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            animator.SetInteger("lifeSprite", 0);
            //Se for o tipo de bug que morreu foi o bug crítico (tipo 3).
            if (gameObject.GetComponentInParent<BugCollision>().TipoBug == 3)
            {
                //Então diminui o big crítico do contador de bugs.
               GerenciadorJogo.GetComponent<GerenciadorJogo>().numBugsCriticos--;
            }

            DestroyObject(gameObject.transform.parent.gameObject);
        }

        animator.SetInteger("lifeSprite", vidaAtual * 12 / maxVida);
        

     
    }

 

}
