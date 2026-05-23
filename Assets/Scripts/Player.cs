using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static float timer;
    private Rigidbody rb;

    private void Awake()
    {
        timer = 0;
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(Vector3.up*10, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        SceneManager.LoadScene("GameOverScene");
    }
}
