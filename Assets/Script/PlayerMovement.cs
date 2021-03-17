using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 2f;

    public Rigidbody2D rb;
    public Animator animator;

    private Vector2 lastDir;

    Vector2 movement;
    // Update is called once per frame
    void Update()
    {
        //Input
        /*movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");*/

        movement.x = CrossPlatformInputManager.GetAxis("Horizontal");
        movement.y = CrossPlatformInputManager.GetAxis("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x > 0 || movement.x < 0 || movement.y > 0 || movement.y < 0)
        {
            lastDir = movement;
        }

        if (lastDir.y > 0)
        {
            animator.SetBool("up", true);
            animator.SetBool("right", false);
            animator.SetBool("left", false);
            
        }
        else if (lastDir.x > 0)
        {
            animator.SetBool("up", false);
            animator.SetBool("right", true);
            animator.SetBool("left", false);
            
        }
        else if (lastDir.x < 0)
        {
            animator.SetBool("up", false);
            animator.SetBool("right", false);
            animator.SetBool("left", true);
            
        }
        else if (lastDir.y < 0)
        {
            animator.SetBool("up", false);
            animator.SetBool("right", false);
            animator.SetBool("left", false);
            
        }
    }

    private void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
