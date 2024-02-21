using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D enemyCharacter; // pt 1 of the two common lines of code for any component you want to access
    [SerializeField] private float moveSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyCharacter = GetComponent<Rigidbody2D>(); // pt 2 of the two common lines of code for any component you want to access

    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            enemyCharacter.velocity = new Vector2(moveSpeed, 0); // left is x, right is y coordinates
        }
        else
        { 
            enemyCharacter.velocity = new Vector2 (-moveSpeed, 0);
        }
         
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Reverse the current direction (scale) of the X-Axis
        transform.localScale = new Vector2(-(Mathf.Sign(enemyCharacter.velocity.x)), 1f); 
    }

    bool IsFacingRight() // automatically private even if you do not set it that way
    {
        return transform.localScale.x > 0;

    }
}
