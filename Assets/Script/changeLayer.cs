using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeLayer : MonoBehaviour
{
    public SpriteRenderer sprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sprite.sortingOrder = 1;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sprite.sortingOrder = 3;
        }
    }
}
