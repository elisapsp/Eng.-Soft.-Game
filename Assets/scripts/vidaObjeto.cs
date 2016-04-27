using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class vidaObjeto : MonoBehaviour {

    //Objeto barra vida criado.
    public GameObject barraVida;
    
    //HP Máximo do personagem.
    public int maxVida;
    private int vidaAtual;

    // Use this for initialization
    void Start () {

        //Vida
        vidaAtual = maxVida;
        //Seta a cor do texto verde.
        barraVida.GetComponent<GUIText>().color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
        //Escreve o texto.
        barraVida.GetComponent<GUIText>().text = "HP: " + vidaAtual + "/" + maxVida;

    }
	
	// Update is called once per frame
	void Update () {

        
    }

    public void PerdeVida(int dano)
    {
        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            //Objeto deve morrer (ser destruido).

            //Como é só um teste, vou só resetar o jogo.
            restartCurrentScene();
            
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

    public void restartCurrentScene()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }


}

