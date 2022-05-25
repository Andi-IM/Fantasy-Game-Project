using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public Vector2 location;
    public Vector2 locationEnd;
    public Vector2 arahjalan;
    public Vector2 arahjalanstatic;
    public Vector2 mouse;
    public Vector2 direction;
    public Vector2 lineMover;
    public GameObject path;
    public Camera cam;
    public GameObject camG;
    public Vector2 camV;
    private BoxCollider2D trigger;
    public BoxCollider2D hidingplace;
    public bool chased;
    private LineRenderer lineRenderer;
    public Text notifikasi;
    public Text objectResult;
    private bool checking;
    private bool searching;
    private bool moved;
    public bool clicked;
    public GameObject pointerObject;
    private PlayerChoose playerCheck; 

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        trigger = gameObject.GetComponent<BoxCollider2D>();
        lineRenderer = gameObject.GetComponent<LineRenderer>();     
        playerCheck = pointerObject.GetComponent<PlayerChoose>();
        lineRenderer.SetPosition(0, gameObject.transform.position);
            lineRenderer.SetPosition(1, gameObject.transform.position);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Path") {
        Invoke("Delay", 0.0f);
        clicked = false;
        moved = false;
        }

        if (other.gameObject.tag == "Enemy") {
        chased = true;
        }

        if (other.gameObject.tag == "ObjectSearch") {
        checking = true;
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Hide") {
        if (chased == false){
        if (clicked == false){
        gameObject.transform.position = hidingplace.transform.position;
        trigger.enabled = false;    
        rb.velocity = Vector2.zero;  
        path.SetActive(false);
        }
        } else {
            if (clicked == false){
        gameObject.transform.position = hidingplace.transform.position;
        trigger.enabled = true;
        rb.velocity = Vector2.zero;  
        path.SetActive(false);
        }
        }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy") {
        chased = false;
        }
        if (other.gameObject.tag == "ObjectSearch") {
        checking = false;
        searching = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        camV = camG.transform.position;
        mouse = Input.mousePosition;
        location = cam.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y , 0f));
        locationEnd = location - camV;
        direction = location - (new Vector2(transform.position.x, transform.position.y));
        lineMover = gameObject.transform.position;
        lineRenderer.SetPosition(0, gameObject.transform.position);
        arahjalan = direction.normalized;

        if (moved == true) {
            rb.velocity = arahjalanstatic * speed;
        }

        if (playerCheck.player == "Player 1"){
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            if (playerCheck.roamed == ""){
            moved = true;
            arahjalanstatic = arahjalan;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            path.SetActive(true);
            path.transform.position = new Vector2(location.x, location.y);
            trigger.enabled = true;
            lineRenderer.SetPosition(0, gameObject.transform.position);
            lineRenderer.SetPosition(1, path.transform.position);
            clicked = true;
        }
        }
        }


        if (checking == true) {
            notifikasi.enabled = true;
            notifikasi.text = "Press E to check for items";
            if (searching == false){
            objectResult.text = "Searching...";
            }
        } else {
            notifikasi.enabled = false;
            objectResult.text = "Go to objects to find some items";
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            searching = true;
            if (checking == true) {
                if (searching == true){
            if (Random.Range(0, 100) < 50){
                objectResult.text = "Barang ditemukan";
            } else if (Random.Range(0, 100) > 50) {
                objectResult.text = "Tidak ada barang";
            }
            }
            }
        }
    }

    void Delay() {
        rb.velocity = Vector2.zero;
        gameObject.transform.position = path.transform.position;
        path.SetActive(false);
        lineRenderer.SetPosition(0, gameObject.transform.position);
            lineRenderer.SetPosition(1, gameObject.transform.position); 
    }

    void triggerShowing() {
    trigger.enabled = true;    
    }

    IEnumerator triggerSwitch() {
        hidingplace.enabled = false;
        yield return new WaitForSeconds(1.0f);
        hidingplace.enabled = true;
    }

}
