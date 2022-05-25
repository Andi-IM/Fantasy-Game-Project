using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aroma : MonoBehaviour
{
    public GameObject kuning;
    public GameObject merah;
    public GameObject suhu;
    // Start is called before the first frame update
    void Start()
    {
       kuning.SetActive(false);
       merah.SetActive(false); 
       suhu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        
        if (collision.tag == "kuning")
        {
           kuning.SetActive(true);
        }

        if (collision.tag == "merah")
        {
           merah.SetActive(true);
        }

        if (collision.tag == "suhu")
        {
           suhu.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        
        if (collision.tag == "kuning")
        {
           kuning.SetActive(false);
        }

        if (collision.tag == "merah")
        {
           merah.SetActive(false);
        }

        if (collision.tag == "suhu")
        {
           suhu.SetActive(false);
        }

    }

   
}
