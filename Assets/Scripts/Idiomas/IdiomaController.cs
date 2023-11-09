using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;using UnityEngine.Localization;
using UnityEngine.UI;

public class IdiomaController : MonoBehaviour
{
    static int indice = 0;
    List<Locale> listaLocales;

    public GameObject espanolboton;
    public GameObject francesboton;
    public GameObject inglesboton;

    static Color colorFondoBoton = new Color(97, 139, 236, 255);
    static Color colorSeleccionadoBoton = new Color(236, 183, 97, 255);

    // Start is called before the first frame update
    void Start()
    {
        listaLocales = LocalizationSettings.AvailableLocales.Locales;
        //Debug.Log(listaLocales.IndexOf(LocalizationSettings.Instance.GetSelectedLocale()));
        indice = listaLocales.IndexOf(LocalizationSettings.Instance.GetSelectedLocale());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moverLocaleIzquierda()
    {
        indice--;
        if (indice < 0)
        {
            indice = listaLocales.Count - 1;
        }
        Debug.Log(indice);
        cambiarColorBoton(indice);

        // Establece el idioma
        LocalizationSettings.Instance.SetSelectedLocale(listaLocales[indice]);
    }

    public void moverLocaleDerecha()
    {
        indice++;
        
        if (indice >= listaLocales.Count)
        {
            indice = 0;
        }
        Debug.Log(indice);
        cambiarColorBoton(indice);

        // Establece el idioma
        LocalizationSettings.Instance.SetSelectedLocale(listaLocales[indice]);
    }

    public void cambiarColorBoton(int indice)
    {
        francesboton.GetComponent<Image>().color = colorFondoBoton;
        espanolboton.GetComponent<Image>().color = colorFondoBoton;
        inglesboton.GetComponent<Image>().color = colorFondoBoton;

        if (indice == 0)
        {
            inglesboton.GetComponent<Image>().color = colorFondoBoton;
        }
        /*else
        {
            inglesboton.GetComponent<Image>().color = colorFondoBoton;
        }*/

        if (indice == 1)
        {
            //francesboton.GetComponent<Image>().color = colorFondoBoton;
        }

        if (indice == 2)
        {
            espanolboton.GetComponent<Image>().color = colorFondoBoton;
        }
    }
}
