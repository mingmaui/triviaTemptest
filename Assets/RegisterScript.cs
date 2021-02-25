using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class RegisterScript : MonoBehaviour
{
    [SerializeField] InputField SchoolName;
    [SerializeField] Button RegSBtn;
    [SerializeField] Text msgTxt;
    int schoolStatus = 1;

    WWWForm form;

    public void RegSchoolBtn(){
        if(SchoolName.text==""){
            msgTxt.text = "<color=red>Please input a school</color>";
            Debug.Log("<color=red>"+msgTxt.text+"</color>");

        }

        else{
            StartCoroutine(RegSchool());
        }      
    }

    IEnumerator RegSchool(){
        //int varStatus = int.Parse(schoolStatus);
        form = new WWWForm();
    
        form.AddField("SchoolName", SchoolName.text);
        form.AddField("Status", schoolStatus);

        UnityWebRequest w = UnityWebRequest.Post("http://localhost/TriviaTempest/register_school.php", form);
		yield return w.SendWebRequest();

        if(w.isNetworkError) {
            Debug.Log(w.error);
        }
        else {
            if(w.isDone){
                msgTxt.text = "School registered successfully!";
                Debug.Log("School registered complete!");
            }
            
        }

        w.Dispose();
    }

    public void StudBtn(){
        SceneManager.LoadScene(sceneName:"AddStudScene");
    }

    public void TeacherBtn(){
        SceneManager.LoadScene(sceneName:"AddTrScene");
    }

    public void ViewSchoolBtn(){
        SceneManager.LoadScene(sceneName:"ViewSchool");
    }

    public void LogOutBtn(){
		SceneManager.LoadScene(sceneName:"AdminLogin");
	}
}
