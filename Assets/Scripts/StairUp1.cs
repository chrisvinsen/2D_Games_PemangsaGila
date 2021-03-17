using UnityEngine;

public class StairUp1 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(-0.1f, -9.1f, 0f);
        }
    }
}
