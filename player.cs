using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rigidbodyComponent;
    private bool isGrounded;
    private int superJumpsRemaining;

    [SerializeField] private Transform GroundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    // fixed update
    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(horizontalInput * 6, rigidbodyComponent.velocity.y, 0);

        if (Physics.OverlapSphere(GroundCheckTransform.position, 1, playerMask).Length == 0)
        {
            return;
        }

        if (jumpKeyWasPressed)
        {
            float jumpPower = 5;

            if (superJumpsRemaining > 0)
            {
                jumpPower *= 2;
                superJumpsRemaining--;
            }
            rigidbodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    if (other.gameObject.layer==9)
        {
            Destroy(other.gameObject);
            superJumpsRemaining++;
        }

}
