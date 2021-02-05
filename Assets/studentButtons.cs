using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class studentButtons : MonoBehaviour
{

    public void LogoutStudent(){
        SceneManager.LoadScene(sceneName:"LoginScene");
    }
    public void RedirectToTriviaScene(){
        SceneManager.LoadScene(sceneName:"TriviaScene");
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

}
