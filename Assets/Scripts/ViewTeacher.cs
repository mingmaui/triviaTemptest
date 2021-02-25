using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ViewTeacher : MonoBehaviour
{
    [SerializeField] InputField SchoolID;
    [SerializeField] Text msgTxt1;
    public GameObject prefab;
    WWWForm form;

    public void SearchBtn(){
        if(SchoolID.text == ""){
            msgTxt1.text = "<color=red>Field is empty!</color>";
            Debug.Log("<color=red>"+msgTxt1.text+"</color>");
        }

        else{
            StartCoroutine(retrieveTeacher());
        }
    }

    IEnumerator retrieveTeacher(){
        GameObject dataObj;
        form = new WWWForm();

        form.AddField("SchoolID", SchoolID.text);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/TriviaTempest/retrieve_teacher.php", form);
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
