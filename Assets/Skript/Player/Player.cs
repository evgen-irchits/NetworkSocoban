using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    private bool facingRight = true;
    void Update()
    {
        if (hasAuthority)
        {
            
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
            float speed = 6f * Time.deltaTime;
            transform.Translate(new Vector2(input.x * speed, input.y * speed));
            Animator animator = GetComponent<Animator>();
            if (input.x == 0 && input.y == 0)
            {
                animator.SetBool("Walk", false);
            }
            else
            {
                animator.SetBool("Walk", true);
            }

            if (!facingRight && input.x < 0)
            {
                Flip();
            }
            else if(facingRight && input.x > 0)
            {
                Flip();
            }
        }
    }

    private void Flip()
    {
        if (hasAuthority)
        {
            facingRight = !facingRight;
            Vector3 Scale = transform.localScale;
            Scale.x *= -1;
            transform.localScale = Scale;
        }
    }
}
