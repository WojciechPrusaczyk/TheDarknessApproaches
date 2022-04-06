using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject elevator; //gameobject windy xd
    public GameObject Trigger;
    public bool direction; //0 - dol, 1 - gora
    public float speed; //predkosc z ktora winda jedze do gory
    Vector3 begin, end; //start i koniec
    public float destination; //miejsce docelowe ustawiane przez Ciebie Wojtus
    public bool active;
    public GameObject playerinstance;
    void Start()
    {
        active = false;
        direction = true;
        begin = new Vector3(elevator.transform.position.x, elevator.transform.position.y); // przypisanie poczatku
        end = new Vector3(elevator.transform.position.x, elevator.transform.position.y + destination); //przypisanie konca
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision = playerinstance.GetComponent<Collider2D>())
        {
            Debug.Log("Kolizja");
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            if (direction == true)
            {
                elevator.GetComponent<Transform>().position = Vector3.MoveTowards(elevator.transform.position, end, speed * Time.deltaTime);
                if (elevator.GetComponent<Transform>().position.y == end.y)
                {
                    direction = false;
                    active = false;
                }
            }
            if (direction == false)
            {
                elevator.GetComponent<Transform>().position = Vector3.MoveTowards(elevator.transform.position, begin, speed * Time.deltaTime);
                if (elevator.GetComponent<Transform>().position.y == begin.y)
                {
                    direction = true;
                    active = false;
                }
            }
        }
    }

}
