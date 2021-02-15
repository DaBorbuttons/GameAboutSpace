using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velZ = 25f;
    Rigidbody bala;
    void Start()
    {
        bala = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bala.velocity = new Vector3(0, 0, velZ);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject, 0.001f);
        }
    }
}
