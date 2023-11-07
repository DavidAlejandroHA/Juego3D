using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public float segundos = 2f;
    public Material materialPlataformaUsada;
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
            GetComponent<MeshRenderer>().material = materialPlataformaUsada;
            LeanTween.scale(this.gameObject, new Vector3(0f, 0f, 0f), 0.5f).setEaseOutBounce().setDelay(segundos).setDestroyOnComplete(true);
            //Destroy(this.gameObject, segundos);
        }
    }
}
