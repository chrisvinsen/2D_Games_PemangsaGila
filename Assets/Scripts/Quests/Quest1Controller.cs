using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest1Controller : MonoBehaviour
{
    public TMP_InputField hours, minutes;
    public Camera[] playerCamera;

    public void CheckSolution()
    {
        if (hours.text == DateTime.Now.ToString("HH") && minutes.text == DateTime.Now.ToString("mm"))
        {
            this.gameObject.SetActive(false);
            PlayerPrefs.SetInt("Quest1", 1);
            if (PlayerPrefs.GetString("CharacterUsed") == "Male")
            {
                if(PlayerPrefs.GetInt("Quest2") != 1 || PlayerPrefs.GetInt("Quest3") != 1)
                {
                    playerCamera[0].orthographicSize = 0.5f;
                    PlayerPrefs.SetFloat("Camera", 0.5f);
                }
                
            }
            else if (PlayerPrefs.GetString("CharacterUsed") == "Female")
            {
                if (PlayerPrefs.GetInt("Quest2") != 1 || PlayerPrefs.GetInt("Quest3") != 1)
                {
                    playerCamera[1].orthographicSize = 0.5f;
                    PlayerPrefs.SetFloat("Camera", 0.5f);
                }
            }
            Debug.Log("CORRECT");
        }
        else
        {
            Debug.Log("INCORRECT");
        }
    }
}