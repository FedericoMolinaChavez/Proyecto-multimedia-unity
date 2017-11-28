using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class poder1 : MonoBehaviour
{
    public Rigidbody rocketPrefab;
    public float coolDown = 0f;
    void Update ()
    {
        // Lanzamiento Proyectil
        if(Input.GetButtonDown("Fire1") && coolDown <= 0 && this.name == "poder1")
        {
            this.GetComponent<MeshRenderer>().enabled = true;
            Rigidbody rocketInstance;
            rocketInstance = Instantiate(rocketPrefab, transform.position, transform.rotation) as Rigidbody;
            rocketInstance.AddForce(transform.forward * 500);
            coolDown = 5f;
            Destroy(rocketInstance,4f);
            this.GetComponent<MeshRenderer>().enabled = false;
        }
        // Lanzamiento Proyectil

        //Tiempo de espera para lanzar de nuevo
        if(coolDown >= 0){coolDown -= Time.deltaTime;}
        //Tiempo de espera para lanzar de nuevo

        //Destrye proyectil lanzado
        Destroy(GameObject.Find("poder1(Clone)"),4f);
        //Destrye proyectil lanzado
    }

    //Collider con Poryectil
    void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.name == "Lumberjack3"){
            GameObject.Find("player2").GetComponent<FPC>().slowed = 3f;
        }
        if(col.gameObject.name != "poder1" && col.gameObject.name != "poder1(Clone)" && col.gameObject.name != "FreeCharacter_model"){Destroy(GameObject.Find("poder1(Clone)"));} 
    }    
    //Collider con Poryectil
}