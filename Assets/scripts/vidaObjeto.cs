using UnityEngine;
using System.Collections;

public class vidaObjeto : MonoBehaviour {

    public GameObject barraVida;
    public int maxVida;
    private int vidaAtual;

    // Use this for initialization
    void Start () {

        //Vida
        vidaAtual = maxVida;
        barraVida.GetComponent<GUIText>().color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
        barraVida.GetComponent<GUIText>().text = "HP: " + vidaAtual + "/" + maxVida;

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
            Application.LoadLevel(Application.loadedLevel);
        }

        if ((vidaAtual * 100 / maxVida) < 30)
        {
            barraVida.GetComponent<GUIText>().color = Color.red;
        }

        barraVida.GetComponent<GUIText>().text = "HP: " + vidaAtual + "/" + maxVida;
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
            barraVida.GetComponent<GUIText>().color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
        }

        barraVida.GetComponent<GUIText>().text = "HP: " + vidaAtual + "/" + maxVida;
    }

}
