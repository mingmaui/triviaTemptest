using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class StudentScript : MonoBehaviour
{
    [SerializeField] InputField Lname;
    [SerializeField] InputField Fname;
    [SerializeField] InputField Mname;
    [SerializeField] InputField StudNum;
    [SerializeField] InputField SchoolName;
    [SerializeField] InputField TrNumber;
    [SerializeField] InputField PasswordField;
    [SerializeField] Dropdown gradeLvl;
    [SerializeField] Text msgTxt;
    int studStatus = 1;
    WWWForm form;

    public void AddStudBtn(){
        if(Lname.text == "" | Fname.text == "" | Mname.text == "" | StudNum.text == "" | SchoolName.text == "" | PasswordField.text == "" | TrNumber.text == ""){
            msgTxt.text = "<color=red>Please fill up all fields</color>";
            Debug.Log("Please fill up all fields");
        }
        else{
            StartCoroutine(AddStudent());
        }
        
    }

    IEnumerator AddStudent(){
        string setGradeLvl = gradeLvl.options[gradeLvl.value].text;

        form = new WWWForm();
        form.AddField("Lname", Lname.text);
        form.AddField("Fname", Fname.text);
        form.AddField("Mname", Mname.text);
        form.AddField("Number", StudNum.text);
        form.AddField("SchoolName", SchoolName.text);
        form.AddField("TeacherID", TrNumber.text);
        form.AddField("GradeLvl", setGradeLvl);
        form.AddField("Password", PasswordField.text);
        form.AddField("Status", studStatus);

        string hash = Hash(PasswordField.text);
		form.AddField ("Password", hash);

        UnityWebRequest w = UnityWebRequest.Post("http://localhost/TriviaTempest/add_student.php", form);
        yield return w.SendWebRequest();

        if(w.isNetworkError) {
            Debug.Log(w.error);
            msgTxt.text = "<color=red>Error: 404 not found</color>";
            Debug.Log("<color=red>"+msgTxt.text+"</color>");
        }
        else {
            if(w.isDone){
                msgTxt.text = "Student added successfully!";
                Debug.Log("Student added successfully!");
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

    public void BackBtn(){
        SceneManager.LoadScene(sceneName:"AdminMenu");
    }

    public void ViewStudentBtn(){
        SceneManager.LoadScene(sceneName:"ViewStudent");
    }

    public void ClearBtn(){
        Lname.text = "";
        Fname.text = "";
        Mname.text = "";
        StudNum.text = "";
        SchoolName.text = "";
        TrNumber.text = "";
        PasswordField.text = "";
        msgTxt.text = "";
    }

}
