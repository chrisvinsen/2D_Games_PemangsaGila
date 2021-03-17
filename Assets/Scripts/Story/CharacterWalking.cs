using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWalking : MonoBehaviour
{
	Vector3 targetPos1, targetPos2;
    Animator animator;
   	bool arrivedPos1, arrivedPos2;

    void Start()
    {
    	animator = this.gameObject.GetComponent<Animator>();
    	arrivedPos1 = false;
    	arrivedPos2 = false;
    	targetPos1 = new Vector3(7f,-12.27f,-8.57f);
    	targetPos2 = new Vector3(-7f, -12.27f, -8.57f);
    }

    void Update()
    {
    	if (!arrivedPos1 && !arrivedPos2) {
	    	if (transform.position == targetPos1) {
		        animator.SetBool("isWalking", false);
		        arrivedPos1 = true;
		        PlayerPrefs.SetInt("Story_1", 1);
		        this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
	    	} else {
		        animator.SetBool("isWalking", true);
	        	transform.position = Vector3.MoveTowards(transform.position, targetPos1, .05f);
	    	}
    	}

    	if (arrivedPos1 && !arrivedPos2) {
    		if (transform.position == targetPos2) {
		        animator.SetBool("isWalking", false);
		        arrivedPos2 = true;
			} else {
		        animator.SetBool("isWalking", true);
	        	transform.position = Vector3.MoveTowards(transform.position, targetPos2, .075f);
			}
    	}
    }

    private IEnumerator wait(float time) {
		yield return new WaitForSeconds(time);
    }
}
