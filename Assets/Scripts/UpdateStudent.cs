using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class UpdateStudent : MonoBehaviour
{
    [SerializeField] Dropdown gradeLvl;
    [SerializeField] InputField TrNum;
    [SerializeField] InputField SchoolID;
    [SerializeField] InputField StudNum;
    [SerializeField] Dropdown studStatus;
    [SerializeField] Text msgTxt1, msgTxt2;
    string setStatus = "0";

    WWWForm form;

    public void UpdateGrLvlTrNumBtn(){
        if(TrNum.text == ""){
            msgTxt1.text = "<color=red>Please fill out the field</color>";
            Debug.Log("Please fill up all fields");
        } else{
            StartCoroutine(UpdateGrLvlTrNum());
        }

    }

    public void UpdateStudStatusBtn(){
        if(StudNum.text == ""){
            msgTxt2.text = "<color=red>Please fill out the field</color>";
            Debug.Log("Please fill up all fields");
        } else{
            StartCoroutine(UpdateStudStatus());
        }
    }

    public void BackBtn(){
        SceneManager.LoadScene(sceneName:"AddStudScene");
    }

    public void HomeBtn(){
        SceneManager.LoadScene(sceneName:"AdminMenu");
    }

    IEnumerator UpdateGrLvlTrNum(){
        string lvl = gradeLvl.options[gradeLvl.value].text;

        int lvlup = System.Int32.Parse(lvl);
        lvlup++;
        lvlup.ToString();

        form = new WWWForm();

        form.AddField("SchoolID", SchoolID.text);
        form.AddField("OldGradeLvl", lvl);
        form.AddField("NewGradeLvl", lvlup);
        form.AddField("TrNumber", TrNum.text);

        UnityWebRequest w = UnityWebRequest.Post("http://localhost/TriviaTempest/update_lvl_trNum.php", form);
        yield return w.SendWebRequest();

        if(w.isNetworkError) {
            Debug.Log(w.error);
            msgTxt1.text = "<color=red>Error: 404 not found</color>";
            Debug.Log("<color=red>"+msgTxt1.text+"</color>");
        }
        else {
            if(w.isDone){
                msgTxt1.text = "Updated successfully!";
                Debug.Log("Student updated successfully!");
            }
            
        }
        
        w.Dispose();
    }

    IEnumerator UpdateStudStatus(){
        string newStatus = studStatus.options[studStatus.value].text;
        
        if(string.Compare(newStatus, "Deactivate") == 0){
            setStatus = "2";
            Debug.Log("deactivate na");
        } else{
            setStatus = "1";
            Debug.Log("activate!!");
        }

        int varStatus = int.Parse(setStatus);

        form = new WWWForm();

        form.AddField("SchoolID", SchoolID.text);
        form.AddField("Number", StudNum.text);
        form.AddField("Status", varStatus);

        UnityWebRequest w = UnityWebRequest.Post("http://localhost/TriviaTempest/update_student_status.php", form);
        yield return w.SendWebRequest();

        if(w.isNetworkError) {
            Debug.Log(w.error);
            msgTxt2.text = "<color=red>Error: 404 not found</color>";
            Debug.Log("<color=red>"+msgTxt2.text+"</color>");
        }
        else {
            if(w.isDone){
                msgTxt2.text = "Updated successfully!";
                Debug.Log("Student status updated successfully!");
            }
            
        }
        
        w.Dispose();
    }
}
