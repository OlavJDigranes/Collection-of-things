using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed, rotationSpeed, jumpForce;

    Rigidbody rb;

    Camera myCamera;

    bool isJumping;

    public float currentHealth, maximumHealth;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        myCamera = Camera.main;
    }
    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        currentHealth = maximumHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }


    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 inputVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        inputVelocity = inputVelocity * movementSpeed * Time.deltaTime;

        if (!isJumping)
        {
            rb.MovePosition(transform.position + (transform.forward * inputVelocity.z) + (transform.right * inputVelocity.x));
        }
        else
        {
            rb.MovePosition(transform.position + rb.velocity);
        }

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float horizontalRotation = mouseX * rotationSpeed * Time.deltaTime;
        float verticalRotation = mouseY * rotationSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up, horizontalRotation);
        myCamera.transform.rotation = myCamera.transform.rotation * Quaternion.Euler(new Vector3(-verticalRotation, 0, 0));

        //find ouyt how to roll a base rotation
        //rb.rotation = Quaternion.Euler(new Vector3(0, Time.deltaTime, 0));
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }

    /*// Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    */
}