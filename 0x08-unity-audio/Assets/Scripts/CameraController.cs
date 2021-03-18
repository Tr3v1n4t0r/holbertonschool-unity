using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float sensitivity = 2.0f;
    public bool isInverted = false;

    private Vector3 offset;
    private float distance;

    private float rotateX = 0f;
    private float rotateY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        distance = Vector3.Distance(transform.position, player.transform.position);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        rotateX += Input.GetAxis("Mouse X") * sensitivity;
        if (isInverted)
        {
            rotateY += Input.GetAxis("Mouse Y") * -sensitivity;
        }
        else
        {
            rotateY += Input.GetAxis("Mouse Y") * sensitivity;
        }

        rotateY = Mathf.Clamp(rotateY, 5f, 89.9f);

        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(rotateY, rotateX, 0);
        transform.position = player.transform.position + rotation * direction;

        transform.LookAt(player.transform.position);
        //playerDirection = transform.rotation * new Vector3(rotateX, 0.0f, rotateY);
    }

}
