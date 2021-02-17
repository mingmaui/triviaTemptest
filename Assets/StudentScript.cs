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
    [SerializeField] InputField StudentID;
    [SerializeField] InputField SchoolID;
    [SerializeField] InputField TrGameIDField;
    [SerializeField] InputField PasswordField;
    [SerializeField] Dropdown gradeLvl;
    [SerializeField] Text msgTxt;
    //string studPwd = "helloworld";
    WWWForm form;

    public void AddStudBtn(){
        if(Lname.text == "" | Fname.text == "" | Mname.text == "" | StudentID.text == "" | SchoolID.text == "" | TrGameIDField.text == "" | PasswordField.text == ""){
            msgTxt.text = "<color=red>Please fill up all fields</color>";
            Debug.Log("Please fill up all fields");
        }
        else{
            StartCoroutine(AddStudent());
        }
        
    }

    IEnumerator AddStudent(){
        form = new WWWForm();
        form.AddField("Lname", Lname.text);
        form.AddField("Fname", Fname.text);
        form.AddField("Mname", Mname.text);
        form.AddField("Number", StudentID.text);
        form.AddField("SchoolID", SchoolID.text);
        form.AddField("TeacherID", TrGameIDField.text);
        form.AddField("GradeLvl", gradeLvl.options[gradeLvl.value].text);
        form.AddField("Password", PasswordField.text);

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

    public void ClearBtn(){
        Lname.text = "";
        Fname.text = "";
        Mname.text = "";
        StudentID.text = "";
        SchoolID.text = "";
        TrGameIDField.text = "";
        PasswordField.text="";
    }

}
