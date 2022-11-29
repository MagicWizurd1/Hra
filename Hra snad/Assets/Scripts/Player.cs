using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 10f;
    private float movementX = 22f;

    private Rigidbody myBody;
    private SpriteRenderer sr;
    private Animator anim;
    //private String "WALK_ANIMATION";

    private bool isGrounded;
    

    
    // Start is called before the first frame update
    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        PlayerJump();
    }
    void PlayerMoveKeyboard()
    {

        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0, 0) * Time.deltaTime * moveForce;


    }
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
