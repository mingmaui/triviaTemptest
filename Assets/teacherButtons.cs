using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class teacherButtons : MonoBehaviour
{

    ////////////////////

    public void RegisterButton(){
        SceneManager.LoadScene(sceneName:"RegisterScene");
    }

    public void ExitGame(){
        Application.Quit();
        Debug.Log("Game is exiting");
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
        SceneManager.LoadScene(sceneName:"LoginScene");
    }

    public void ExitHelpScene(){
        SceneManager.LoadScene(sceneName:"LoginScene");
    }

    public void RedirectToTeacherHELP(){
        SceneManager.LoadScene(sceneName:"HelpTeachScene");
    }

    public void RedirectToChangePassword(){
        SceneManager.LoadScene(sceneName:"ChangePassword");
    }
}

