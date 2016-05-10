using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class leDiasTrabalhados : MonoBehaviour {

    private GameObject GerenciadorJogo;

	// Use this for initialization
	void Start () {

        GerenciadorJogo = GameObject.Find("GerenciadorJogo");

    }
	
	// Update is called once per frame
	void Update () {

        gameObject.GetComponent<Text>().text = GerenciadorJogo.GetComponent<GerenciadorJogo>().countDiasTrabalhados.ToString();
	}
}
