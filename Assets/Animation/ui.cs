using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui : MonoBehaviour
{
    public GameObject UI;
    


    //public string LevelName;


    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "suhu")
        {
           UI.SetActive(true);

           StartCoroutine(UISetOff());
        }
        
    }
    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     UI.SetActive(false);
    // }

    IEnumerator UISetOff()
    {
        yield return  new WaitForSeconds(3);
        UI.SetActive(false);
    }
}
