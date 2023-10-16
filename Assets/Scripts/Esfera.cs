using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esfera : MonoBehaviour
{
    public GameObject puntoGiro;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (puntoGiro != null)
        {
            transform.RotateAround(puntoGiro.transform.position, Vector3.up, 100 * Time.deltaTime);
        }
        else
        {
            Destroy(this);
        }
    }
}
