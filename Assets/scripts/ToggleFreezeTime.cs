using UnityEngine;
using System.Collections;

public class ToggleFreezeTime : MonoBehaviour {

    private GameObject[] PopUpMenus;
    private GameObject Timer;

    void FreezeTime()
    {
        PopUpMenus = GameObject.FindGameObjectsWithTag("PopUpMenu");
        if (PopUpMenus.Length > 0)
        {
            Timer.GetComponent<Timer>().freeze = true;
        }
        else
        {
            Timer.GetComponent<Timer>().freeze = false;
        }
    }

    // Use this for initialization
    void Start () {
        Timer = GameObject.Find("Canvas/Timer/Panel/Text");
    }
	
	// Update is called once per frame
	void Update () {

        //Se algum painel estiver ativado, o tempo congela. Isso facilitará o jogo.
        FreezeTime();

    }
}
