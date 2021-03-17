using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingController : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetString("CharacterUsed", "");
    }
}
