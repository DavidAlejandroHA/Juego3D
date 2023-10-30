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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado)
            {
                panelMenu.transform.localScale = escalaUno;
                //LeanTween.cancel(panelMenu); // Interrumpe la animación en caso de que se estuviera reproduciendo
                resumir(); // Se resume el juego
                LeanTween.scale(panelMenu, panelMenu.transform.localScale - new Vector3(1f, 1f, 1f), 0.5f).setEaseInBounce().setIgnoreTimeScale(true);
                // La animación de ocultar el menú se reproduce
            }
            else
            {
                panelMenu.transform.localScale = escalaCero;
                //LeanTween.cancel(panelMenu); // Interrumpe la animación en caso de que se estuviera reproduciendo
                pausar(); // Se pausa el juego
                LeanTween.scale(panelMenu, panelMenu.transform.localScale + new Vector3(1f, 1f, 1f), 0.5f).setEaseOutBounce().setIgnoreTimeScale(true);
                // La animación de mostrar el menú se reproduce
            }
        }
    }

    // Pausar la escala de tiempo
    void pausar()
    {
        Time.timeScale = 0f;
        pausado = true;
    }

    // Retomar la escala de tiempo
    void resumir()
    {
        if (!MovimientoPersonaje.finalPartida)
        {
            Time.timeScale = 1f;
            pausado = false;
        }
    }
}
