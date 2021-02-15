using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float jump = 6;
    public float gravity = -20;

    private float hr, vr;
    public FixedJoystick joy;

    Vector3 movIn = Vector3.zero;
    CharacterController ch;

    public GameObject bala;
    public GameObject position;
    Vector3 pos;
    public float tDisp = 0.5f;
    float sigDisp = 0.0f;

    public Camera cam;
    public GameObject camFPS;
    public GameObject camTPS;
    bool fps = false;

    private void Awake()
    {
        ch = GetComponent<CharacterController>();
    }
    private void Update()
    {
        hr = joy.Horizontal;
        vr = joy.Vertical;
        Movemento();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpIn();
        }
    }

    public void Movemento()
    {
        if (ch.isGrounded)
        {
            movIn = new Vector3(hr, 0f, vr);
            movIn = transform.TransformDirection(movIn * speed);
        }

        movIn.y += gravity * Time.deltaTime;
        ch.Move(movIn * Time.deltaTime);
    }

    public void JumpIn()
    {
        if (ch.isGrounded)
        {
            movIn.y = Mathf.Sqrt(jump * -2f * gravity);
        }
        movIn.y += gravity * Time.deltaTime;
        ch.Move(movIn * Time.deltaTime);
    }

    public void Shoot()
    {
        pos = position.transform.position;
        if (Time.time > sigDisp)
        {
            sigDisp = Time.time + tDisp;
            Instantiate(bala, pos, Quaternion.identity);
        }
    }

    public void CameraC()
    {
        if (fps == false)
        {
            fps = true;
            cam.transform.position = camFPS.transform.position;
        }
        else
        {
            fps = false;
            cam.transform.position = camTPS.transform.position;
        }
    }
}