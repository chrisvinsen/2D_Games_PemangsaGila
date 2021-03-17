using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest3Trigger : MonoBehaviour
{
    public GameObject Quest;

    void Awake() {
        if(GameManager.Instance.reset == true)
        {
            PlayerPrefs.SetInt("Quest3", 0);
        }
    }

    void Update()
    {
    	if (PlayerPrefs.GetInt("Quest3") == 0) {
    		if (Input.GetMouseButtonDown (0)) {
				RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
				if (hit.collider != null && hit.collider.name == "Quest3") 
				{
					Quest.SetActive(true);
				}
			}
    	} else if (PlayerPrefs.GetInt("Quest3") == 1) {
    		this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    	}
    }
}
