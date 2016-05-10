using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class leBugsCriticos : MonoBehaviour {

    private GameObject GerenciadorJogo;

	// Use this for initialization
	void Start () {
        GerenciadorJogo = GameObject.Find("GerenciadorJogo");

    }
	
	// Update is called once per frame
	void Update () {

        gameObject.GetComponent<Text>().text = GerenciadorJogo.GetComponent<GerenciadorJogo>().numBugsCriticos.ToString();



    }
}
