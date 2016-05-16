using UnityEngine;
using System.Collections;

public class showHideObject : MonoBehaviour {


    public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (target.activeSelf == true)
        {
            target.SetActive(false);
            gameObject.GetComponent<Animator>().SetBool("show", false);
        }
        else
        {
            target.SetActive(true);
            gameObject.GetComponent<Animator>().SetBool("show", true);
        }

    }
}
