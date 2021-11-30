using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "hide" && Input.GetKeyDown("f"))
        {
            
                Debug.Log("true");
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

    }
}
