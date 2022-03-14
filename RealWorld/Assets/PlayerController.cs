using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public float MovementSpeed =1;
    public float Gravity = 9.8f;
    private float velocity = 0;
	
	public float jumpSpeed = 2.0f;
	private Vector3 movingDirection = Vector3.zero;
	

    private Camera cam;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    void Update()
    {
        // player movement - forward, backward, left, right
        float horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
        float vertical = Input.GetAxis("Vertical") * MovementSpeed;
        characterController.Move((cam.transform.right * horizontal + cam.transform.forward * vertical) * Time.deltaTime);

        // Gravity
        if(characterController.isGrounded)
        {
            velocity = 0;
        }
        else
        {
            velocity -= Gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }
		// Running
		if (Input.GetKey(KeyCode.LeftShift)) {
 
            MovementSpeed = 4;
            print ("Running");
 
        } else {
 
            MovementSpeed = 1;
            print ("Not Running");
 
        }
		// Jumping
		
		
		if (characterController.isGrounded && Input.GetButton("Jump")) {
			movingDirection.y = jumpSpeed;
		}
		movingDirection.y -= Gravity * Time.deltaTime;
		characterController.Move(movingDirection * Time.deltaTime);
		
    }
}
