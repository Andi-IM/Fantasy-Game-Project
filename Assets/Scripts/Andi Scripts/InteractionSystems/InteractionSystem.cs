using System;
using Andi_Scripts;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InteractionSystem : MonoBehaviour
{
    [Header("Detection Fields")]
    // Detection Point
    public Transform detectionPoint;

    // Detection Radius
    private const float detectionRadius = 0.2f;

    // Detection Layer
    public LayerMask detectionLayer;

    // Cached TriggerObject
    public GameObject detectedObject;

    [Header("Examine Fields")] public GameObject examineWindow;
    public GameObject grabbedObject;
    public float grabbedObjectYValue;
    public Transform grabPoint;
    public Image examineImage;
    public Text examineText;
    public bool isExamining;
    public bool isGrabbing;

    private void Update()
    {
        if (DetectObject())
        {
            Debug.Log("Object Detected!");
            if (InteractInput())
            {
                Debug.Log("Input Detected!");
                GrabDrop();
                return;
            }
            
            detectedObject.GetComponent<Item>().Interact();
        }
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }

    bool DetectObject()
    {
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);

        if (obj == null)
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;
        }
    }

    public void ExamineItem(Item item)
    {
        if (isExamining)
        {
            // Hide the Examine Window
            examineWindow.SetActive(false);
            // disable examine
            isExamining = false;
        }
        else
        {
            // Show the item's image in the middle
            examineImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
            // Write the description text underneath the image
            examineText.text = item.descriptionText;
            // Display an Examine Window
            examineWindow.SetActive(true);
            // enable examining
            isExamining = true;
        }
    }

    public void GrabDrop()
    {
        // Check if we do have a grabbed object => drop it
        if (isGrabbing)
        {
            // make isGrabbing false
            isGrabbing = false;
            // unparent the grabbed object
            grabbedObject.transform.parent = null;
            // Set the y position to it's origin
            grabbedObject.transform.position = new Vector3(grabbedObject.transform.position.x, grabbedObjectYValue, grabbedObject.transform.position.z);
            // null the grabbed object reference
            grabbedObject = null;
        }
        // Check if we have nothing grabbed grab the detected item
        else
        {
            // Enable isGrabbing bool
            isGrabbing = true;
            // assign the grabbed to the object itself
            grabbedObject = detectedObject;
            // Parent the grabbed object to the player
            grabbedObject.transform.parent = transform;
            // Cache the y value of the object
            grabbedObjectYValue = grabbedObject.transform.position.y;
            // Adjust the position of the grabbed object to be closer to hands
            grabbedObject.transform.localPosition = grabPoint.localPosition;
        }
    }
}