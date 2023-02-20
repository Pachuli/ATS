using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTest : MonoBehaviour
{
    public LineRenderer myLine;

    public Vector3 startPos, endPos;

    public Transform inicio, final;
    // Start is called before the first frame update
    void Start()
    {
        startPos = inicio.position;
        endPos = final.position;

        myLine = GetComponent<LineRenderer>();
        myLine.SetPosition(0, startPos);
        myLine.SetPosition(1, endPos);
    }

}
