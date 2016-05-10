using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public float tempoInicial;
    private GameObject GerenciadorJogo;

    public float timer;
	// Use this for initialization
	void Start () {

        GerenciadorJogo = GameObject.Find("GerenciadorJogo");
        tempoInicial = timer;
	}




    // Update is called once per frame
    void Update () {

        //Se o jogo estiver acontecendo.
        if (GerenciadorJogo.GetComponent<GerenciadorJogo>().GameOver == false &&
            GerenciadorJogo.GetComponent<GerenciadorJogo>().GameWait == false &&
            GerenciadorJogo.GetComponent<GerenciadorJogo>().GameStart == false) { 


           
        if (timer <= 0)
        {
            timer = 0;
            GerenciadorJogo.GetComponent<GerenciadorJogo>().GameOver = true;
                Debug.Log("GameOver");
        }
        else
        {
            timer -= Time.deltaTime;
        }
        }
        gameObject.GetComponent<Text>().text = timer.ToString("0");
	}



 
}
