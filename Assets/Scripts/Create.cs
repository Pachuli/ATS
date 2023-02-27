using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class Create : MonoBehaviour
{

    //ACCESO A TRAVES DE UN SINGLETON
    public static Create backdoor;

    //OBJETO QUE SE INSTANCIARA
    public GameObject planes;

    //LIMITES PANTALLA
    private float MinX, MaxX, MinY, MaxY;

    //VARIABLE PARA CREAR UNA POSICION ALEATORIA AL INICIO
    public Vector3 BornPos;

    //VARIABLE PARA METER LOS GAMEOBJECTS A UN EMPTY
    public Transform padre;

    //CONTROLADOR PARA INSTANCIAR EN UN TIEMPO DETERMINADO
    public bool CanSpawn = true;

    public Transform AirSpace;

    public Vector3 center;


    void Start()
    {
        //SE INICIALIZA EL SINGLETON
        if (backdoor != null)
        {

            return;
        }

        else
        {

            backdoor = this;
        }

        //CALCULAMOS LA PANTALLA
        ScreenSize();

    }

    private void Update()
    {
        if (CanSpawn)
        {
            StartCoroutine(SpawnManager(2f));
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

        Vector3 SpacePosition = center + new Vector3(Random.Range(MinX / 2, MaxX / 2), Random.Range(MinY / 2, MaxY / 2),1);
    }

    //METODO PARA INSTANCIAR UN OBJETO EN CUALQUIER LUGAR DE LA PANTALLA
    void Spawn()
    {

        //DENTRO DE BornPosition GUARDAMOS UN POSICION ALEATORIA DENTRO DE LOS LIMITES DE LA PANTALLA
        BornPos = new Vector3(UnityEngine.Random.Range(MinX, MaxX), UnityEngine.Random.Range(MinY, MaxY), 10);

        //SE GENERA UN OBJETO DENTRO DE LA PANTALLA
        Instantiate(planes, BornPos, Quaternion.identity, padre);

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

