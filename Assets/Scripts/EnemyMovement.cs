using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector2 arahjalan;
    private Rigidbody2D rb;
    public float speed;
    public GameObject target;
    public Vector2 direction;
    public bool gardenArea;
    public bool garageArea;
    public bool masterBedroomArea;
    public bool playerb;
    public bool garageb;
    public bool garage1b;
    public bool garage2b;
    public bool garage3b;
    public bool gardenb;
    public bool garden1b;
    public bool garden2b;
    public bool garden3b;
    public bool masterBedroomb;
    public bool masterBedroom1b;
    public bool masterBedroom2b;
    public bool masterBedroom3b;
    public bool masterBedroom4b;
    public bool masterBedroom5b;
    public GameObject garage1;
    public GameObject garage2;
    public GameObject garage3;
    public GameObject garage4;
    public GameObject garden1;
    public GameObject garden2;
    public GameObject garden3;
    public GameObject garden4;
    public GameObject masterBedroom1;
    public GameObject masterBedroom2;
    public GameObject masterBedroom3;
    public GameObject masterBedroom4;
    public GameObject masterBedroom5;
    public GameObject masterBedroom6;
    public float randomfloat;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        randomMovement();
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
        playerb = true;
        garageb = false;
        garage1b = false;
        garage2b = false;
        garage3b = false;
        gardenb = false;
        garden1b = false;
        garden2b = false;
        garden3b = false;
        masterBedroomb = false;
        masterBedroom1b = false;
        masterBedroom2b = false;
        masterBedroom3b = false;
        masterBedroom4b = false;
        masterBedroom5b = false;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            playerb = false; 
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
        arahjalan = direction.normalized;
        rb.velocity = arahjalan * speed;  
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (playerb == true) {
        direction = target.transform.position - this.transform.position;
        }
        if (garageb == true) {
        direction = garage1.transform.position - this.transform.position;
        }
        if (garage1b == true) {
        direction = garage2.transform.position - this.transform.position;
        }
        if (garage2b == true) {
        direction = garage3.transform.position - this.transform.position;
        }
        if (garage3b == true) {
        direction = garage4.transform.position - this.transform.position;
        }
        if (gardenb == true) {
        direction = garden1.transform.position - this.transform.position;
        }
        if (garden1b == true) {
        direction = garden2.transform.position - this.transform.position;
        }
        if (garden2b == true) {
        direction = garden3.transform.position - this.transform.position;
        }
        if (garden3b == true) {
        direction = garden4.transform.position - this.transform.position;
        }
        if (masterBedroomb == true) {
        direction = masterBedroom1.transform.position - this.transform.position;
        }
        if (masterBedroom1b == true) {
        direction = masterBedroom2.transform.position - this.transform.position;
        }
        if (masterBedroom2b == true) {
        direction = masterBedroom3.transform.position - this.transform.position;
        }
        if (masterBedroom3b == true) {
        direction = masterBedroom4.transform.position - this.transform.position;
        }
        if (masterBedroom4b == true) {
        direction = masterBedroom5.transform.position - this.transform.position;
        }
        if (masterBedroom5b == true) {
        direction = masterBedroom6.transform.position - this.transform.position;
        }

        
    }

    public void randomMovement() {
        randomfloat = Random.Range(0, 100);
    }
}
