using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class DeleteSchoolScript : MonoBehaviour
{
    [SerializeField] InputField SchoolID;
    [SerializeField] Text msgTxt; 
    [SerializeField] Dropdown schoolStatus;
    public GameObject YesBtn, NoBtn, AlertBox, AlertTxt;
    string setStatus = "0";

    WWWForm form;

    void Start(){
        AlertBox.SetActive(false);
        AlertTxt.SetActive(false);
        YesBtn.SetActive(false);
        NoBtn.SetActive(false);
    }

    // void Update(){
    //     //Invoke("YesDelBtn", 2);
    //     AlertBox.SetActive(false);
    //     YesBtn.SetActive(false);
    //     NoBtn.SetActive(false);
    // }
    
    public void UpdateSchoolBtn(){
        if(SchoolID.text == ""){
            msgTxt.text = "<color=red>Please input a School ID</color>";
            Debug.Log("<color=red>"+msgTxt.text+"</color>");
        }

        else{
            AlertBox.SetActive(true);
            AlertTxt.SetActive(true);
            YesBtn.SetActive(true);
            NoBtn.SetActive(true);
        }

    }

    public void YesStatusBtn(){
        if(schoolStatus.options[schoolStatus.value].text == "Deactivate"){
            StartCoroutine(DeactivateSchool());
        }

        else{
            StartCoroutine(ActivateSchool());
        }
        
        AlertBox.SetActive(false);
        AlertTxt.SetActive(false);
        YesBtn.SetActive(false);
        NoBtn.SetActive(false);
    }

    public void NoStatusBtn(){
        AlertBox.SetActive(false);
        AlertTxt.SetActive(false);
        YesBtn.SetActive(false);
        NoBtn.SetActive(false);
    }

    public void BackBtn(){
        SceneManager.LoadScene(sceneName:"AdminMenu");
    }

    IEnumerator DeactivateSchool(){
        string newStatus = schoolStatus.options[schoolStatus.value].text;
        
        if(string.Compare(newStatus, "Deactivate") == 0){
            setStatus = "2";
            Debug.Log("deactivate na");
        } 

        int varStatus = int.Parse(setStatus);
        form = new WWWForm();
    
        form.AddField("SchoolID", SchoolID.text);
        form.AddField("Status", varStatus);

        UnityWebRequest w = UnityWebRequest.Post("http://localhost/TriviaTempest/delete_school.php", form);
		yield return w.SendWebRequest();

        if(w.isNetworkError) {
            Debug.Log(w.error);
        }
        else {
            if(w.isDone){
                msgTxt.text = "School deactivated successfully!";
                Debug.Log("School deactivated!");
            }
            
        }

        w.Dispose();
    }

    IEnumerator ActivateSchool(){
        string newStatus = schoolStatus.options[schoolStatus.value].text;
        
        if(newStatus == "Activate"){
            setStatus = "1";
            Debug.Log("activate na");
        } 

        int varStatus = int.Parse(setStatus);
        form = new WWWForm();
    
        form.AddField("SchoolID", SchoolID.text);
        form.AddField("Status", varStatus);

        UnityWebRequest w = UnityWebRequest.Post("http://localhost/TriviaTempest/delete_school.php", form);
		yield return w.SendWebRequest();

        if(w.isNetworkError) {
            Debug.Log(w.error);
        }
        else {
            if(w.isDone){
                msgTxt.text = "School activated successfully!";
                Debug.Log("School activated!");
            }
            
        }

        w.Dispose();
    }
    
}
