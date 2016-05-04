using UnityEngine;
using System.Collections;

public class tiro : MonoBehaviour {

    private GameObject player;

    public float duracaoTiro = 1.0f;
    private float direcao;
    private float xPos;
    private float yPos;
    private float zPos;
    public float velocidade;
  

	// Use this for initialization
	void Start () {

        player = GameObject.Find("Player");
        gameObject.transform.parent = player.transform;

        //o tiro sempre irá para o lado da ultima direcao que o player andou.
        direcao = gameObject.GetComponentInParent<Player>().ultimaDirecaoTiro;
       

        yPos = gameObject.GetComponentInParent<Player>().transform.position.y - 0.07f;
        xPos = gameObject.GetComponentInParent<Player>().transform.position.x;
        zPos = gameObject.GetComponentInParent<Player>().transform.position.z;
        velocidade = 1f;
        gameObject.transform.parent = null;
 
        if (direcao > 0)
        {
            direcao = 1f;
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            direcao = -1f;
            transform.eulerAngles = new Vector2(0, 180);
        }

        transform.position = new Vector3(xPos, yPos, zPos);
        DestroyObject(gameObject,duracaoTiro);
     
    }
	
	// Update is called once per frame
	void Update () {

        
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);

	}
}
