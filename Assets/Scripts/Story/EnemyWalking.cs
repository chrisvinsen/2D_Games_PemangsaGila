using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalking : MonoBehaviour
{
	Vector3 targetPos;
    Animator animator;

    void Start()
    {
    	animator = this.gameObject.GetComponent<Animator>();
    	targetPos = new Vector3(-5f,-11.9f,-8.1f);
    }

    void Update()
    {
    	if (PlayerPrefs.GetInt("Story_1") == 1) {
	    	if (transform.position == targetPos) {
		        animator.SetBool("isWalking", false);
		        PlayerPrefs.SetInt("Story_2", 1);
	    	} else {
		        animator.SetBool("isWalking", true);
	        	transform.position = Vector3.MoveTowards(transform.position, targetPos, .1f);
		        PlayerPrefs.SetInt("Story_2", 0);
	    	}
    	}
    }
}
