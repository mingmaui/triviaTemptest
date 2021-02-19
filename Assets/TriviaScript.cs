using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;

public class TriviaScript : MonoBehaviour
{
    public Text displayAnswer;
    public Text displayDesc;
    public InputField inputAns;
    public string SessionCode = "";
    string toRandomize;
    string correctAns;


    void Start()
    {
        SessionCode = GameObject.Find("sessionhandler").GetComponent<RoomScript>().GetSessionCode();
        StartCoroutine(FindAnswer("http://localhost/TriviaTempest/get_answersTM.php"));
        Debug.Log("Room Found!" + SessionCode);
    }

    
    void Update()
    {
       InputAns();
    }

    //for input answer
    public void InputAns()
    {
       if(Input.GetKeyDown(KeyCode.Return))
       {
            if(inputAns.text == correctAns)
            {
                Debug.Log("correct");
            }
            else{
                Debug.Log("incorrect");
                inputAns.text = "";
            }    
        } 
    }

    
    IEnumerator FindAnswer(string url)
    {
        WWWForm form = new WWWForm ();
		form.AddField ("SC", SessionCode);
        Debug.Log(SessionCode+" hello");

		WWW w = new WWW (url, form);
		yield return w;

        if(w.isDone)
        {
            Debug.Log(w.text+" hi");
            string[] temp = w.text.Split('|');
            correctAns = temp[0];
            toRandomize = new string(temp[0].ToUpper().ToCharArray().OrderBy(x=>Guid.NewGuid()).ToArray());
            displayAnswer.text = toRandomize;
            displayDesc.text = temp[1];
        }
    }
}


