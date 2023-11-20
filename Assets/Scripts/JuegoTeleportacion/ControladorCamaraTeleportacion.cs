using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamaraTeleportacion : MonoBehaviour
{
    public GameObject personajeGameObj;
    public float offsetZ, offsetY;
    bool primeraPersona = false;
    float sensibilidad = 2f;
    float rotacionCamaraVertical = 0f;
    float rotacionCamaraHorizontal = 0f;
    bool resetCamara = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            primeraPersona = !primeraPersona;
            resetCamara = true;
        }

        transform.position = new Vector3(personajeGameObj.transform.position.x,
            personajeGameObj.transform.position.y - (primeraPersona ? 0 : offsetY),
            personajeGameObj.transform.position.z - (primeraPersona ? 0 : offsetZ));

        // Recolección de los movimientos del ratón
        float inputX = Input.GetAxis("Mouse X") * sensibilidad;
        float inputY = Input.GetAxis("Mouse Y") * sensibilidad;

        // Si se está en primera persona se trabaja las rotaciones de la cámara
        if (primeraPersona)
        {
            // Rota la cámara al rededor del eje Y
            rotacionCamaraVertical -= inputY;
            rotacionCamaraHorizontal -= inputX;
            rotacionCamaraVertical = Mathf.Clamp(rotacionCamaraVertical, -90f, 90f);
            transform.localEulerAngles = new Vector3(rotacionCamaraVertical, -rotacionCamaraHorizontal, 0.0f);
        }
        else
        {
            if (resetCamara)
            {
                resetCamara = !resetCamara;
                transform.localEulerAngles = Vector3.right * 0 + Vector3.down * 0;
            }
        }
    }
}
