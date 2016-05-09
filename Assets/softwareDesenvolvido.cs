using UnityEngine;
using System.Collections;

public class softwareDesenvolvido : MonoBehaviour {

    
    public bool[] coletado = new bool[4];
    public string[] cores = new string[4];
    public bool[] funciona = new bool[4];

    private GameObject inventario;

    // Use this for initialization
    void Start () {

        for (int i = 0; i < 4; i++)
        {
            coletado[i] = false;
            funciona[i] = false;
            cores[i] = "";
            
        }

        inventario = GameObject.Find("Canvas/Inventario");


    }
	
	// Update is called once per frame
	void Update () {

        //Atualiza as informações dos pedacos de software com a linha1.
        inventario.GetComponent<Inventory>().AtualizaSoftwareDesenvolvido();

       /*
        for (int i = 0; i < 4; i++)
        {
            Debug.Log("Software Tipo " + (i+1).ToString() + ": " + " coletado = " + coletado[i].ToString() + " functiona = " + funciona[i].ToString() + " cor = " + cores[i]);
            
        }
        */

    }
}
