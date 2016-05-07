using UnityEngine;
using System.Collections;

public class ShowHideMenu : MonoBehaviour {


    public GameObject targetMenu;

    public void toggleMenu()
    {
        if (targetMenu.activeSelf == false)
        {
            targetMenu.SetActive(true);
        }
        else
        {
            targetMenu.SetActive(false);
        }

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
