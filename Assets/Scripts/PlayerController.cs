using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    //Movimiento
    public float speed = 5;
    public float jump = 6;
    public float gravity = -20;

    private float hr, vr;
    public FixedJoystick joy;
    
    Vector3 movIn = Vector3.zero;
    CharacterController ch;
    //Movimiento

    //Bala
    public GameObject bala;
    Vector3 posBala;
    public float tDisp = 0.5f;
    float sigDisp = 0.0f;

    public GameObject balaFPS;
    public GameObject balaTPS;

    //Bala

    //Posiciones de la camara
    public Camera cam;
    public GameObject camFPS;
    public GameObject camTPS;
    //Posiciones de la camara


    private void Awake()
    {
        ch = GetComponent<CharacterController>();
        cam.transform.position = camTPS.transform.position;
    }

    private void Update()
    {
        if (cam.transform.position == camTPS.transform.position)
        {
            posBala = balaTPS.transform.position;
        }
        if (cam.transform.position == camFPS.transform.position)
        {
            posBala = balaFPS.transform.position;
        }
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
        //pos = position.transform.position;
        if (Time.time > sigDisp)
        {
            sigDisp = Time.time + tDisp;
            Instantiate(bala, posBala, Quaternion.identity);
        }
    }

    public void CameraC()
    {
        //La camara siempre inicia en 3ra persona
       //Si la camara está en FP entonces la bala se dispara desde FP      
        if (cam.transform.position == camTPS.transform.position)
        {
            cam.transform.position = camFPS.transform.position;
        }
        else
        {
            cam.transform.position = camTPS.transform.position;
        }
    }
}