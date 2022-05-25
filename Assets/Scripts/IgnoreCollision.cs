using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    public GameObject player1;
    private PlayerMovement script1; 
    private BoxCollider2D box1;
    public GameObject player2;
    private PlayerMovement2 script2; 
    private BoxCollider2D box2;
    // Start is called before the first frame update
    void Start()
    {
        script1 = player1.GetComponent<PlayerMovement>();
        script2 = player2.GetComponent<PlayerMovement2>();
        box1 = player1.GetComponent<BoxCollider2D>();
        box2 = player2.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(box1, box2, true);
    }
}
