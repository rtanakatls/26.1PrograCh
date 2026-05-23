using TMPro;
using UnityEngine;

public class GetRankingView : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform container;
    private GetRankingController controller;

    private void Awake()
    {
        controller=GetComponent<GetRankingController>();
    }

    public void Send()
    {
        controller.Send(OnResult);
    }

    private void OnResult(UserResultData result)
    {
        if (result.data.Length > 0)
        {
            foreach (UserData user in result.data) 
            {
                GameObject item = Instantiate(prefab, container);
                item.GetComponent<TextMeshProUGUI>().text= $"{user.username} - {user.score}";
            }
        }
    }

}
