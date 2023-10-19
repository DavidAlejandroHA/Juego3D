using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonedasTexto : MonoBehaviour
{

    //[SerializeField]
    //public static TMP_Text texto;

    public static TextMeshProUGUI objetoTexto;
    // Start is called before the first frame update
    void Start()
    {
        objetoTexto = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //objetoTexto.text = "CAMBIO";
    }
}
