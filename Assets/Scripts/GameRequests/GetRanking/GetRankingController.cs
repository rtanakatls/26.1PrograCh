using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetRankingController : MonoBehaviour
{
    private const string URL = "http://localhost/prograch261/game1/get_ranking.php";
    public void Send(Action<UserResultData> callback)
    {
        StartCoroutine(SendRequest( callback));
    }

    private IEnumerator SendRequest( Action<UserResultData> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(URL))
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
