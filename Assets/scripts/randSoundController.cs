using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randSoundController : MonoBehaviour
{
    public float randomTime;
    public float randomTimeMin = 5.0f;
    public float randomTimeMax = 20.0f;
    private float timer;

    public float randomTimeToPlay()
    {
        //czas max i min w sekundach
        return Random.Range(randomTimeMin, randomTimeMax);
    }
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        randomTime = randomTimeToPlay();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > randomTime)
        {
            // gramy dŸwiêk
            randomTime = randomTimeToPlay();
            timer = 0;
            //FindObjectOfType<AudioManager>().Play("chest1");
            //FindObjectOfType<AudioManager>().Play("death");

        }
        else
        {
            // nie gramy dŸwiêku
            timer += Time.deltaTime;
        }
    }
}
