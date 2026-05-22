using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class SelectAllStudentsController : MonoBehaviour
{
    private const string URL = "http://localhost/prograch261/library/select_all_students.php";
    [SerializeField] private StudentResultdata result;
    
    private void Start()
    {
        StartCoroutine(SendRequest());
    }

    IEnumerator SendRequest()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(URL))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                result=JsonUtility.FromJson<StudentResultdata>(www.downloadHandler.text);
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }
}
