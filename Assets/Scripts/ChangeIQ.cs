using UnityEngine;
using TMPro;

public class ChangeIQ : MonoBehaviour
{
	void Awake()
	{
        GameObject.Find("Text - Score").GetComponent<TextMeshProUGUI>().text = SceneController.playerIQ.ToString();
    }
}
