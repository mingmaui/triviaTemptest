﻿using UnityEngine;
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
    [SerializeField] InputField TrGameID;
    [SerializeField] Dropdown gradeLvl;
    [SerializeField] Text msgTxt;
    string studPwd = "helloworld";
    WWWForm form;

    public void AddStudBtn(){
        if(Lname.text == "" | Fname.text == "" | Mname.text == "" | StudentID.text == "" | SchoolID.text == "" | TrGameID.text == ""){
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
        form.AddField("TrGameID", TrGameID.text);
        form.AddField("GradeLvl", gradeLvl.options[gradeLvl.value].text);
        form.AddField("Password", studPwd);

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

    public void BackBtn(){
        SceneManager.LoadScene(sceneName:"AdminMenu");
    }

    public void ClearBtn(){
        Lname.text = "";
        Fname.text = "";
        Mname.text = "";
        StudentID.text = "";
        SchoolID.text = "";
        TrGameID.text = "";
    }

}