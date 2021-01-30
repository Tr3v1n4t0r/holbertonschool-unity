using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Camera;
    public float Speed = 5f;
    public float jumpForce = 2f;
    
    private Rigidbody body;
    private Vector3 movement;
    private bool groundCheck = true;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Quaternion rotate = Camera.transform.rotation;
        rotate.z = 0;
        rotate.x = 0;

        transform.rotation = rotate;

        Vector3 move = transform.right * Horizontal + transform.forward * Vertical;

        if (Input.GetButtonDown("Jump") && groundCheck)
        {
            body.AddForce(Vector3.up * Mathf.Sqrt(jumpForce * -2 * Physics.gravity.y), ForceMode.VelocityChange);
        }
        body.MovePosition(body.position + move * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        groundCheck = true;
    }
    private void OnCollisionExit(Collision other)
    {
        groundCheck = false;
    }
}
