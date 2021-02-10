using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class teacherButtons : MonoBehaviour
{

    ////////////////////

    public void RegisterButton(){
        SceneManager.LoadScene(sceneName:"RegisterScene");
    }

    public void ExitGame(){
        StartCoroutine (sessionEnd ());
        Application.Quit();
    }


    /////////////////
    public void RedirectLeaderboard(){
        SceneManager.LoadScene(sceneName:"TeacherLeaderboard");
    }

    public void ReturnButtonToTeacherMenu(){
        SceneManager.LoadScene(sceneName:"TeacherMenu");
    }

    public void RedirectTopicScene(){
        SceneManager.LoadScene(sceneName:"TopicScene");
    }

    public void RedirectCreateNewRoom(){
        SceneManager.LoadScene(sceneName:"createNewRoom");
    }

    public void ReturnToLoginScene(){
        StartCoroutine (sessionEnd ());
        SceneManager.LoadScene(sceneName:"TeacherLoginScene");
        
    }

    IEnumerator sessionEnd(){
        WWW w = new WWW ("http://localhost/TriviaTempest/endSession.php");
        yield return w;
        if(w.text.Contains("Success")){
            Debug.Log("<color=red>Session Cleared</color>");
        }
    }

    public void ExitHelpScene(){
        SceneManager.LoadScene(sceneName:"TeacherLoginScene");
    }

    public void RedirectToTeacherHELP(){
        SceneManager.LoadScene(sceneName:"HelpTeachScene");
    }

    public void RedirectToChangePassword(){
        SceneManager.LoadScene(sceneName:"ChangePassword");
    }
}

