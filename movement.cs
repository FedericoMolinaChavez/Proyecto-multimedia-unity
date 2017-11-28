using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        bool isIDLE = !(Input.GetKey(KeyCode.W)) && !(Input.GetKey(KeyCode.A)) && !(Input.GetKey(KeyCode.S)) && !(Input.GetKey(KeyCode.D)) && !(Input.GetKey(KeyCode.Space));

        if (isIDLE)
            animator.SetTrigger("Idle");
        else
            animator.SetTrigger("Walk");
	}
}
