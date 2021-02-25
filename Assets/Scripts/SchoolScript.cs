using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SchoolScript : MonoBehaviour
{
    public GameObject prefab;
    public string[] schoolArr;
    WWWForm form;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(retrieveSchool());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void Populate(){
    //     GameObject dataObj;

    //     dataObj = (GameObject)Instantiate(prefab, transform);
    //     dataObj.GetComponent<Image>().
    // }

    IEnumerator retrieveSchool(){
        GameObject dataObj;
        //List<GameObject> schoolList = new List<GameObject>();
        form = new WWWForm();
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/TriviaTempest/view_school.php", form);
        yield return www.SendWebRequest();

        // string schoolList = www.downloadHandler.text;
        // schoolArr = schoolList.Split(',');
        // Debug.Log(schoolList);
        // Debug.Log(schoolArr);
        // List<string> myList = new List<string>(schoolArr);
        // // DataRecord row = new DataRecord();
        // // myList.Add(row);
        // foreach (string arrItem in schoolArr)
        // {
        //     myList.Add(arrItem);
        // }

        if (www.isNetworkError){
            Debug.Log("Error while sending: "+ www.error);
        }

        else{
            if(www.isDone){
                //string[] arr =  www.downloadHandler.text.Split(',');
                //Debug.Log("school: "+arr);
                
                dataObj = (GameObject)Instantiate(prefab, transform);
                dataObj.GetComponent<Text>().text = www.downloadHandler.text;
                Debug.Log("Received: " + www.downloadHandler.text);
            }      
        }

        www.Dispose();
    }
}
