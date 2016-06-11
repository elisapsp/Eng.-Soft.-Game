using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine.EventSystems;

public class EntrarNaFase : MonoBehaviour {

    public string nextScene;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        

    }

    

    public void goToScene()
    {
        nextScene = EventSystem.current.currentSelectedGameObject.name;
        Application.LoadLevel(nextScene);
        
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
