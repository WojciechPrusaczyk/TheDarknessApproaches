using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fKeyController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "hide")
        {
            Debug.Log("layer 10");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        gameObject.layer = -10;
    }
}
