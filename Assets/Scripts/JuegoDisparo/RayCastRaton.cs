using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastRaton : MonoBehaviour
{
    int mascara = 1 << 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LanzarRayoCamara();
    }

    void LanzarRayoCamara()
    {
        if (Input.GetMouseButton(0))
        {
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit golpeRayo;

            if (Physics.Raycast(rayo, out golpeRayo, 100000f, mascara))
            {
                Destroy(golpeRayo.collider.gameObject);
            }
        }
    }
}
