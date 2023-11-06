using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MovimientoPersonaje : MonoBehaviour
{
    public float movX, movZ;
    public GameObject flechaIzquierdaMenu;
    public GameObject flechaDerechaMenu;
    public GameObject flechaArribaMenu;
    public GameObject flechaAbajoMenu;
    Rigidbody fisicas;
    public float speed = 10f;
    bool estaEnSuelo = false;
    bool quiereSaltar = false;
    public static bool pausado = false;
    public static bool finalPartida = false;
    float segundos = 0f;
    public GameObject panelGanar;
    public GameObject panelPerder;
    public static string monedasTextoAux;
    TextMeshProUGUI textoGanar;

    Color blanco = new Color(255, 255, 255);
    Color rojo = new Color(255, 0, 0);

    // Start is called before the first frame update
    void Start()
    { 
        fisicas = GetComponent<Rigidbody>();
        //textoTiempo = TiempoJugadoTexto.objetoTexto.text;
        textoGanar = TextoGanar.objetoTexto;
        Debug.Log(textoGanar);
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

        if (!pausado && !finalPartida)
        {
            cambioColorFlechas(flechaIzquierdaMenu, KeyCode.A);
            cambioColorFlechas(flechaDerechaMenu, KeyCode.D);
            cambioColorFlechas(flechaArribaMenu, KeyCode.W);
            cambioColorFlechas(flechaAbajoMenu, KeyCode.S);
        }

        // Si está intentando saltar y está en el suelo se pone saltando
        if (Input.GetButton("Jump") /*Input.GetButtonDown*/)
        {
            if (estaEnSuelo)
            {
                quiereSaltar = true;
            }
        }

        // Si está pausado se para el tiempo
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
            //textoGanar = GameObject.Find("GanarTexto (TMP)").GetComponent<TextMeshProUGUI>();
            TextoGanar.objetoTexto.text = TextoGanar.objetoTexto.text
                + MonedasCount.numMonedas + " monedas del mapa en " + segundos.ToString("f2") + " segundos.";
            //textoGanar.text = TextoGanar.objetoTexto.text + MonedasCount.numMonedas + " monedas del mapa en " + segundos.ToString("f2") + " segundos.";
            panelGanar.SetActive(true);
        }
    }

    void cambioColorFlechas(GameObject flecha, KeyCode tecla)
    {
        if (Input.GetKey(tecla))
        {
            flecha.GetComponent<RawImage>().color = rojo;
        }
        else
        {
            flecha.GetComponent<RawImage>().color = blanco;
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
