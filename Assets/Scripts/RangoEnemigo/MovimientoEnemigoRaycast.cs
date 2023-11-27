using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigoRaycast : MonoBehaviour
{
    public int radio;
    public float velocidad = 3f;
    public GameObject target;
    public string plaveholdef;
    bool seEncuentraConMuro = false;
    float timer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Esta lista almacenar� el resultado de llamar a OverlapSphere
        Collider[] listaChoques;

        /* TODO 1: LLamar al m�todo OverlapShpere */
        int mascara = 1 << 9;
        listaChoques = Physics.OverlapSphere(transform.position, radio, mascara);

        if (listaChoques.Length > 0)
        {
            float step = velocidad * Time.deltaTime; // calcula la distancia a moverse

            RaycastHit choqueParedes;

            if (Physics.Raycast(transform.position, transform.forward,
                out choqueParedes, 1f))
            {
                if (choqueParedes.collider.gameObject != target)
                {
                    // opposite: hit.point + hit.normal * collider.size
                    seEncuentraConMuro = true;
                    //transform.RotateAround(transform.position, Vector3.right, 2f);
                    Debug.Log("a");
                    transform.Rotate(Vector3.right, 15);
                    Invoke("cambiarSeEncuentraConMuro", 0.25f); // ejecuta una funci�n con retraso, hacerlo para cambiar seEncuentraConMuro y rotar si hay un muro

                    //transform.RotateAround(transform.position, Vector3.forward, 45f);
                }
                else
                {

                }
            }

            if (!seEncuentraConMuro)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
                transform.LookAt(target.transform.position, Vector3.left);
            } else
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position +
                    new Vector3(0f, 1f, 0f), step);
            }
            
            

            
        }

        
        //int mascaraParedes = 1 << 10;
        //listaChoques = Physics.RaycastAll

    }
    void cambiarSeEncuentraConMuro()
    {
        seEncuentraConMuro = false;
        //Debug.Log("Hola!");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(255, 192, 203); // Color rosa
        Gizmos.DrawWireSphere(transform.position, radio);
        Gizmos.DrawRay(transform.position, transform.forward);
    }
}
