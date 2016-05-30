using UnityEngine;
using System.Collections;

public class OnGameWait : MonoBehaviour
{
    private GameObject GerenciadorJogo;

    // Use this for initialization
    void Start () {
        GerenciadorJogo = GameObject.Find("GerenciadorJogo");
    }
	
	// Update is called once per frame
	void Update () {


        //Se tiver na fase de remanejamento de recursos..
        if (GerenciadorJogo.GetComponent<GerenciadorJogo>().GameWait == true)
        {


            GerenciadorJogo.GetComponent<GerenciadorJogo>().GameStart = false;
            GerenciadorJogo.GetComponent<GerenciadorJogo>().GameOver = false;

            //Coloca o menu de gerenciamento de recursos aparecendo.
            GerenciadorJogo.GetComponent<GerenciadorJogo>().menuRecursos.SetActive(true);

        }

    }
}
