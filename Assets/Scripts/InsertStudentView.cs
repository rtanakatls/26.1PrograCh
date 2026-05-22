using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InsertStudentView : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private TMP_InputField lastnameInputField;
    [SerializeField] private Button button;
    private InsertStudentController controller;

    private void Awake()
    {
        controller = GetComponent<InsertStudentController>();
        button.onClick.AddListener(Send);
    
    }

    private void Send()
    {
        string name = nameInputField.text;
        string lastname = lastnameInputField.text;
        controller.Send(name, lastname);
    }


}
