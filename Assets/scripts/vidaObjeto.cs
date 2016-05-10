using UnityEngine;
using System.Collections;

public class vidaObjeto : MonoBehaviour {


    private GameObject GerenciadorJogo;
    public int maxVida;
    private int vidaAtual;

    // Use this for initialization
    void Start () {

        GerenciadorJogo = GameObject.Find("GerenciadorJogo").gameObject;
        //Vida
        vidaAtual = maxVida;
        gameObject.GetComponent<GUIText>().color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
        //barraVida.GetComponent<GUIText>().color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
        gameObject.GetComponent<GUIText>().text = "HP: " + vidaAtual + "/" + maxVida;
        //barraVida.GetComponent<GUIText>().text = "HP: " + vidaAtual + "/" + maxVida;
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
            //Se for o tipo de bug que morreu foi o bug crítico (tipo 3).
            if (gameObject.GetComponentInParent<BugCollision>().TipoBug == 3)
            {
                //Então diminui o big crítico do contador de bugs.
               GerenciadorJogo.GetComponent<GerenciadorJogo>().numBugsCriticos--;
            }

            DestroyObject(gameObject.transform.parent.gameObject);
        }

        if ((vidaAtual * 100 / maxVida) < 30)
        {
            gameObject.GetComponent<GUIText>().color = Color.red;
        }

        gameObject.GetComponent<GUIText>().text = "HP: " + vidaAtual + "/" + maxVida;
    }

    public void RecuperaVida(int recupera)
    {
        vidaAtual += recupera;

        if (vidaAtual > maxVida)
        {
            vidaAtual = maxVida;
        }

        if ((vidaAtual * 100 / maxVida) >= 30)
        {
            gameObject.GetComponent<GUIText>().color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
        }

        gameObject.GetComponent<GUIText>().text = "HP: " + vidaAtual + "/" + maxVida;
    }

}
