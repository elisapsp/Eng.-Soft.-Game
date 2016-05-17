using UnityEngine;
using System.Collections;

public class adiarTrabalho : MonoBehaviour {


    private GameObject Timer;

    public void AdiarTrabalho()
    {
        Timer.GetComponent<Timer>().timer = 0;
    }

	// Use this for initialization
	void Start () {
        Timer = GameObject.Find("Canvas/Timer/Panel/Text");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
