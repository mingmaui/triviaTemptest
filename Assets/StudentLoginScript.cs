using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class StudentLoginScript : MonoBehaviour
{
    [SerializeField] InputField Number;
	[SerializeField] InputField password;
	[SerializeField] Text errorTxt;
	
	WWWForm form;


	public void OnLoginButtonClicked ()
	{
		
		if(Number.text == "" | password.text == ""){
			errorTxt.text = "<color=red>Please fill up all fields</color>";
			Debug.Log("Please fill up all fields");
		}

		else{
			StartCoroutine (Login());
		}
		
	}

	IEnumerator Login()
	{
		form = new WWWForm ();

		form.AddField ("Number", Number.text);
        string hash = Hash(password.text);
		form.AddField ("Password", hash);

		WWW w = new WWW ("http://localhost/TriviaTempest/login_student.php", form);
		yield return w;

		if (w.error != null) {
			errorTxt.text = "404 not found!";
			Debug.Log("<color=red>"+w.text+"</color>");//error
		} else {
			if (w.isDone) {
				if (w.text.Contains("error")) {
					errorTxt.text = "Invalid ID Number or Password!";
                    Debug.Log("<color=red>Invalid ID Number or Password!</color>");
					Debug.Log("<color=red>"+errorTxt.text+"</color>");//error
				} 
                else {
					SceneManager.LoadScene(sceneName:"StudentMenu");
                    Debug.Log("Login Successful");
					Debug.Log(w.text);//user exist
				}
			}
		}

		w.Dispose ();
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
