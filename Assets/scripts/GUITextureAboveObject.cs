using UnityEngine;
using System.Collections;

public class GUITextureAboveObject : MonoBehaviour {

    public Transform target;
    public float xOffset;
    public float yOffset;
 
    private Vector2 wantedPos;

    private Vector3 acimaCabecaObjeto;
        
    // Use this for initialization
    void Start () {


        xOffset = 0.5f;
        yOffset = 0.5f;


    }
	
	// Update is called once per frame
	void Update () {
        acimaCabecaObjeto = new Vector3(target.position.x + xOffset, target.position.y + yOffset, target.position.z);
        wantedPos = Camera.main.WorldToViewportPoint(acimaCabecaObjeto);
        transform.position = wantedPos;
    }
}
