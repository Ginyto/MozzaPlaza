using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ginyto : MonoBehaviour
{
    public Camera MainCamera;
    public Transform body;
    public float speed;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        LockMouse();
        Move();
        CameraOnMouse();
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    public void CameraOnMouse()
    {

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, mouseX * 2);
        MainCamera.transform.Rotate(Vector3.right, -mouseY * 2);
    }

    public void LockMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
