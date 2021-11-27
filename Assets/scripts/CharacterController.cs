using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject player; //gracz
    public Ladder ladder; //deklaracja drabiny
    GameObject drabina; //gameobject drabina
    Rigidbody2D rigidbody; //rigidbody, cokolwiek to jest
    // Start is called before the first frame update
    float charspeed = 5f; //mowi samo za siebie
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>(); 
    }

    private void FixedUpdate()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * charspeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("drabka");
        drabina = collision.gameObject.GetComponent<Ladder>()?.drabina; //wykrywa kolizje z drabina 
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Player left a ladder");
        drabina = null;
    }


    // Update is called once per frame
    void Update()
    {
        FixedUpdate();
    /*    if (Input.GetKey("w"))
        {
            if (drabina != null)
            {
                if (player.transform.position.x == drabina.transform.position.x)
                {
                    player.transform.position += new Vector3(0, charspeed);
                }
            }
        }
        if (Input.GetKey("s"))
        {
            if (drabina != null)
            {
                if (player.transform.position.y == drabina.transform.position.y)
                {
                    player.transform.position += new Vector3(0, -charspeed);
                }
            }
            }
        if (Input.GetKey("a"))
        {
            player.transform.position += new Vector3(-charspeed, 0);
        }
        if (Input.GetKey("d"))
        {
            player.transform.position += new Vector3(charspeed, 0);
        } */ //OBSOLETE


    }
}
