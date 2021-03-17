using UnityEngine;

public class Player : MonoBehaviour
{
	void Awake()
	{
		//GameObject player = /*GameObject.Find("Player")*/;
		//GameObject.Find("Player").GetComponent<Transform>().position = new Vector2(-8.085f, -4.558f);
	}

	void Update()
	{
		movement();
	}

	private void movement()
	{
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			this.transform.Translate(new Vector2(0, 0.16f));
		}
		else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
		{
			this.transform.Translate(new Vector2(0, -0.16f));
		}
		else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
		{
			this.transform.Translate(new Vector2(-0.16f, 0));
			GetComponent<Rigidbody2D>().velocity = new Vector3(-2, 0, 0);
		}
		else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
		{
			this.transform.Translate(new Vector2(0.16f, 0));
		}
	}
}
