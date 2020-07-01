using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{

    public Slider healthBarSlider;      //reference for slider         //reference for text

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void healthUP()
    {
        healthBarSlider.value += 20.0f;
    }


    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && healthBarSlider.value > 0)
        {
            healthBarSlider.value -= 0.5f;  //reduce health
        }
        else if(0 >= healthBarSlider.value)
        {    //set game over to true                     

            SceneManager.LoadScene("Lose");
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy" && healthBarSlider.value > 0)
        {
            healthBarSlider.value -= 0.5f;  //reduce health
        }
        else if (0 >= healthBarSlider.value)
        {    //set game over to true
           // SceneManager.LoadScene("Lose");
        }
    }
}
