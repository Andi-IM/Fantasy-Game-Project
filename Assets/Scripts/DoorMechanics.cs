using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanics : MonoBehaviour
{
    public float parameter;
    public float rotation;
    public string position;
    public GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        position = "";
    }

    // Update is called once per frame
    void Update()
    {
        rotation = transform.rotation.z;
        parameter = Vector3.Distance(playerObject.transform.position, gameObject.transform.position);

        if (gameObject.transform.position.x > playerObject.transform.position.x){
            parameter = parameter * -1;
        }

        if (parameter > 0 && parameter < 1)
        {
            if (position != "Left"){
            position = "Right";
            }
            if (position == "Right"){
            gameObject.transform.Rotate(0, 0, 0.7f);
            if (rotation > 0.7f){
            gameObject.transform.Rotate(0, 0, 0);
            gameObject.transform.rotation = Quaternion.Euler(0,0,90);  
            }
            }
        }

        if (parameter < -2.5)
        {
            gameObject.transform.Rotate(0, 0, -0.7f);
            if (rotation < 0.1f){
            gameObject.transform.Rotate(0, 0, 0);
            gameObject.transform.rotation = Quaternion.Euler(0,0,0);
            position = "";  
            }
        }

        if (parameter < 0 && parameter > -1)
        {
            if (position != "Right"){
            position = "Left";
            }
            if (position == "Left"){
            gameObject.transform.Rotate(0, 0, -0.7f);
            if (rotation < -0.7f){
            gameObject.transform.Rotate(0, 0, 0);
            gameObject.transform.rotation = Quaternion.Euler(0,0,-90);  
            }
            }
        }

        if (parameter > 2.5)
        {
            gameObject.transform.Rotate(0, 0, 0.7f);
            if (rotation > -0.1f){
            gameObject.transform.Rotate(0, 0, 0);
            gameObject.transform.rotation = Quaternion.Euler(0,0,0);  
            position = "";  
            }
        }

    }
}
