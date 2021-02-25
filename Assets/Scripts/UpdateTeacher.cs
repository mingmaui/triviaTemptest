using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class UpdateTeacher : MonoBehaviour
{
    [SerializeField] InputField SchoolID;
    [SerializeField] InputField TrNum;
    [SerializeField] Dropdown trStatus;
    [SerializeField] Text msgTxt1, msgTxt2;
    string setStatus = "0";
    WWWForm form;

    public void UpdateTrStatusBtn(){
        if(TrNum.text == ""){
            msgTxt1.text = "<color=red>Please fill out the field</color>";
            Debug.Log("Please fill up all fields");
        } else{
            StartCoroutine(UpdateTrStatus());
        }
    }

    public void BackBtn(){
        SceneManager.LoadScene(sceneName:"AddTrScene");
    }

    public void HomeBtn(){
        SceneManager.LoadScene(sceneName:"AdminMenu");
    }

    IEnumerator UpdateTrStatus(){
        string newStatus = trStatus.options[trStatus.value].text;
        
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
        form.AddField("Number", TrNum.text);
        form.AddField("Status", varStatus);

        UnityWebRequest w = UnityWebRequest.Post("http://localhost/TriviaTempest/update_teacher_status.php", form);
        yield return w.SendWebRequest();

        if(w.isNetworkError) {
            Debug.Log(w.error);
            msgTxt2.text = "<color=red>Error: 404 not found</color>";
            Debug.Log("<color=red>"+msgTxt2.text+"</color>");
        }
        else {
            if(w.isDone){
                msgTxt2.text = "Updated successfully!";
                Debug.Log("Teacher status updated successfully!");
            }
            
        }
        
        w.Dispose();
    }
    
}
