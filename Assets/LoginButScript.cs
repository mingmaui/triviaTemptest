using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoginButScript : MonoBehaviour
{
    public InputField UnField = null;
    public InputField PwdField = null;
    public string un = "admin";
    public string pwd = "admin1234";
    public string unStud = "student";
    public string pwdStud = "student1234";

    public void LoginButton()
    {
        if(UnField.text == un && PwdField.text == pwd){
            Debug.Log("Login Successfully");
            SceneManager.LoadScene(sceneName:"TeacherMenu");
        }
        
        if(UnField.text == unStud && PwdField.text == pwdStud){
            Debug.Log("Login Successfully");
            SceneManager.LoadScene(sceneName:"StudentMenu");
        }

        else{
            Debug.Log("Login Failed");
        }
        

    }

    public void LogoutButton(){
        SceneManager.LoadScene(sceneName:"LoginScene");
    }

   

    //public void SubmitButton(){ //string username, string password
        //Debug.Log("Done");
        // string connStr = "server=localhost;user=root;database=triviadb;port=3380;password=";
        // MySqlConnection conn = new MySqlConnection(connStr);
        // try
        // {
        //     Console.WriteLine("Connecting to MySQL...");
        //     conn.Open();

        //     string sql = "SELECT username, password FROM login where username='"+username+"' and password='"+password+"'";
        //     MySqlCommand cmd = new MySqlCommand(sql, conn);
        //     MySqlDataReader rdr = cmd.ExecuteReader();

        //     // while (rdr.Read())
        //     // {
        //     //     if(rdr[0]==username & rdr[1]==password){
        //     //         Console.WriteLine("Login Successfully");
        //     //     }

        //     //     else{
        //     //         Console.WriteLine("Invalid");
        //     //     }
                
        //     // }
        //     rdr.Close();
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.ToString());
        // }

        // conn.Close();
        
    //}
}
