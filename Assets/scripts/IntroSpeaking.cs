using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroSpeaking : MonoBehaviour {


    public string texto0;
    public string texto1;
    public string texto2;

    private string[] message = new string[3];
    public GameObject DialogBoxText;
    public string novaFase;

    // Use this for initialization
    void Start()
    {
        DialogBoxText.transform.parent.gameObject.SetActive(true);
        message[0] = texto0;
        message[1] = texto1;
        message[2] = texto2;
        DialogBoxText.GetComponent<ImportText>().text = message;

    }

    // Update is called once per frame
    void Update()
    {

        //Quando não houver mais diálogo.
        if (DialogBoxText.transform.parent.gameObject.activeSelf == false)
        {
            //mudaDeFase

            SceneManager.LoadScene(novaFase);
        }

    }
}
