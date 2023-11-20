using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausaResumen : MonoBehaviour
{
    bool pausado = false;
    public GameObject panelMenu;
    Vector3 escalaCero = new Vector3(0f, 0f, 0f);
    Vector3 escalaUno = new Vector3(1f, 1f, 1f);
    // Start is called before the first frame update
    void Start()
    {
        panelMenu.transform.localScale = escalaCero;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Si se usa la tecla Esc
        if (Input.GetKeyDown(KeyCode.Escape) && !MovimientoPersonaje.finalPartida)
        {
            if (pausado)
            {
                resumir(); // Se resume el juego
            }
            else
            {
                pausar(); // Se pausa el juego
            }
        }
    }

    // Pausar la escala de tiempo
    public void pausar()
    {
        panelMenu.transform.localScale = escalaCero;
        //LeanTween.cancel(panelMenu); // Interrumpe la animación en caso de que se estuviera reproduciendo
        Time.timeScale = 0f;
        MovimientoPersonaje.pausado = true;
        pausado = true;
        LeanTween.scale(panelMenu, panelMenu.transform.localScale + new Vector3(1f, 1f, 1f), 0.5f).setEaseOutBounce().setIgnoreTimeScale(true);
        // La animación de mostrar el menú se reproduce

    }

    // Retomar la escala de tiempo
    public void resumir()
    {
        if (pausado)
        {
            panelMenu.transform.localScale = escalaUno;
            //LeanTween.cancel(panelMenu); // Interrumpe la animación en caso de que se estuviera reproduciendo
            //if (!MovimientoPersonaje.finalPartida)
            Time.timeScale = 1f;
            MovimientoPersonaje.pausado = false;
            pausado = false;
            LeanTween.scale(panelMenu, panelMenu.transform.localScale - new Vector3(1f, 1f, 1f), 0.5f).setEaseInBounce().setIgnoreTimeScale(true);
            // La animación de ocultar el menú se reproduce
        }
    }
}
