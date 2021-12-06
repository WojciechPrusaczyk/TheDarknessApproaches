using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fKeyController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
            //gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //gameObject.GetComponent<SpriteRenderer>().sortingOrder = -10;
        //gameObject.GetComponent<SpriteRenderer>().sortingOrder = -10;
    }
}
