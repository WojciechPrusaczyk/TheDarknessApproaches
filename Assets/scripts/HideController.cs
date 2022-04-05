using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HideController : MonoBehaviour
{

    public GameObject fKey;
    public GameObject Eyes;
    public int fKeyLayerOnHidden = -10;
    public int fKeyLayerOnShown = 10;
    public int playerLayerOnHidden = -10;
    public int playerLayerOnShown = 7;
    private void OnTriggerStay2D(Collider2D other)
    {

        fKey.GetComponent<SpriteRenderer>().sortingOrder = fKeyLayerOnShown;


        // obracanie grafiki przycisku w zale¿noœci od pozycji
        if (Input.GetKey(KeyCode.A))
        {
            fKey.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            fKey.GetComponent<SpriteRenderer>().flipX = false;
        }


        //chowanie siê:
        if (other.gameObject.CompareTag("hide") && Input.GetKey(KeyCode.F) && FindObjectOfType<VignetteController>().isInSafePosition == false)
        {
            // to siê dzieje po klikniêciu F na triggerze
            //FindObjectOfType<AudioManager>().Play("wardrobe2");

            FindObjectOfType<VignetteController>().isInSafePosition = true;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = playerLayerOnHidden;
            Eyes.GetComponent<SpriteRenderer>().sortingOrder = playerLayerOnShown;
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //akcja po wyjœciu z triggera
        FindObjectOfType<VignetteController>().isInSafePosition = false;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = playerLayerOnShown;
        Eyes.GetComponent<SpriteRenderer>().sortingOrder = playerLayerOnHidden;
        fKey.GetComponent<SpriteRenderer>().sortingOrder = fKeyLayerOnHidden;

    }
}
