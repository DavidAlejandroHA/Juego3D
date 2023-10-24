using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamara : MonoBehaviour
{
    //public GameObject cubo;
    public Transform personaje;
    public float offsetZ, offsetY;
    float auxoffsetZ, auxoffsetY;
    bool primeraPersona = false;
    float sensibilidad = 2f;
    float rotacionCamaraVertical = 0f;
    float rotacionCamaraHorizontal = 0f;
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

        //transform.position = new Vector3(cubo.transform.position.x,
        //cubo.transform.position.y - (primeraPersona ? 0 : offsetY),
        //cubo.transform.position.z - (primeraPersona ? 0 : offsetZ));


        // 


        transform.position = new Vector3(cubo.transform.position.x,
            cubo.transform.position.y - (primeraPersona ? 0 : offsetY),
            cubo.transform.position.z - (primeraPersona ? 0 : offsetZ));

        // Si se está en primera persona se trabaja las rotaciones de la cámara
        if (primeraPersona)
        {

            // Recolección de los movimientos del ratón
            float inputX = Input.GetAxis("Mouse X") * sensibilidad;
            float inputY = Input.GetAxis("Mouse Y") * sensibilidad;

            // Rota la cámara al rededor del eje Y
            rotacionCamaraVertical -= inputY;
            rotacionCamaraHorizontal -= inputX;
            rotacionCamaraVertical = Mathf.Clamp(rotacionCamaraVertical, -90f, 90f);
            transform.localEulerAngles = (Vector3.right * rotacionCamaraVertical) + (Vector3.down * rotacionCamaraHorizontal);


            //rotacionCamaraVertical = 0f;
            //rotacionCamaraHorizontal = 0f;
            // Rota la cámara al rededor del eje X
            personaje.Rotate(Vector3.right * inputX);
        } else
        {
            
        }
    }
}
