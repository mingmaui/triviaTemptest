using UnityEngine;
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


    WWWForm form;

    public void ChangePassBtn(){
        if(SchoolName.text==""){
            msgTxt.text = "<color=red>Please input a school</color>";
            Debug.Log("<color=red>"+msgTxt.text+"</color>");

        }

        else{
            StartCoroutine(ChangePass());
        }      
    }

    IEnumerator ChangePass(){
        form = new WWWForm();
    
        form.AddField("SchoolName", SchoolName.text);

        UnityWebRequest w = UnityWebRequest.Post("http://localhost/TriviaTempest/register.php", form);
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

    public void LogOutBtn(){
		SceneManager.LoadScene(sceneName:"LoginScene");
	}
}
