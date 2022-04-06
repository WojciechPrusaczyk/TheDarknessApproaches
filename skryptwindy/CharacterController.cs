using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject player; //gracz
    public GameObject fKey;
    public Ladder ladder; //deklaracja drabiny
    public Elevatoronoff trigger;
    public Elevator elevator;
    GameObject drabina; //gameobject drabina

    Rigidbody2D rigidbody; //rigidbody, cokolwiek to jest
    //public Collider2D gracz;
    //public Collider2D drabka;
    public Anim animidle;
    public Anim animrun;
    //public Anim animladder; //DRABINY
    public bool bIsOnElevator = false;
    // Start is called before the first frame update
    public float charspeed = 4500f; //mowi samo za siebie

    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

        //rigidbody.AddForce(transform.right * 1500f);
        animidle.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        trigger = collision.gameObject.GetComponent<Elevatoronoff>();
        elevator = trigger.transform.parent.GetComponent<Elevator>();

    }

    private void FixedUpdate()
    {
        Vector3 h_Input = new Vector3(Input.GetAxis("Horizontal"), 0); //inputy Horizontal
        Vector3 v_Input = Vector3.zero; //inputy Vertical
        if (drabina != null) //Drabiny... drabiny...
        {
            v_Input = new Vector3(0, Input.GetAxis("Vertical")); //

        }

        Vector2 force = (h_Input + v_Input * 2) * Time.fixedDeltaTime * charspeed;

        rigidbody.AddForce(force); //Movement 
    }
    


    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Player left a ladder");
        trigger = null;
        elevator = null;
        bIsOnElevator = false;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("f") && elevator == trigger.transform.parent.GetComponent<Elevator>())
        {
            elevator.active = true;
        }

        if (Input.GetKey("a"))
        {
            player.transform.rotation = Quaternion.Euler(0, 180, 0); //rotacja gracza
            animidle.Stop();
            animrun.Play();
        }
        if (Input.GetKey("d"))
        {
            animidle.Stop();
            animrun.Play();
            
            player.transform.rotation = Quaternion.Euler(0, 0, 0); //rotacja gracza
            
        }
        if(Mathf.Abs(rigidbody.velocity.magnitude) < float.Epsilon)
        {
            animrun.Stop();
            animidle.Play();
        }

    }
}
