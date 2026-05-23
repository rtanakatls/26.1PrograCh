using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UploadScoreView : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private Button button;
    private UploadScoreController controller;

    private void Awake()
    {
        controller = GetComponent<UploadScoreController>();
        button.onClick.AddListener(Send);
    }

    private void Send()
    {
        string username = usernameInputField.text;
        int score = (int)Player.timer;
        controller.Send(username, score, OnResult);
    }

    private void OnResult()
    {

        GetComponent<GetRankingView>().Send();
    }

}
