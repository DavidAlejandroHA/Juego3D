using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEsferaDefinitivo : MonoBehaviour
{
    //int mascara = 1 << 7;
    public float movX, movZ;
    Rigidbody fisicas;
    public float speed = 10f;
    bool estaEnSuelo = false;
    bool quiereSaltar = false;
    public static int numBotones = 0;
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

        // Detectar cuando el personaje está en el suelo usando el RaycastHit
        RaycastHit hit;
        Vector3 origen = transform.position;
        int mascara = 1 << 6;
        // Raycast salto
        if (Physics.Raycast(origen, Vector3.down, out hit, 0.51f, mascara))
        {
            estaEnSuelo = true;
            //Debug.Log(estaEnSuelo);
        }
        else
        {
            estaEnSuelo = false;
            //Debug.Log(estaEnSuelo);
        }
    }

    private void FixedUpdate()
    {
        //Vector3 nuevaVelocidad = new Vector3(movX * speed, fisicas.velocity.y, movZ * speed);
        //fisicas.velocity = nuevaVelocidad;

        // Se añaden constantemente las físicas respecto a los movimientos del teclado
        fisicas.AddForce(movX * speed, 0, movZ * speed, ForceMode.Force);


        // Y se hace saltar al personaje si se cumplen las condiciones
        if (estaEnSuelo && quiereSaltar)
        {
            estaEnSuelo = false;
            quiereSaltar = false;
            fisicas.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }
    }
}