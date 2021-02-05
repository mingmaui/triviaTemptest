using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using MySql.Data.MySqlClient;

public class RegisterScript : MonoBehaviour
{
    public InputField pwdField;
    public InputField rePwdField;
    public Text reqTxt;
    public void RegisterButton(){
        if(pwdField.text == rePwdField.text){
            SceneManager.LoadScene(sceneName:"TeacherMenu");
        }
        
        else{
            reqTxt.text = "Password not match";
        }
    }
}
