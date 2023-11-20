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
    //public TextMeshProUGUI textoGanar;

    public float radioRaycast = 0.5f;

    Color blanco = new Color(255, 255, 255);
    Color rojo = new Color(255, 0, 0);

    Vector3 escalaCero = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 escalaUno = new Vector3(1.0f, 1.0f, 1.0f);

    // Start is called before the first frame update
    void Start()
    { 
        fisicas = GetComponent<Rigidbody>();
        panelGanar.transform.localScale = escalaCero;
        panelPerder.transform.localScale = escalaCero;

        // Esto daba problemas ya que al estar desactivados los paneles luego habían elementos que daban NullReferenceException
        //panelGanar.SetActive(false);
        //panelPerder.SetActive(false);
        //Al final les cambié la escala a 0 desde el inicio (visualmente es lo mismo)

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
            // Se comprueba constantemente las teclas pulsadas para cambiar el color de las flechas según qué teclas estén pulsadas
            cambioColorFlechas(flechaIzquierdaMenu, KeyCode.A);
            cambioColorFlechas(flechaDerechaMenu, KeyCode.D);
            cambioColorFlechas(flechaArribaMenu, KeyCode.W);
            cambioColorFlechas(flechaAbajoMenu, KeyCode.S);
        }

        // Si está intentando saltar y está en el suelo se pone saltando
        // Raycast salto
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
        if (Physics.Raycast(origen, Vector3.down, out hit, 0.51f, mascara)){
            estaEnSuelo = true;
            Debug.Log(estaEnSuelo);
        }
        else
        {
            estaEnSuelo = false;
            Debug.Log(estaEnSuelo);
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
            TextoGanar.objetoTexto.text = TextoGanar.objetoTexto.text
               + MonedasCount.numMonedas + " monedas del mapa en " + segundos.ToString("f2") + " segundos.";
            //textoGanar.text = TextoGanar.objetoTexto.text + MonedasCount.numMonedas + " monedas del mapa en " + segundos.ToString("f2") + " segundos.";
            panelGanar.transform.localScale = escalaUno;
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
        // Si choca con el suelo el personaje podrá saltar
        /*if (collision.gameObject.tag == "suelo")
        {
            estaEnSuelo = true;
        } else */
        if (collision.gameObject.tag == "enemigo")
        {
            // Si choca con el enemigo el juego se termina
            Pausar();
            finalPartida = true;
            panelPerder.transform.localScale = escalaUno;
        }
        else
        {

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Al salir del suelo se detectan los cambios
        //if (collision.gameObject.tag == "suelo")
        //{
            //estaEnSuelo = false;
        //}
    }

        void Pausar()
    {
        // Se pausa el tiempo y la partida
        pausado = true;
        Time.timeScale = 0f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, new Vector3(0f, -radioRaycast, 0f));
    }


}
