using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hitted : MonoBehaviour
{
    public Camera playerCam;
    public void Start()
    {
        if(GameManager.Instance.reset == false)
        {
            this.gameObject.transform.position = GameManager.Instance.currentPos;
            playerCam.orthographicSize = GameManager.Instance.cameraRange;
        }
    }
    public void GotHitted()
    {
    	StartCoroutine(GoToLoseScene());
    }

    private IEnumerator GoToLoseScene() {

        GameManager.Instance.currentPos = this.gameObject.transform.position;
        GameManager.Instance.cameraRange = PlayerPrefs.GetFloat("Camera");

		yield return new WaitForSeconds(.1f);
		SceneManager.LoadScene("LoseScene");
    }
}
