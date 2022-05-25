using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    static List<MoveToMouse> moveableObjects = new List<MoveToMouse>();
    public float speed = 5f;
    private bool selected;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        moveableObjects.Add(this);
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && selected)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        selected = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;

        foreach (MoveToMouse obj in moveableObjects)
        {
            if (obj != this)
            {
                obj.selected = false;
                obj.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
}