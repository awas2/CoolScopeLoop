#if UNITY_EDITOR
using UnityEngine;

public class EditorTest : MonoBehaviour
{
    [SerializeField] float sensitivity = 1000;
    Transform player;
    float XRotate = 0;
    bool exit = true;
    bool isFirst;

    void Start()
    {
        player = transform.parent;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Flipper();
        }
        if (exit) return;
        if (isFirst && Input.GetAxis("Mouse X") != 0)
        {
            isFirst = false;
            return;
        }
        float MouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        XRotate -= MouseY;
        XRotate = Mathf.Clamp(XRotate, -90, 90);
        transform.localRotation = Quaternion.Euler(XRotate, 0, 0);
        player.Rotate(Vector3.up * MouseX);
    }
    void Flipper()
    {
        exit = !exit;
        if (Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
            isFirst = true;
        }
        else if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
#endif