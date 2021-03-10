using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //declaração das variáveis
    public CharacterController controller;

    private float initialHeight = 1.8f;
    private float initialSpeed = 12f;
    public float speed = 12f;
    public float weight = 60f;
    public float height = 1.8f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Gun primaryGun;
    public Gun secundaryGun;
    public Transform cameraTransform;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Awake() 
    {
        initialHeight = height;
        initialSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {

        height = initialHeight;
        speed = initialSpeed;
        // speed = speed - (weight * 0.1f);


        //criar uma sphera pra checar se o personagem ta no chão ou não
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    
        //criação do andar
        if(Input.GetButton("Walk") && isGrounded)
        {
            speed = (initialSpeed / 2);
        }

        //criação do agachamento
        if(Input.GetButton("Duck"))
        {
            height = (initialHeight / 2);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //aumentar a velocidade da queda de acordo com a gravidade
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        cameraTransform.localPosition = height * Vector3.up;
    }

}
