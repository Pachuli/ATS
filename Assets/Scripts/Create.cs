using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class Create : MonoBehaviour
{

    //ACCESO A TRAVES DE UN SINGLETON
    public static Create backdoor;

    //OBJETO QUE SE INSTANCIARA
    public GameObject planes;

    //VARIABLE PARA METER LOS GAMEOBJECTS A UN EMPTY
    public Transform padre;

    //CONTROLADOR PARA INSTANCIAR EN UN TIEMPO DETERMINADO
    public bool CanSpawn = true;

    //CONTADOR DE AVIONES SPAWNEADOS
    public int PlanesCount;


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


    }

    private void Update()
    {
        if (CanSpawn)
        {
            StartCoroutine(SpawnManager(2f));
        }

    }

    //METODO PARA INSTANCIAR UN OBJETO EN CUALQUIER LUGAR DE LA PANTALLA
    void Spawn()
    {

        //Vector3 ScanMap = center + new Vector3
        //(Random.Range(-50 / 2, 50 / 2), Random.Range(-50 / 2,50 / 2), 0);

        //SE GENERA UN OBJETO DENTRO DE LA PANTALLA
        //Instantiate(planes,ScanMap, Quaternion.identity, padre);

        Vector3 randomPosition = new Vector3(Random.Range(3900, 4200), (Random.Range(-150, 150)),0);

        Instantiate(planes, randomPosition, Quaternion.identity, padre);

        PlanesCount++;


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

