using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextoGanar : MonoBehaviour
{
    public static TextMeshProUGUI objetoTexto;
    // Start is called before the first frame update
    void Start()
    {
        
        objetoTexto = GetComponent<TextMeshProUGUI>();
        //Debug.Log(objetoTexto.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
