using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseCharacterController : MonoBehaviour
{
	private string characterChosen = "";
	public GameObject characterMale, characterFemale, playButton;
	private Vector3 scaleNormal, scaleZoom;

	void Awake()
	{
		scaleNormal = new Vector3(0.125f, 0.125f, 0.125f);
		scaleZoom = new Vector3(0.15f, 0.15f, 0.15f);
	}

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

			if (hit.collider != null && hit.collider.tag == "Clickable") 
			{
				if (characterChosen != hit.collider.name) {
    				AudioSFXController.SFXInstance.Audio.PlayOneShot(AudioSFXController.SFXInstance.Click);
					if (hit.collider.name == "MaleCharacter") {
						characterMale.transform.Rotate(new Vector3(0, 0, -12));
						characterMale.transform.localScale = scaleZoom;

						characterFemale.transform.rotation = Quaternion.identity;
						characterFemale.transform.localScale = scaleNormal;

						PlayerPrefs.SetString("CharacterUsed", "Male");
					} else if (hit.collider.name == "FemaleCharacter") {
						characterFemale.transform.Rotate(new Vector3(0, 0, 9));
						characterFemale.transform.localScale = scaleZoom;

						characterMale.transform.rotation = Quaternion.identity;
						characterMale.transform.localScale = scaleNormal;

						PlayerPrefs.SetString("CharacterUsed", "Female");
					}
				}
				characterChosen = hit.collider.name;
			}
		}

		if (characterChosen != "") {
			playButton.SetActive(true);
		} else {
			playButton.SetActive(false);
		}
	}
}
