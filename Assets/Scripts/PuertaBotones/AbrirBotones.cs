using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirBotones : MonoBehaviour
{
    int mascara = 1 << 8;
    public Material material;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AbrirBoton();
    }

    void AbrirBoton()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit golpeRayo;

            if (Physics.Raycast(rayo, out golpeRayo, 100000f, mascara))
            {
                
                if (MovimientoEsferaDefinitivo.numBotones >= 0)
                {
                    //Destroy(golpeRayo.collider.gameObject);
                    //Debug.Log(MovimientoEsferaDefinitivo.numBotones);
                    golpeRayo.collider.gameObject.GetComponent<Renderer>().material = material;
                    MovimientoEsferaDefinitivo.numBotones--;
                    //Debug.Log(MovimientoEsferaDefinitivo.numBotones);
                }
            }
        }
    }
}
