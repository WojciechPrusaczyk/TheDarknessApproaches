using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class div : MonoBehaviour
{
    public Transform division;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        division.position = new Vector3(player.position.x, player.position.y, -10);
    }
}
