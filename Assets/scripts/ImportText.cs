using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class ImportText : MonoBehaviour {

    public int limiteCaracteresPorLinha = 70;
    public string[] text;
    public bool[] respostas;
    private int currentLine, currentQuestionLine;
    private bool firstEnter = true;
  

    // Use this for initialization
    void Start () {
        currentLine = 0;
        currentQuestionLine = 0;
    }

    void OnEnable()
    {
        firstEnter = true;
        currentLine = 0;
        currentQuestionLine = 0;
    }


	// Update is called once per frame
	void Update () {

        //Se tiver texto.
        if (text!=null && text.Length>0)
        {
            
            List<string> list;
            list = arrumaTamanhoFrases(text, limiteCaracteresPorLinha);

            if (currentLine == 0)
            {
                gameObject.GetComponent<Text>().text = list[currentLine];
                currentLine++;
            }


            if (Input.GetKeyDown(KeyCode.G))
            {

                if (currentLine >= list.Count)
                {
                    text = null;
                    currentLine = 0;
                    gameObject.transform.parent.gameObject.SetActive(false);

                }
                else
                {
                    gameObject.GetComponent<Text>().text = list[currentLine];
                    currentLine++;
                }
            }
            else if ((Input.GetKeyDown(KeyCode.Return))){
                if (firstEnter)
                {
                    firstEnter = false;
                    //GerenciadorJogo.instance.cliente.GetComponent<Cliente>().OnPressEnter();
                    gameObject.GetComponent<Text>().text = list[currentQuestionLine];
                    currentQuestionLine++;
                    currentLine++;
                }
                else {
                    text = null;
                    currentLine = 0;
                    gameObject.transform.parent.gameObject.SetActive(false);
                }
            }
            //voce acretou
            else if ((Input.GetKeyDown(KeyCode.J) && respostas[currentQuestionLine-1]) || (Input.GetKeyDown(KeyCode.K) && !respostas[currentQuestionLine-1]))
            {

                if (currentQuestionLine >= list.Count)
                {
                    text = null;
                    currentQuestionLine = 0;
                    currentLine = 0;
                    gameObject.transform.parent.gameObject.SetActive(false);
                    GerenciadorJogo.instance.objetivoConcluido = true;

                }
                else
                {
                    gameObject.GetComponent<Text>().text = list[currentQuestionLine];
                    currentQuestionLine++;
                }
            }
            //voce errou
            else if ((Input.GetKeyDown(KeyCode.K) && respostas[currentQuestionLine-1]) || (Input.GetKeyDown(KeyCode.J) && !respostas[currentQuestionLine-1]))
            {
                gameObject.GetComponent<Text>().text = "Não foi dessa vez! Será que as placas podem ajudar? Leia um pouco sobre engenharia de software e tente novamente!";
                GerenciadorJogo.instance.countDiasTrabalhados++;
                text = null;
                currentQuestionLine = 0;
                currentLine = 0;
            }
            




            
        }
        
	}

    //Essa função ajeita as frases para caber direito no dialogBox.
    List<string> arrumaTamanhoFrases(string[] texts, int limitPerLine)
    {

        List<string> list = new List<string>();

        int currentText = 0;
        string text = texts[currentText];
   
        int countChar = 0;

        string buffer = "";

        int numOfLines = 0;
        bool endOfText = false;

       

        //Percorre a frase toda.
        for (int i = 0; i < text.Length; i++)
        {
            
            //Toda vez que o quadro estiver todo preenchido.
            if (numOfLines == 3|| endOfText)
            {

                text.Substring(i, 1);
                if (buffer != "" && buffer != "\n")
                {
                    list.Add(buffer);
                    //gameObject.GetComponent<Text>().text = buffer;

                }
                //Debug.Log(buffer);
                buffer = "";
                
                numOfLines = 0;
                countChar = 0;

                if (!endOfText)
                {
                    i--;
                }else
                {
                    //Pega o indice do próximo texto.
                    currentText++;
                    //Se o texto exisitir.
                    
                    if (currentText < texts.Length)
                    {
                        text = texts[currentText];
                        //Debug.Log(text);
                        endOfText = false;
                        i = -1;
                    }
                }

            }
            else
            {

                if (countChar == limitPerLine || text.Substring(i, 1) == "\n")
                {

                    numOfLines++;
                    countChar = 0;
                    if (text.Substring(i, 1) != "\n")
                    { 
                        buffer += text.Substring(i, 1);
                    }
                }


                if (numOfLines < 3)
                {
                    buffer += text.Substring(i, 1);
                }

                if (i == text.Length - 1)
                {
                    endOfText = true;
                    i--;
                }
               
            }
            
        }





        return list;
    }



}

