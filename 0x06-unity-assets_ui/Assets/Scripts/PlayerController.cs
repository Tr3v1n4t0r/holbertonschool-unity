using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject Camera;
    public float Speed = 5f;
    public float jumpForce = 4f;
    public float fallMultiplier = 1.8f;
    
    private Rigidbody body;
    private Vector3 movement;
    private bool groundCheck = true;
    private bool GameIsPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        PlayerPrefs.SetInt("lastLevel", SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameIsPaused)
        {
            Movement();
            FallCheck();
            if (body.velocity.y < 0)
            {
                body.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
        }
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

    private void FallCheck()
    {
        if (transform.position.y < -40)
        {
            transform.position = new Vector3(0, 50, 0);
        }
    }

    public void TogglePause()
    {
        GameIsPaused = !GameIsPaused;
    }
}
