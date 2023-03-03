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

    // VARIABLES PARA CALCULAR LOS LIMITES DEL MAPA

    public Vector3 center;

    public Vector3 Size;


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


        center = this.transform.position;
        Size = this.transform.localScale;


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

        Vector3 ScanMap = center + new Vector3
                                        (Random.Range(-Size.x / 2, Size.x / 2), Random.Range(-Size.y / 2, Size.y / 2), Random.Range(-Size.z / 2, Size.z));
        
        //SE GENERA UN OBJETO DENTRO DE LA PANTALLA
        
        Instantiate(planes,ScanMap, Quaternion.identity, padre);

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

