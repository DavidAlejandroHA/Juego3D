using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnerCirculos : MonoBehaviour
{
    static float temporizador = 1f;
    public GameObject esfera;
    Vector3 posInicial;
    float radio = 8f;
    // Start is called before the first frame update
    void Start()
    {
        temporizador = 0f;
        esfera.SetActive(false);
        //esfera.GetComponent<GameObject>().SetActive(false);
        //esfera.GetComponent<Rigidbody>().useGravity = false; // La esfera primordial se quedará quieta para poder seguir haciendo copias
        posInicial = esfera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        temporizador -= Time.deltaTime;
        if (temporizador <= 0)
        {
            //float radio = Random.value * 5;
            float centro = radio / 2;
            GameObject nuevaEsfera = Instantiate(esfera, posInicial - new Vector3(centro, 0f, centro) + new Vector3(Random.value * radio, 
                Random.value * radio, Random.value * radio), Quaternion.identity);
            nuevaEsfera.SetActive(true);
            temporizador = 1f;
        }
    }
}
