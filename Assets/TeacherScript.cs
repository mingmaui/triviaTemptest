using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class TeacherScript : MonoBehaviour
{
    [SerializeField] InputField Lname;
    [SerializeField] InputField Fname;
    [SerializeField] InputField Mname;
    [SerializeField] InputField SchoolName;
    [SerializeField] InputField TrNumber;
    [SerializeField] Text msgTxt;
    int trStatus = 1;

    string trPwd = "defaultpass";

    WWWForm form;
    public void AddTeacherBtn(){
        if(Lname.text == "" | Fname.text == "" | Mname.text == "" | TrNumber.text == "" | SchoolName.text == ""){
            msgTxt.text = "<color=red>Please fill up all fields</color>";
            Debug.Log("Please fill up all fields");
        }

        else{
            StartCoroutine(AddTeacher());
        }        
    }

    IEnumerator AddTeacher(){
        form = new WWWForm();
        form.AddField("Number", TrNumber.text);
        form.AddField("Password", trPwd);
        form.AddField("Lname", Lname.text);
        form.AddField("Fname", Fname.text);
        form.AddField("Mname", Mname.text);
        form.AddField("SchoolName", SchoolName.text);
        form.AddField("Status", trStatus);

        UnityWebRequest w = UnityWebRequest.Post("http://localhost/TriviaTempest/add_teacher.php", form);
        yield return w.SendWebRequest();

        if(w.isNetworkError) {
            Debug.Log(w.error);
            msgTxt.text = "<color=red>Error: 404 not found</color>";
            Debug.Log("<color=red>"+msgTxt.text+"</color>");
        }
        else {
            if(w.isDone){
                msgTxt.text = "Teacher added successfully!";
                Debug.Log("Teacher added successfully!");
            }
            
        }
        
        w.Dispose();
    }

    public void BackBtn(){
        SceneManager.LoadScene(sceneName:"AdminMenu");
    }

    public void ViewTeacherBtn(){
        SceneManager.LoadScene(sceneName:"ViewTeacher");
    }

    public void ClearBtn(){
        Lname.text = "";
        Fname.text = "";
        Mname.text = "";
        SchoolName.text = "";
        TrNumber.text = "";
    }
}
