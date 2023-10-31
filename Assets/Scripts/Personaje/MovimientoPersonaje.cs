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
    public static bool finalPartida = false;
    float segundos = 0f;
    public GameObject panelGanar;
    public GameObject panelPerder;
    public static string monedasTextoAux;
    // Start is called before the first frame update
    void Start()
    {
        fisicas = GetComponent<Rigidbody>();
        //textoTiempo = TiempoJugadoTexto.objetoTexto.text;
        panelGanar.SetActive(false);
        panelPerder.SetActive(false);

        monedasTextoAux = MonedasTexto.objetoTexto.text;
        MonedasTexto.objetoTexto.text = monedasTextoAux + CapsulaMoneda.monedas;

        //https://discussions.unity.com/t/playing-audio-on-collision/161497/2
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");

        // Si est� intentando saltar y est� en el suelo se pone saltando
        if (Input.GetButton("Jump") /*Input.GetButtonDown*/)
        {
            if (estaEnSuelo)
            {
                quiereSaltar = true;
            }
        }

        // Si est� pausado se para el tiempo
        if (!pausado)
        {
            segundos += Time.deltaTime;
            TiempoJugadoTexto.objetoTexto.text = segundos.ToString("f2") + " seg.";
        }


        // Si se recogen todas las monedas se gana la partida
        if (MonedasCount.numMonedas == CapsulaMoneda.monedas && !pausado)
        {
            Pausar();
            finalPartida = true;
            TextoGanar.objetoTexto.text = TextoGanar.objetoTexto.text + MonedasCount.numMonedas + " monedas del mapa en " + segundos.ToString("f2") + " segundos.";
            panelGanar.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        //Vector3 nuevaVelocidad = new Vector3(movX * speed, fisicas.velocity.y, movZ * speed);
        //fisicas.velocity = nuevaVelocidad;
        
        // Se a�aden constantemente las f�sicas respecto a los movimientos del teclado
        fisicas.AddForce(movX * speed, 0, movZ * speed, ForceMode.Force);


        // Y se hace saltar al personaje si se cumplen las condiciones
        if (estaEnSuelo && quiereSaltar)
        {
            estaEnSuelo = false;
            quiereSaltar = false;
            fisicas.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //
        if (collision.gameObject.tag == "suelo")
        {
            estaEnSuelo = true;
        } else if (collision.gameObject.tag == "enemigo")
        {
            Pausar();
            finalPartida = true;
            //TextoGanar.objetoTexto.text = TextoGanar.objetoTexto.text + segundos + " segundos.";
            panelPerder.SetActive(true);
        }
        else
        {

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "suelo")
        {
            estaEnSuelo = false;
        }
    }

        void Pausar()
    {
        pausado = true;
        Time.timeScale = 0f;
    }

    
}
