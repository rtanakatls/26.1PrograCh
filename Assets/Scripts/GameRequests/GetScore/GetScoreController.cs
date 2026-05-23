using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetScoreController : MonoBehaviour
{
    private const string URL = "http://localhost/prograch261/game1/get_user.php";
    public void Send(string username, Action<UserResultData> callback)
    {
        StartCoroutine(SendRequest(username, callback));
    }

    private IEnumerator SendRequest(string username, Action<UserResultData> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                callback?.Invoke(JsonUtility.FromJson<UserResultData>(www.downloadHandler.text));
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }

}
