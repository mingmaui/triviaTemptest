using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class studentButtons : MonoBehaviour
{

    public void LogoutStudent(){
        StartCoroutine (sessionEnd ());
        SceneManager.LoadScene(sceneName:"StudentLogin");
    }

    public void Select(){
        StartCoroutine (sessionEnd ());
        SceneManager.LoadScene(sceneName:"SelectScene");
    }

    public void RedirectToRoomScene(){
        SceneManager.LoadScene(sceneName:"RoomScene");
    }

    public void RedirectToEndlessScene(){
        SceneManager.LoadScene(sceneName:"EndlessScene");
    }
    public void RedirectToStudentLeaderboard(){
        SceneManager.LoadScene(sceneName:"StudentLeaderboard");
    }
    public void ExitButton(){
        Application.Quit();
        Debug.Log("Game is exiting");
    }

    public void RedirectToDictionary(){
        SceneManager.LoadScene(sceneName:"DictScene");
    }

    public void RedirectToStudentHELP(){
        SceneManager.LoadScene(sceneName:"HelpStudScene");
    }

    public void ReturnToStudentMenu(){
        SceneManager.LoadScene(sceneName:"StudentMenu");
    }

    public void ExitGame(){
        StartCoroutine (sessionEnd ());
        Application.Quit();
    }

    IEnumerator sessionEnd(){
        WWW w = new WWW ("http://localhost/TriviaTempest/endSession.php");
        yield return w;
        if(w.text.Contains("Success")){
            Debug.Log("<color=red>Session Cleared</color>");
        }
    }

}
