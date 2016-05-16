using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroSpeaking : MonoBehaviour {


    public string texto;
    private string[] message = new string[1];
    public GameObject DialogBoxText;
    public string novaFase;

    // Use this for initialization
    void Start()
    {
        DialogBoxText.transform.parent.gameObject.SetActive(true);
        message[0] = texto;
        DialogBoxText.GetComponent<ImportText>().text = message;

    }

    // Update is called once per frame
    void Update()
    {

        //Quando não houver mais diálogo.
        if (DialogBoxText.transform.parent.gameObject.activeSelf == false)
        {
            //mudaDeFase
            
            Application.LoadLevel(novaFase);
        }

    }
}
