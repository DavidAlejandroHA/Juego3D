using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;

public class IdiomaController : MonoBehaviour
{
    static int indice = 0;
    List<Locale> listaLocales = LocalizationSettings.AvailableLocales.Locales;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moverLocaleIzquierda()
    {
        Debug.Log(listaLocales);
        if (indice<=0)
        {
            indice = listaLocales.Count - 1;
        }
        else
        {
            indice--;
        }

        LocalizationSettings.SelectedLocale = listaLocales[indice];
    }

    public void moverLocaleDerecha()
    {
        if (indice >= listaLocales.Count)
        {
            indice = 0;
        }
        else
        {
            indice++;
        }

        LocalizationSettings.SelectedLocale = listaLocales[indice];
    }
}
