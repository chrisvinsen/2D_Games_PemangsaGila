using UnityEngine;

public class StairDown2 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(-2.5f, -2.3f, 0f);
        }
    }
}
