using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class poder2 : MonoBehaviour
{
    public Rigidbody rocketPrefab;
    public float coolDown = 0f;
    void Update ()
    {
        // Lanzamiento Proyectil
        if(Input.GetButtonDown("Fire1") && coolDown <= 0 && this.name == "poder2")
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
        Destroy(GameObject.Find("poder2(Clone)"),4f);
        //Destrye proyectil lanzado
    }

    //Collider con Poryectil
    void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.name == "FreeCharacter_model"){
            GameObject.Find("player1").GetComponent<FPS>().slowed = 3f;
        }
        if(col.gameObject.name != "poder2" && col.gameObject.name != "poder2(Clone)" && col.gameObject.name != "Lumberjack3"){Destroy(GameObject.Find("poder2(Clone)"));} 
    }    
    //Collider con Poryectil
}