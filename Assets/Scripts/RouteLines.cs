using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteLines : MonoBehaviour
{
    public LineRenderer Ruta;

    public Transform startPos;

    public Transform endPos;

    private void Start()
    {
        Ruta = GetComponent<LineRenderer>();

        Ruta.positionCount = 2;

    }

    private void Update()
    {
        Ruta.SetPosition(0,startPos.position);
        Ruta.SetPosition(0,endPos.position);
    }

}
