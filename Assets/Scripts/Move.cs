using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Move : MonoBehaviour
{

    //ACCESO AL CODIGO
    public static Move backdoor;

    public float speed;

    //ESTA VARIABLE GENERA UN NUMERO ALEATORIO QUE ELEGIRA UN DESTINO DE LA LISTA POSITIONS
    public int randy;

    //LINEA DE TRAYECTORIA
    public LineRenderer Line;

    //LISTA DE OBJETIVOS
    public List<Transform> Positions = new List<Transform>();



    public void Start()
    {
        randy = Random.Range(0, Positions.Count);

        //SE INICIALIZA EL SINGLETON
        if (backdoor != null)
        {

            return;
        }

        else
        {

            backdoor = this;
        }


    }

    void Update()
    {
        DestroyPlanes();

        //SELECCIONAMOS EL TRANSFORM DEL AVION Y LE ASIGNAMOS UN IMPULSO HACIA UN OBJETIVO DETERMINADO POR RANDY
        this.transform.position = Vector2.MoveTowards(transform.position,
        Positions[randy].position, speed * Time.deltaTime);

        LinePlane();

    }


    public void DestroyPlanes()
    {
        if (this.transform.position == Positions[randy].position)
        {
            Destroy(this.gameObject);
        }
    }

    public void LinePlane()
    {
        Line = GetComponent<LineRenderer>();


        Line.SetPosition(0, this.transform.position);
        Line.SetPosition(1, Positions[randy].position);
    }

}
