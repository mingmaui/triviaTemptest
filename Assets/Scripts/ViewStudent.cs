using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ViewStudent : MonoBehaviour
{
    [SerializeField] InputField SchoolID;
    [SerializeField] Dropdown gradeLvl;
    [SerializeField] Text msgTxt3;
    public GameObject prefab;
    WWWForm form;

    public void SearchBtn(){
        if(SchoolID.text == ""){
            msgTxt3.text = "<color=red>Field is empty!</color>";
            Debug.Log("<color=red>"+msgTxt3.text+"</color>");
        }

        else{
            StartCoroutine(retrieveStudent());
        }
    }

    IEnumerator retrieveStudent(){
        GameObject dataObj;
        form = new WWWForm();

        form.AddField("SchoolID", SchoolID.text);
        form.AddField("GradeLvl", gradeLvl.options[gradeLvl.value].text);

        Debug.Log(SchoolID.text);
        Debug.Log(gradeLvl.options[gradeLvl.value].text);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/TriviaTempest/retrieve_student.php", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError){
            Debug.Log("Error while sending: "+ www.error);
        }

        else{
            if(www.isDone){
                dataObj = (GameObject)Instantiate(prefab, transform);
                dataObj.GetComponent<Text>().text = www.downloadHandler.text;
                Debug.Log("Received: " + www.downloadHandler.text);
            }      
        }

        www.Dispose();
    }
}
