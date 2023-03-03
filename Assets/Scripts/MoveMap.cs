using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour
{

    public float speed;


    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-speed * Time.deltaTime,0,0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0, speed * Time.deltaTime, 0);
        }
   

;       if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0, -speed * Time.deltaTime, 0);
        }

    }
}
