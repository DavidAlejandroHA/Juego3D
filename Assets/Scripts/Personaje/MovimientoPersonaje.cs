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
    bool pausado = false;
    float segundos = 0f;
    string textoTiempo;
    public GameObject panelGanar;
    public GameObject panelPerder;
    // Start is called before the first frame update
    void Start()
    {
        fisicas = GetComponent<Rigidbody>();
        textoTiempo = TiempoJugadoTexto.objetoTexto.text;
        panelGanar.SetActive(false);
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

        if (!pausado)
        {
            segundos += Time.deltaTime;
            TiempoJugadoTexto.objetoTexto.text = textoTiempo + segundos.ToString("f2") + " seg.";
        }

        if (MonedasCount.numMonedas == CapsulaMoneda.monedas)
        {
            Pausar();
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
        } else if (collision.gameObject.tag == "enemigo")
        {
            Pausar();
            //TextoGanar.objetoTexto.text = TextoGanar.objetoTexto.text + segundos + " segundos.";
            panelPerder.SetActive(true);
        }
    }

    void Pausar()
    {
        pausado = true;
        Time.timeScale = 0f;
    }

    
}
