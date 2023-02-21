using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;

public class Move : MonoBehaviour
{
    //ACCESO AL CODIGO
    public static Move backdoor;

    public float speed;

    //ESTA VARIABLE GENERA UN NUMERO ALEATORIO QUE ELEGIRA UN DESTINO DE LA LISTA POSITIONS
    int randy;

    //LISTA DE OBJETIVOS
    public List<Transform> Positions = new List<Transform>();

    public void Start()
    {
        randy = Random.Range(0,Positions.Count);     
    }

    void Update()
    {
        DestroyPlanes();

        //SELECCIONAMOS EL TRANSFORM DEL AVION Y LE ASIGNAMOS UN IMPULSO HACIA UN OBJETIVO DETERMINADO POR RANDY
        this.transform.position = Vector2.MoveTowards(transform.position,
            Positions[randy].position,speed * Time.deltaTime);  
        
    }


    public void DestroyPlanes()
    {
        if (this.transform.position == Positions[randy].position)
        {
           Destroy(this.gameObject);
        }
    }
        
        


}
