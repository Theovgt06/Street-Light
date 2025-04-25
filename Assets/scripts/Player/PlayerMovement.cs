using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("Mouvement")]
    [SerializeField]
    public float moveSpeed = 4f;
    private bool isFacingRight = true;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
   

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.linearVelocity = new Vector2(moveSpeed, 0);
            if (!isFacingRight)
            {
                Flip();
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Flip();
            rb.linearVelocity = new Vector2(-moveSpeed, 0);
            if (isFacingRight)
            {
                Flip();
            }
        }
       /* else if (Input.GetKeyDown(KeyCode.Z))
        {
            Interact interact = GetComponent<Interact>();
        }*/
    }
}
