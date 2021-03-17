using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestFinalController : MonoBehaviour
{
	public TMP_InputField q1, q2, q3;
	
	public void CheckSolution()
	{
		if (q1.text == GameManager.Instance.cntTorch.ToString() && q2.text == GameManager.Instance.cntBarrel.ToString() && q3.text == GameManager.Instance.cntShelf.ToString()) {
			PlayerPrefs.SetInt("QuestFinal", 1);
			Debug.Log("CORRECT");
			int iq = calculateIQ(SceneController.start);
			Debug.Log("IQ : " + iq);
			GameObject.Find("Scene Controller").GetComponent<SceneController>().ChangeToWinScene(iq);
		} else {
    		Debug.Log("INCORRECT");
		}
	}

	public int calculateIQ(float start)
    {
		float end = Time.realtimeSinceStartup;
		int time = Mathf.FloorToInt(end - start);
		if (time <= 15 * 60)
        {
			return 150;
        }
		else if (time <= 20 * 60)
        {
			return 140;
        }
		else if (time <= 25 * 60)
        {
			return 130;
        }
		else if (time <= 30 * 60)
		{
			return 120;
		}
		else if (time <= 35 * 60)
		{
			return 110;
		}
		else
        {
			return 100;
        }
	}
}
