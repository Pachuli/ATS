using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{

    public GameObject Ray;


    [SerializeField] private float DistanceTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Ray.transform.position, Ray.transform.forward, out hit))
        {

            if(hit.collider != null)
            {
                transform.localScale = new Vector3(1f, 1f, DistanceTarget);
            }

            DistanceTarget = hit.distance;
        }
    }
}
