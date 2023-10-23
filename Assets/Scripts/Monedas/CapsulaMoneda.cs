using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsulaMoneda : MonoBehaviour
{
    public GameObject capsulaMoneda;
    //public ParticleSystem particulas;
    public Material materialMonedaUsada;
    bool monedaRecogida = false;
    public static int monedas = 0;
    
    //GameObject capsula;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void Play()
    //{
    //capsulaMoneda = Instantiate(capsulaMoneda, capsulaMoneda.transform.position, Quaternion.identity);
    //capsulaMoneda.GetComponent<ParticleSystem>().Play();
    //}

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "personaje")
        {
            //Destroy(collider.gameObject);
            //Debug.Log("A");
            //collider.gameObject.GetComponent<ParticleSystem>().Play();
            if (!monedaRecogida)
            {
                monedas++;
                MonedasTexto.objetoTexto.text = MovimientoPersonaje.monedasTextoAux + monedas;
                monedaRecogida = true;
                GetComponent<MeshRenderer>().material = materialMonedaUsada;
                transform.GetChild(1).GetComponent<ParticleSystem>().Play();
            }
        }
    }
}
