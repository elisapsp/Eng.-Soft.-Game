using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {


    public float timer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        if (timer <= 0)
        {
            timer = 0;
            Debug.Log("GameOver");
        }
        else
        {
            timer -= Time.deltaTime;
        }

        gameObject.GetComponent<Text>().text = timer.ToString("0");
	}
}
