using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaScript : MonoBehaviour
{
    public Text displayTextTwist;


    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<TimerScript>().TimerStart();
        StartCoroutine(FindAnswer("http://localhost/TriviaTempest/get_answersTM.php"));
        SessionCode = GameObject.Find("sessionhandler").GetComponent<RoomScript>().GetSessionCode();
        Debug.Log("Room Found!" + SessionCode);
    }

    public string SessionCode = "";


    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FindAnswer(string url)
    {
        //form = new WWWForm();
        //form.AddField ("word", txtBoxSearch.text);
        WWW w = new WWW (url);
		yield return w;

        if (w.error != null)
        {
            Debug.Log("Error While Sending: " + w.error);
        }
        else
        {
            Debug.Log("Received: " + w.text);
            displayTextTwist.text=w.text;
        }
    }
}


