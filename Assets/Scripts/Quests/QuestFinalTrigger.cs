using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestFinalTrigger : MonoBehaviour
{
    public GameObject Quest;

    void Awake() {
        PlayerPrefs.SetInt("QuestFinal", 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(-10.3f, -4.9f, 0f);
            if (PlayerPrefs.GetInt("QuestFinal") == 0)
            {
                Quest.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("QuestFinal") == 1)
            {
                this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
