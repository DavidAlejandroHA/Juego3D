using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float movX, movZ;
    Rigidbody fisicas;
    public float speed = 10f;
    bool estaEnSuelo = false;
    bool quiereSaltar = false;
    // Start is called before the first frame update
    void Start()
    {
        fisicas = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");

        if (Input.GetButton("Jump") /*Input.GetButtonDown*/)
        {
            if (estaEnSuelo)
            {
                quiereSaltar = true;
            }
        }


    }

    private void FixedUpdate()
    {
        Vector3 nuevaVelocidad = new Vector3(movX * speed, fisicas.velocity.y, movZ * speed);
        fisicas.velocity = nuevaVelocidad;

        if (estaEnSuelo && quiereSaltar)
        {
            estaEnSuelo = false;
            quiereSaltar = false;
            fisicas.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "suelo")
        {
            estaEnSuelo = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "moneda")
        {
            Destroy(collider.gameObject);
            //Debug.Log("A");
        }
    }
}
