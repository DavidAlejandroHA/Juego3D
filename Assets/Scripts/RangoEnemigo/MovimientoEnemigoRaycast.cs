using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigoRaycast : MonoBehaviour
{
    public int radio;
    public float velocidad = 3f;
    public GameObject target;
    public string plaveholdef; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Esta lista almacenará el resultado de llamar a OverlapSphere
        Collider[] listaChoques;

        /* TODO 1: LLamar al método OverlapShpere */
        int mascara = 1 << 9;
        listaChoques = Physics.OverlapSphere(transform.position, radio, mascara);

        if (listaChoques.Length > 0)
        {
            float step = velocidad * Time.deltaTime; // calcula la distancia a moverse
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
            transform.LookAt(target.transform.position, Vector3.left);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(255, 192, 203); // Color rosa
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
