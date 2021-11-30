using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collect : MonoBehaviour
{
    public bool isInSafePosition = false;
    
    /*IEnumerator czekanie()
    {
        yield return new WaitForSeconds(5.5f);
    }
    public void safe()
    {
        gameObject.layer = -10;
        isInSafePosition = true;
        czekanie();
        isInSafePosition = false;
        gameObject.layer = 7;
    }*/
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool E = false;
        if (other.gameObject.CompareTag("key"))
        { 
        Destroy(other.gameObject);
        E=true;
        }
        if (other.gameObject.CompareTag("exit")&&E==true)
        {
            SceneManager.LoadScene("End");
        }
        /*if (other.gameObject.CompareTag("hide"))
        { 
        if(Input.GetKeyDown("space"))
            {
                safe();
            }
        }*/
    }
}
