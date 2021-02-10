using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class ChangePassScript : MonoBehaviour
{
    [SerializeField] InputField currentPassword;
    [SerializeField] InputField newPassword;
    [SerializeField] InputField reenteredPassword;
    [SerializeField] Button changePwd;
    [SerializeField] Text ChangePassLabel;
    [SerializeField] Text NewPassLabel;
    [SerializeField] Text ReenterPassLabel;
    [SerializeField] Text changedBtnLabel;


    WWWForm form;

    public void ChangePassBtn(){
        // if(currentPassword.text == ""){
        //     ChangePassLabel.text = "<color=red>Please Enter your Password</color>";
        //     Debug.Log("<color=red>"+ChangePassLabel.text+"</color>");
        // }
        // else if(currentPassword.text != "215169924920431"){
        //     ChangePassLabel.text = "<color=red>Password Incorrect</color>";
        //     Debug.Log("<color=red>"+ChangePassLabel.text+"</color>");

        // }
        if(newPassword.text==""){
            NewPassLabel.text = "<color=red>Please Enter New Password</color>";
            Debug.Log("<color=red>"+NewPassLabel.text+"</color>");

        }
        else if(newPassword.text != reenteredPassword.text){
            ReenterPassLabel.text = "<color=red>Password does not Match</color>";
            Debug.Log("<color=red>"+ReenterPassLabel.text+"</color>");

        }
        else{
            StartCoroutine(ChangePass());
        }      
    }

    IEnumerator ChangePass(){
        form = new WWWForm();
        string hash = Hash(reenteredPassword.text);
 
        form.AddField("Password", hash);

        WWW w = new WWW("http://localhost/TriviaTempest/change_pass.php", form);
		yield return w;

        if(w.error != null) {
            Debug.Log(w.error);
        }
        else {
            if(w.isDone){
                NewPassLabel.text = "";
                ReenterPassLabel.text = "";
                changedBtnLabel.text = "Password Changed successfully!";
                Debug.Log("Password Changed complete!");
                Debug.Log(w.text);
            }
            
        }

        w.Dispose();
    }

    public static string Hash(string s)
    => BitConverter.ToString(
        System.Security
            .Cryptography.MD5
            .Create()
            .ComputeHash(
                System.Text
                    .Encoding
                    .UTF8
                    .GetBytes(s)
            )
    ).Replace("-","");
}
