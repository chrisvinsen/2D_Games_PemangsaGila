using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest2Trigger : MonoBehaviour
{
    public GameObject Quest;

    void Awake() {
        if(GameManager.Instance.reset == true)
        {
            PlayerPrefs.SetInt("Quest2", 0);
        }
    }

    void Update()
    {
    	if (PlayerPrefs.GetInt("Quest2") == 0) {
    		if (Input.GetMouseButtonDown (0)) {
				RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
				if (hit.collider != null && hit.collider.name == "Quest2") 
				{
					Quest.SetActive(true);
				}
			}
    	} else if (PlayerPrefs.GetInt("Quest2") == 1) {
    		this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    	}
    }
}
