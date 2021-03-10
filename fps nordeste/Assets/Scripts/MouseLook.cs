using UnityEngine;

public class MouseLook : MonoBehaviour
{

    //declaração das variáveis
    public float mouseSensitivity = 100f;

    public Transform playerBody;
    public GameObject crosshair;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        //bloqueio do cursor in game
        Cursor.lockState = CursorLockMode.Locked;
        crosshair.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //inverter rotação Y
        xRotation -= mouseY;

        //limitar rotação X
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //rotacionar o player de acordo com a movimentação do mouse
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
