using UnityEngine;
using System.Collections;

public class pedacoSoftware : MonoBehaviour {

    public Transform spritePedacoSoftware;
    private Animator animator;

    public int tipo;
    public string color;
    public bool funciona;

	// Use this for initialization
	void Start () {
        animator = spritePedacoSoftware.GetComponent<Animator>();
        
        
     

    }
	
	// Update is called once per frame
	void Update () {
        //Seta a variavel do animator que mudará o numero desenhado no sprite.
        animator.SetInteger("Tipo", tipo);

        switch (color)
        {
            case "red":
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                break;
            case "green":
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                break;
            case "yellow":
                gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case "blue":
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
                break;
            case "gray":
                gameObject.GetComponent<Renderer>().material.color = Color.gray;
                break;
            case "purple":
                gameObject.GetComponent<Renderer>().material.color = new Color(0.29f, 0, 0.5f, 1f);
                break;
            case "black":
                gameObject.GetComponent<Renderer>().material.color = Color.black;
                break;
            default:
                gameObject.GetComponent<Renderer>().material.color = Color.clear;
                break;
        }

    }
}
