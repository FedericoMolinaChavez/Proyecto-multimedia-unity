using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager2 : MonoBehaviour {

	public float timeLeft = 10.0f;
	public Text text;
	public bool countOver = false;
	public bool encontrado = false;
	public float tiempoLetretroEncontrado = 2f;

	// Use this for initialization
	void Awake () {
		Time.timeScale = 1;
		//GameObject.Find("player2").GetComponent<FPC>().enabled = true;
		//GameObject.Find("player1").GetComponent<FPS>().enabled = false;
	}
	
	//---------------------------------------------------------------Collider Camera Jugador
	void checkCameraCollider(){
        RaycastHit hit;
		GameObject.Find("Lumberjack3").layer = 0;
		Vector3 Chaser = GameObject.Find("FirstPersonCharacter").transform.position;
		Vector3 Hidden = GameObject.Find("Lumberjack3").transform.position;
		Vector3 forward = GameObject.Find("FirstPersonCharacter").transform.forward;
		Vector3 Direction = Hidden - Chaser;
		Direction[1] = 0;
		if(Physics.Raycast(Chaser,Direction,out hit) && Vector3.Angle(Direction,forward) < 55f * 0.5f){
			if(hit.collider.gameObject.name == "Lumberjack3"){
				encontrado = true;
			}
		}
	}
	//---------------------------------------------------------------Collider Camera Jugador

	// Update is called once per frame
	void Update () {
		//---------------------------------------------------------------Conteo		
	  	if(countOver == false){	
	  		Mathf.Round(timeLeft);
	        //text.text = "Time Left:" + Mathf.Round(timeLeft);
	        if(timeLeft < 0)
	        {
	            GameObject.Find("player1").GetComponent<FPS2>().enabled = true;	//Habilitar control 
	            countOver = true;          
	        }else{
	        	timeLeft -= Time.deltaTime;
	        }
	    }else{
	    	checkCameraCollider();	
	    }
        //---------------------------------------------------------------Conteo

        //pausaJuego
	    if(Input.GetButtonDown("pause")){
			if(Time.timeScale == 1){
				GameObject.Find("pause").GetComponent<Canvas>().enabled = true;
				Time.timeScale = 0;
			}else{
				GameObject.Find("pause").GetComponent<Canvas>().enabled = false;
				Time.timeScale = 1;
			}
	    }
        //pausaJuego

	    //Letrero encontrado
	    if(encontrado == true){
	    	GameObject.Find("Encontrado").GetComponent<Canvas>().enabled = true;
	    	if(tiempoLetretroEncontrado > 0){
	    		tiempoLetretroEncontrado -= Time.deltaTime;
	    	}else{
	    		GameObject.Find("Encontrado").GetComponent<Canvas>().enabled = false;
	    	}
	    }
	    //Letrero encontrado

	}

	//-------------------------------------------------------------------Tocar el Tacho
	void OnTriggerEnter (Collider col)
    {
        if(countOver == true && col.gameObject.name == "Lumberjack3")
        {
        	//Time.timeScale = 0;
        	GameObject.Find("winText").GetComponent<Text>().text = "Ganador: Jugador 2";
        	GameObject.Find("Ganador").GetComponent<Canvas>().enabled = true;
        }else if(countOver == true && encontrado == true && col.gameObject.name == "FreeCharacter_model"){
        	//Time.timeScale = 0;
        	GameObject.Find("winText").GetComponent<Text>().text = "Ganador: Jugador 1";
        	GameObject.Find("Ganador").GetComponent<Canvas>().enabled = true;
        }
    }
    //-------------------------------------------------------------------Tocar el Tacho
}
