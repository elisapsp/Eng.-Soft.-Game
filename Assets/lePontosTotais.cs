using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class lePontosTotais : MonoBehaviour {

    private GameObject recursos;
    // Use this for initialization
    void Start () {
        recursos = GameObject.Find("GerenciarTime");
    }
	
	// Update is called once per frame
	void Update () {

        gameObject.GetComponent<Text>().text = recursos.GetComponent<Recursos>().PontosTotais.ToString();
	}
}
