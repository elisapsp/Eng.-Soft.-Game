using UnityEngine;
using System.Collections;

public class pedacoSoftware : MonoBehaviour {



    public Transform spritePedacoSoftware;
    private Animator animator;

    public int tipo;
    public string color;

    //Contém a resposta se o software funciona ou não.
    public bool funciona;

	private Inventory inventory;
	internal Sprite sprite;

	void Awake() {
		inventory = GameObject.FindGameObjectWithTag("Inventario").GetComponent<Inventory>();
		animator = spritePedacoSoftware.GetComponent<Animator>();
       
        sprite = spritePedacoSoftware.GetComponent<SpriteRenderer>().sprite;
        
	}
	
	void Update () {
        sprite = spritePedacoSoftware.GetComponent<SpriteRenderer>().sprite;
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

	void OnTriggerEnter2D(Collider2D collision) {
        int checaEspacoDisponivel;
        if (this.gameObject.activeSelf) {

            //Se o pedacoSoftware for preto, significa que ele foi testado e não está funcionando.
            if (this.gameObject.GetComponent<pedacoSoftware>().color != "black")
            {

			checaEspacoDisponivel = inventory.AdicionaTipoDeSoftware(this);
            if (checaEspacoDisponivel == 0) { 
			this.gameObject.SetActive(false);
            }

            }
        }
	}

  
}
