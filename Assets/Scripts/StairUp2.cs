using UnityEngine;

public class StairUp2 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(-10.3f, -18.7f, 0f);
        }
    }
}
