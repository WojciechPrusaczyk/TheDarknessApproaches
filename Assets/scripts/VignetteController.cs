using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;


public class VignetteController : MonoBehaviour 
{

    public  float randomValue;
    public float timer = 0;
    // D³ugoœæ przyciemnienia:
    public float BlackScreenTime = 5.3f;
    // Czas pomiêdzy klatkami przyciemniania i odwrotnie:
    public float pausing = 0.1f;
    public float minObscure = 5f;
    public float maxObscure = 40f;
    public bool isInSafePosition = false;
    public float TimeToObscure()
    {
        //czas max i min do przyciemnienia w sekundach
        return Random.Range(minObscure, maxObscure);
    }
    

    public PostProcessProfile postprocess;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        randomValue = TimeToObscure();
        ((Vignette)postprocess.settings[0]).intensity.value = 0.4f;
        ((ColorGrading)postprocess.settings[1]).colorFilter.value = Color.grey;

    }
    
    // Update is called once per frame
    IEnumerator FadingAnimation()
    {
        enabled = false;
        for (float i = 0.4f; i <= 1.0f; i+=0.01f)
        {
            yield return new WaitForSeconds(pausing);
            ((Vignette)postprocess.settings[0]).intensity.value = i;
            ((ColorGrading)postprocess.settings[1]).saturation.value = i;
        }
        yield return new WaitForSeconds(pausing);
        ((ColorGrading)postprocess.settings[1]).colorFilter.value = Color.black;
        yield return new WaitForSeconds(BlackScreenTime);
        if (isInSafePosition == true)
        {
            ((Vignette)postprocess.settings[0]).intensity.value = 1.0f;
            Debug.Log("Jestes bezpieczny/a");
            ((ColorGrading)postprocess.settings[1]).colorFilter.value = Color.grey;
            for (float i = 0.9f; i >= 0.3f; i -= 0.01f)
            {
                yield return new WaitForSeconds(pausing);
                ((Vignette)postprocess.settings[0]).intensity.value = i;
                ((ColorGrading)postprocess.settings[1]).saturation.value = i;
            }
        }
        else
        {
            //game OVER
            ((Vignette)postprocess.settings[0]).intensity.value = 0;
            ((ColorGrading)postprocess.settings[1]).saturation.value = 0;
            FindObjectOfType<AudioManager>().Play("death");
            DeathScene();
        }

        enabled = true;


    }
    public void DeathScene()
    {
        SceneManager.LoadScene("dead");
    }
    void Update()
    {
        
        if (timer > randomValue)
        {
            // przyciemnienie sie zaczyna
            Debug.Log("Przyciemnienie sie zaczyna");
            randomValue = TimeToObscure();
            timer = 0;
            StartCoroutine(FadingAnimation());



        }
        else
        {
            // jeszcze nie ma przyciemnienia
            timer += Time.deltaTime;
        }
    }
}


