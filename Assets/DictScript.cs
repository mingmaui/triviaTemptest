using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections.Generic;


public class DictScript : MonoBehaviour
{
    [SerializeField] InputField txtBoxSearch;
    [SerializeField] Button searchBtn1;
    [SerializeField] Text showSearch;
    [SerializeField] Text searchDef;

    WWWForm form;


    public void searchBtn(){
        if(txtBoxSearch.text == ""){
            showSearch.text = "<color=red>Please enter a word</color>";
            Debug.Log("<color=red>"+showSearch.text+"</color>");

        }

        else{
            StartCoroutine(FindWord("http://localhost/TriviaTempest/search_dict.php"));
        }
    }

    public void Init(){
        searchDef = GameObject.FindWithTag("sdeftag").GetComponent<Text>();
    }

    IEnumerator FindWord(string url){
        form = new WWWForm();
        form.AddField ("word", txtBoxSearch.text);
        WWW w = new WWW (url, form);
		yield return w;

        if (w.error != null)
        {
            Debug.Log("Error While Sending: " + w.error);
        }
        else{
            Debug.Log("Received: " + w.text);
            searchDef.text=w.text;
        }
    }
}