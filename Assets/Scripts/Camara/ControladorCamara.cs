using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamara : MonoBehaviour
{
    public GameObject cubo;
    public float offsetZ, offsetY;
    float auxoffsetZ, auxoffsetY;
    bool primeraPersona = false;
    // Start is called before the first frame update
    void Start()
    {
        auxoffsetZ = offsetZ;
        auxoffsetY = offsetY;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            primeraPersona = !primeraPersona;
        }

        transform.position = new Vector3(cubo.transform.position.x, 
            cubo.transform.position.y - (primeraPersona ? 0 : offsetY), 
            cubo.transform.position.z - (primeraPersona ? 0 : offsetZ));

        
    }
}
