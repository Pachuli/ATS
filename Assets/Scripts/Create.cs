using System.Collections;
using System.Collections.Generic;
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
    private Vector2 BornPosition;

    //VARIABLE PARA EMPARENTAR LOS AVIONES QUE SE CREAN
    public Transform padre;

    //CONTROLADOR PARA INSTANCIAR EN UN TIEMPO DETERMINADO
    public bool CanSpawn = true;

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
    void CreateAndGo()
    {

        //DENTRO DE UN VECTOR 2 GUARDAMOS LOS LIMITES DE LA PANTALLA
        BornPosition = new Vector2(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY));

        //SE GENERA UN OBJETO DENTRO DE LA PANTALLA
        Instantiate(planes, BornPosition, Quaternion.identity, padre);

    }


    //A TRAVES DE UN BOOLEANO Y UN DETERMINADO TIEMPO LLAMAREMOS AL METODO DE CREACION DE AVIONES
        IEnumerator SpawnManager(float time)
        {
            CreateAndGo();
            
            CanSpawn = false;

            yield return new WaitForSeconds(time);

            CanSpawn = true;
        }
    }

