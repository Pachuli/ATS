using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class Create : MonoBehaviour
{

    //ACCESO
    public static Create backdoor;

    //OBJETO QUE SE INSTANCIARA
    public GameObject planes;

    //LIMITES PANTALLA
    private float MinX, MaxX, MinY, MaxY;

    //VARIABLE PARA CREAR UNA POSICION ALEATORIA AL INICIO
    public Vector3 BornPos;

    //VARIABLE PARA EMPARENTAR LOS AVIONES QUE SE CREAN
    public Transform padre;

    //CONTROLADOR PARA INSTANCIAR EN UN TIEMPO DETERMINADO
    public bool CanSpawn = true;

    public LineRenderer Line;


    void Start()
    {
        //CALCULAMOS LA PANTALLA
        ScreenSize();
    }

    private void Update()
    {
        if (CanSpawn)
        {
            StartCoroutine(SpawnManager(2f));
        }

        if (Line == null)
        {
            Debug.Log("ERROR");
        }
    }

    //ESTE METODO CALCULA EL TAMANO DE LA PANTALLA Y LO GUARDA EN VARIABLES INDEPENDIENTES
    void ScreenSize()
    {
        Vector2 Size = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        MinX = -Size.x;
        MaxX = Size.x;
        MinY = -Size.y;
        MaxY = Size.y;
    }

    //METODO PARA INSTANCIAR UN OBJETO EN CUALQUIER LUGAR DE LA PANTALLA
    void Spawn()
    {

        //DENTRO DE BornPosition GUARDAMOS UN POSICION ALEATORIA DENTRO DE LOS LIMITES DE LA PANTALLA
        BornPos = new Vector2(UnityEngine.Random.Range(MinX, MaxX), UnityEngine.Random.Range(MinY, MaxY));

        //SE GENERA UN OBJETO DENTRO DE LA PANTALLA
        Instantiate(planes, BornPos, Quaternion.identity, padre);

        Line = GetComponent<LineRenderer>();

        Line.SetPosition(0, BornPos);
        Line.SetPosition(1, Move.backdoor.Positions[Move.backdoor.randy].position);

    }


    //A TRAVES DE UN BOOLEANO Y UN DETERMINADO TIEMPO LLAMAREMOS AL METODO DE CREACION DE AVIONES
    IEnumerator SpawnManager(float time)
    {
        Spawn();

        CanSpawn = false;

        yield return new WaitForSeconds(time);

        CanSpawn = true;
    }
}

