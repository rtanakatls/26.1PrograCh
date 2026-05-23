using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetScoreView : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI oldScoreText;
    [SerializeField] private Button button;
    private GetScoreController controller;

    private void Awake()
    {
        scoreText.text = $"Current Score: {(int)Player.timer}";
        controller = GetComponent<GetScoreController>();
        button.onClick.AddListener(Send);
    }

    private void Send()
    {
        string username= usernameInputField.text;
        controller.Send(username, OnGetOldScore);  
    }

    private void OnGetOldScore(UserResultData userResult)
    {
        if (userResult!=null && userResult.data!=null && userResult.data.Length>0)
        {
            oldScoreText.text = $"Old Score: {userResult.data[0].score}";

        }
        else
        {
            oldScoreText.text = "User not found.";
        }
    }
}
