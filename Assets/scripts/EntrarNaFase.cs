using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(nextScene);
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
