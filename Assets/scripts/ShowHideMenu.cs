using UnityEngine;
using System.Collections;

public class ShowHideMenu : MonoBehaviour {

    private GameObject GerenciadorJogo;

    public GameObject targetMenu;

    public void toggleMenu()
    {
        Debug.Log(gameObject.name);
        if (targetMenu.activeSelf == false)
        {
            GerenciadorJogo.GetComponent<OnePanelAtOnce>().cleanAllPanels();
            targetMenu.SetActive(true);
        }
        else
        {
            targetMenu.SetActive(false);
        }

    }

	// Use this for initialization
	void Start () {
        GerenciadorJogo = GameObject.Find("GerenciadorJogo");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
