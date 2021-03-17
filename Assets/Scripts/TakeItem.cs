using UnityEngine;

public class TakeItem : MonoBehaviour
{
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Vector2 touchWorldPoint = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(touchWorldPoint, Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        Debug.Log(this.gameObject.name);
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }
}
