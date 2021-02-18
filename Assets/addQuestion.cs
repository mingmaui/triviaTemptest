using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class addQuestion : MonoBehaviour
{
    [SerializeField] InputField RoomCode;
    [SerializeField] InputField Topic;
    [SerializeField] InputField Answer;
    [SerializeField] InputField Desc;
    [SerializeField] Text QstmsgTxt;
    [SerializeField] Text RMmsgTxt;

    WWWForm form;
    public void AddQuestionBtn(){
        if(RoomCode.text == "" | Answer.text == "" | Desc.text == "" | Topic.text == ""){
            QstmsgTxt.text = "<color=red>Please fill up all fields</color>";
            Debug.Log("Please fill up all fields");
        }

        else{
            StartCoroutine(AddQst());
        }        
    }

    IEnumerator AddQst(){
        form = new WWWForm();
        form.AddField("Room_ID", RoomCode.text.ToUpper());
        form.AddField("Answer", Answer.text);
        form.AddField("Description", Desc.text);

        UnityWebRequest w = UnityWebRequest.Post("http://localhost/TriviaTempest/add_question.php", form);
        yield return w.SendWebRequest();

        if(w.isNetworkError) {
            Debug.Log(w.error);
            QstmsgTxt.text = "<color=red>Error: 404 not found</color>";
            Debug.Log("<color=red>"+QstmsgTxt.text+"</color>");
        }
        else {
            if(w.isDone){
                QstmsgTxt.text = "Question added successfully!";
                Debug.Log("Question added successfully!");
            }
            
        }
        
        w.Dispose();
    }


    ////////////////////////ROOM///////////////////////
    WWWForm form1;
    public void CreateRoom(){
        if(RoomCode.text == "" | Topic.text == ""){
            RMmsgTxt.text = "<color=red>Please fill up all fields</color>";
            Debug.Log("Please fill up all fields");
        }

        else{
            StartCoroutine(create_room());
        }        
    }

    IEnumerator create_room(){
        form1 = new WWWForm();
        form1.AddField("Room_ID", RoomCode.text.ToUpper());
        form1.AddField("Topic", Topic.text);

        UnityWebRequest w = UnityWebRequest.Post("http://localhost/TriviaTempest/create_room.php", form1);
        yield return w.SendWebRequest();

        if(w.isNetworkError) {
            Debug.Log(w.error);
            RMmsgTxt.text = "<color=red>Error: 404 not found</color>";
            Debug.Log("<color=red>"+RMmsgTxt.text+"</color>");
        }
        else {
            if(w.isDone){
                RMmsgTxt.text = "Room Created successfully!";
                Debug.Log("Room Created successfully!");
                RoomCode.interactable = false;
                Topic.interactable = false;
            }
            
        }
        
        w.Dispose();
    }

}
