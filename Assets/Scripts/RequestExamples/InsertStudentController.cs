using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class InsertStudentController : MonoBehaviour
{
    private const string URL = "http://localhost/prograch261/library/insert_student.php";

    public void Send(string name, string lastname)
    {
        StartCoroutine(SendRequest(name, lastname));
    }

    IEnumerator SendRequest(string name, string lastname)
    {
        WWWForm form =new WWWForm();
        form.AddField("name", name);
        form.AddField("lastname", lastname);
        using (UnityWebRequest www= UnityWebRequest.Post(URL,form))
        {
            yield return www.SendWebRequest();

            if(www.result==UnityWebRequest.Result.Success)
            {
                Debug.Log(www.downloadHandler.text);
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }
}
