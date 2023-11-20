using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorBoton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void boton()
    {
        Debug.Log("me pulsaste");
    }

    public void SiONo(bool nuevoEstado)
    {
        Debug.Log("El nuevo estado es " + nuevoEstado);
    }
}
