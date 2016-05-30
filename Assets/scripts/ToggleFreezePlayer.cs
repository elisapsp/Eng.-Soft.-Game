using UnityEngine;
using System.Collections;

public class ToggleFreezePlayer : MonoBehaviour {

    private GameObject PlayerController;
    private GameObject Timer;
    private GameObject GerenciadorJogo;

    void togglefreezePlayer()
    {
        if (Timer.GetComponent<Timer>().freeze == true || GerenciadorJogo.GetComponent<GerenciadorJogo>().GameWait == true)
        {
            PlayerController.GetComponent<Player>().enabled = false;
        }
        else
        {
            PlayerController.GetComponent<Player>().enabled = true;
        }
    }


    void Start()
    {
        PlayerController = GameObject.Find("Player");
        Timer = GameObject.Find("Canvas/Timer/Panel/Text");
        GerenciadorJogo = GameObject.Find("GerenciadorJogo");
    }
	
	// Update is called once per frame
	void Update () {

        //Se o tempo tiver parado, o jogador congela.
        togglefreezePlayer();

    }
}
