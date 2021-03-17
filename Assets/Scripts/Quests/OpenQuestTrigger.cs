using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenQuestTrigger : MonoBehaviour
{
	public GameObject Quest;
	public string name;

    void Update()
    {
    	if (PlayerPrefs.GetInt(name) == 0) {
    		if (Input.GetMouseButtonDown (0)) {
				RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
				if (hit.collider != null && hit.collider.tag == "Quest") 
				{
					Debug.Log("Open Quest " + hit.collider.name);
					Quest.SetActive(true);
				}
			}
    	} 
    }
}
