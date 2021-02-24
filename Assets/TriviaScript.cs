using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;

public class TriviaScript : MonoBehaviour
{
    public Text displayAnswer;
    public Text displayDesc;
    public InputField inputAns;
    public Text scoreBoard;
    public string SessionCode = "";
    public GameObject gameScene;
    public GameObject scoreScene;
    public Text finalScoreUI;
    List<List<string>> container = new List<List<string>>();
    
    private int score = 0;
    private int current = 0;
    string correctAns;


    void Start()
    {
        SessionCode = GameObject.Find("sessionhandler").GetComponent<RoomScript>().GetSessionCode();
        StartCoroutine(FindAnswer("http://localhost/TriviaTempest/get_answersTM.php"));
        Debug.Log("Room Found!" + SessionCode);
    }

    
    void Update()
    {
       InputAns();
       scoreBoard.text = score.ToString();
    }

    //for input answer
    public void InputAns()
    {
       if(Input.GetKeyDown(KeyCode.Return))
       {
           Debug.Log(correctAns + "SAGOT");
            if(inputAns.text == correctAns)
            {
                Debug.Log("correct");
                score+=10;
                NextQuestion();
                //checker();
            }
            else{
                Debug.Log("incorrect");
                inputAns.text = "";
            }    
        } 
    }

    void NextQuestion(){
        current++;
        if(current < container.Count)
        {
            Change();
        }
        else{
            checker();
        }
    }

    void Change(){
        displayAnswer.text = new string(container[current][0].ToUpper().ToCharArray().OrderBy(x=>Guid.NewGuid()).ToArray());
        displayDesc.text = container[current][1];
        correctAns = container[current][0];
    }

    public void checker(){
        if(current >= container.Count){
            StartCoroutine(SubmitScore("http://localhost/TriviaTempest/submit_scrTM.php"));
            showScore();
        }
    }

    public void showScore(){
        gameScene.SetActive(false);
        scoreScene.SetActive(true);
        finalScoreUI.text = score.ToString();
    }

    
    IEnumerator FindAnswer(string url)
    {
        WWWForm form = new WWWForm ();
		form.AddField ("SC", SessionCode);
        Debug.Log(SessionCode+" hello");

		WWW w = new WWW (url, form);
		yield return w;

        if(w.isDone)
        {
            Debug.Log(w.text+" hi");
            string[] temp = w.text.Split('#');

            for(int i = 0; i < temp.Length; i++){
                List<string> holder = new List<string>();
                string[] temps = temp[i].Split('|');
                holder.Add(temps[0]);
                holder.Add(temps[1]);
                container.Add(holder);

            }
            Change();
        }
    }

    IEnumerator SubmitScore(string url)
    {
        WWWForm form = new WWWForm ();
        form.AddField ("RoomID", SessionCode);
        form.AddField ("Score", score);
        Debug.Log(SessionCode+" hello");

		WWW w = new WWW (url, form);
		yield return w;

        if(w.isDone)
        {
            Debug.Log(w.text+" Score Added!"); 
        }
    }
}