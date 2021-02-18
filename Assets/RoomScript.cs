using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class RoomScript : MonoBehaviour
{
    [SerializeField] InputField txtBoxRoom;
    [SerializeField] Button searchBtn1;
    [SerializeField] Text showMessage;

    WWWForm form;

    public string GetSessionCode(){
        return SessionCode;
    }

    private string SessionCode = "";

    private void Start() {
        DontDestroyOnLoad(gameObject);
    }

    public void roomBtn(){
        if(txtBoxRoom.text == ""){
            showMessage.text = "<color=red>Please enter a code</color>";
            Debug.Log("<color=red>"+showMessage.text+"</color>");
        }

        else{
            StartCoroutine(FindRoom());
        }
    }

    IEnumerator FindRoom()
    {
        form = new WWWForm();
        form.AddField ("RoomID", txtBoxRoom.text.ToUpper());

        WWW w = new WWW ("http://localhost/TriviaTempest/get_roomcode.php", form);
		yield return w;

        if (w.error != null)
        {
            showMessage.text = "Room not Found!";
            Debug.Log("<color=red>"+w.text+"</color>");//error
            //Debug.Log("Error While Sending: " + w.error);
        }
        else{
            if(w.isDone)
            {
               if (w.text.Contains("error")) {
					showMessage.text = "Room Not Found!";
                    Debug.Log("<color=red>Room Not Found!</color>");
					Debug.Log("<color=red>"+showMessage.text+"</color>"); //error
                    //SessionCode = "Room Not Found!";
				} 
               else{
                    SceneManager.LoadScene(sceneName:"TriviaScene");
                    Debug.Log("Room Found!");
					//Debug.Log(w.text);//user exist

                    SessionCode = w.text;
                    //Debug.Log("Received: " + w.text);
                    //RedirectToTriviaScene(); 
               }
            }
        }
    }
}
