using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TriviaScript : MonoBehaviour
{
    public Text displayAnswer;
    public Text displayDesc;
    public string SessionCode = "";


    void Start()
    {
        SessionCode = GameObject.Find("sessionhandler").GetComponent<RoomScript>().GetSessionCode();
        StartCoroutine(FindAnswer("http://localhost/TriviaTempest/get_answersTM.php"));
        Debug.Log("Room Found!" + SessionCode);
    }

    
    IEnumerator FindAnswer(string url)
    {
        WWWForm form = new WWWForm ();
        //form.AddField("Answer", displayAnswer.text.ToUpper());
		form.AddField ("SC", SessionCode);
        Debug.Log(SessionCode+" hello");
		WWW w = new WWW (url, form);
		yield return w;

        if(w.isDone)
        {
            Debug.Log(w.text+" hi");
            string[] temp = w.text.Split('|');
            displayAnswer.text = temp[0].ToUpper();
            displayDesc.text = temp[1];
        }
    }
}


