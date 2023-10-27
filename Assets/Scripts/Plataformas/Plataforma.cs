using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public float segundos = 2f;
    public Material materialPlataformaUsada;
    bool consumir = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "personaje")
        {
            consumir = true;
            GetComponent<MeshRenderer>().material = materialPlataformaUsada;
            consumirPlataforma();
            Destroy(this, segundos);
        }
    }

    void consumirPlataforma()
    {
        if (segundos >= 0)
        {
            segundos -= Time.deltaTime;
        } 
    }
}
