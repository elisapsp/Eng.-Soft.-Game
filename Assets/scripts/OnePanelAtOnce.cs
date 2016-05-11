using UnityEngine;
using System.Collections;

public class OnePanelAtOnce : MonoBehaviour {

    private GameObject[] PopUpMenus;

    public void cleanAllPanels()
    {
        PopUpMenus = GameObject.FindGameObjectsWithTag("PopUpMenu");
        if (PopUpMenus.Length > 0)
        {
            foreach (GameObject panel in PopUpMenus)
            {
                panel.SetActive(false);
            }
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
