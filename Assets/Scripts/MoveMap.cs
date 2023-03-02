using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour
{





    //LA CAMARA NO PUEDE MOVERSE INDEPENDIENTEMENTE PORQUE ES EL PADRE DE TODOS LOS ELEMENTOS
    //LOS CONTROLES NO FUNCIONAN, DEBO REFERENCIAR AL TRANSFORM DE LA CAMARA
    //QUITAR LA SEGUNDA CAMARA DEL SEGUNDO CANVAS PARA PODER MOVERSE LIBREMENTE


    public float speed;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.Translate(-speed * Time.deltaTime,0,0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            this.transform.Translate(0, speed * Time.deltaTime, 0);
        }
   

;       if (Input.GetKeyDown(KeyCode.S))
        {
            this.transform.Translate(0, -speed * Time.deltaTime, 0);
        }

    }
}
