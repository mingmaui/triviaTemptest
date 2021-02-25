using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Server : MonoBehaviour
{
	[SerializeField] InputField username;
	[SerializeField] InputField password;

	[SerializeField] Text errorTxt;
	//[SerializeField] GameObject progressCircle;
	
	WWWForm form;

	public void OnLoginButtonClicked ()
	{
		//progressCircle.SetActive (true);
		if(username.text == "" | password.text == ""){
			errorTxt.text = "Please fill up all fields";
			Debug.Log("Please fill up all fields");
		}

		else{
			StartCoroutine (Login ());
		}
		
	}

	IEnumerator Login ()
	{
		form = new WWWForm ();

		form.AddField ("username", username.text);
		form.AddField ("password", password.text);

		WWW w = new WWW ("http://localhost/TriviaTempest/login_admin.php", form);
		yield return w;

		if (w.error != null) {
			errorTxt.text = "404 not found!";
			Debug.Log("<color=red>"+w.text+"</color>");//error
		} else {
			if (w.isDone) {
				if (w.text.Contains ("error")) {
					errorTxt.text = "Invalid Username or Password!";
                    Debug.Log("Invalid Username or Password!");
					Debug.Log("<color=red>"+w.text+"</color>");//error
				} else {
					SceneManager.LoadScene(sceneName:"AdminMenu");
                    Debug.Log("Login Successful");
					Debug.Log("<color=green>"+w.text+"</color>");//user exist
				}
			}
		}

		//progressCircle.SetActive (false);

		w.Dispose ();
	}

}
