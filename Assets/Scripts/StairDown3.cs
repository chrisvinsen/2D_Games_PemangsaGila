using UnityEngine;

public class StairDown3 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(-10.3f, -9.1f, 0f);
        }
    }
}
