using UnityEngine;
using UnityEngine.UI;

public class ChangeValueOverTime : MonoBehaviour
{

    public Text indicator;

    public bool useFixedUpdate;

    private float variableToChange = 25;

    public float changePerSecond;

    bool inroom = false;

    public GameObject UI;

    private void Start() 
    {
        UI.SetActive(false);
    }

    void Update()
    {

       Increase();
       DisplayUI();
       Decrease();
       Limiter();
    }

    // void FixedUpdate()
    // {

    //     if (useFixedUpdate)
    //     {
    //         variableToChange += changePerSecond * Time.deltaTime;
    //     }

    // }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "suhu")
        {
           inroom = true;
        
        }

    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "suhu")
        {
           inroom = false;
            // variableToChange -= changePerSecond * Time.deltaTime;
        }
    }

    public void Increase()
    {
        if (inroom == true)
        {
            if (!useFixedUpdate)
            {
                variableToChange -= changePerSecond * Time.deltaTime;
            }


        /*
        if (variableToChange - ((int)variableToChange) < 0.01f)
        {
            Debug.Break();
        }*/

            indicator.text = ((int)variableToChange).ToString();
        }
        // else
        // {
        //      variableToChange -= changePerSecond * Time.deltaTime;
        // }
    }

    public void Decrease()
    {
        if (inroom == false)
        {
            if (!useFixedUpdate)
            {
                variableToChange += changePerSecond * Time.deltaTime;
            }


        /*
        if (variableToChange - ((int)variableToChange) < 0.01f)
        {
            Debug.Break();
        }*/

            indicator.text = ((int)variableToChange).ToString();
        }
    }

    public void DisplayUI()
    {
        if (variableToChange <= 15)
        {
            UI.SetActive(true);
            Debug.Log("reach 10");
        }
        else{
            UI.SetActive(false);
        }
    }

    public void Limiter()
    {
       variableToChange = Mathf.Clamp(variableToChange, 5, 30);
    }


}
