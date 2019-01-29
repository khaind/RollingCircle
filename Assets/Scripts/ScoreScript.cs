using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Text;

[RequireComponent(typeof(Text))]
public class ScoreScript : MonoBehaviour {

    public User usr;
    public string scoreStr = "Your Score is ";
    Scene currentScene;
    Text scoreText;
    const string leaderBoardUrl = "192.168.1.1";

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        scoreText = gameObject.GetComponent<Text>();


        // Update score text in GameOver scene
        if (currentScene.name.Equals("GameOver"))
        {
            scoreText.text = scoreStr + usr.score.ToString();

            // Send score to leaderboard service
            StartCoroutine("PostScore");
        }
    }

    private void Update()
    {
        // Update score text in Game scene
        if(currentScene.name.Equals("Game"))
        {
            scoreText.text = scoreStr + usr.score.ToString();
        }
    }


    // Post user score to leaderboard services
    // TODO UnityWebRequest initialization might be incorrect currently
    IEnumerator PostScore()
    {
        Debug.Log("Posting score to leaderboard service");

        // Get score data as string
        string data = JsonUtility.ToJson(usr,true);
        Debug.Log(data);

        // request
        var uwr = new UnityWebRequest(leaderBoardUrl, "POST /leaderboard");

        // data as bytes
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(data);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
            switch (uwr.responseCode)
            {
                case 404:
                    Debug.Log("404: Username not found(user has not registered with the leaderboard service)");
                    break;
                case 405:
                    Debug.Log("405: Invalid Username supplied");
                    break;
                case 200:
                    Debug.Log("200: Ok");
                    break;

                default:
                    Debug.Log("Unknown response code");
                    break;
            }
        }
    }

}
