using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChoose : MonoBehaviour
{
    public string player;
    public string roamed;

    public Vector2 mouse;
    public Vector2 location;
    public Camera cam;
    public bool Clicked;
    

    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            roamed = "Player 1";
            if (Input.GetKey(KeyCode.Mouse0)){
            player = "Player 1";
            }
        }
        if (other.gameObject.tag == "Player2") {
            roamed = "Player 2";
            if (Input.GetKey(KeyCode.Mouse0)){
            player = "Player 2";
            }
        }
    }

    void OnTriggerExit2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            roamed = "";
        }

        if (other.gameObject.tag == "Player2") {
            roamed = "";
        }
    }

    void Update() {
    mouse = Input.mousePosition;
    location = cam.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y , 0f));
    gameObject.transform.position = new Vector2(location.x, location.y);
    }
}
