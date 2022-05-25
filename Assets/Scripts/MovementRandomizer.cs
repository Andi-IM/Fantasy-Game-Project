using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRandomizer : MonoBehaviour
{
    public GameObject target;
    private EnemyMovement script;
    private BoxCollider2D trigger;
    public bool hit;
    // Start is called before the first frame update
    void Start()
    {
        script = target.GetComponent<EnemyMovement>();
        trigger = gameObject.GetComponent<BoxCollider2D>();
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Garage") {
            hit = true;
            script.randomMovement();
            StartCoroutine(triggerShutdown());
        }

        if (other.gameObject.tag == "Garden") {
            hit = true;
            script.randomMovement();
            StartCoroutine(triggerShutdown());
        }

        if (other.gameObject.tag == "MasterBedroom") {
            hit = true;
            script.randomMovement();
            StartCoroutine(triggerShutdown());
        }

        if (other.gameObject.tag == "GarageArea") {
        if (script.playerb == false){
        script.playerb = false;
        script.gardenArea = false;
        script.garageArea = true;
        script.masterBedroomArea = false;
        }
        }

        if (other.gameObject.tag == "GardenArea") {
        if (script.playerb == false){
        script.playerb = false;
        script.gardenArea = true;
        script.garageArea = false;
        script.masterBedroomArea = false;
        }
        }

        if (other.gameObject.tag == "MasterBedroomArea") {
        if (script.playerb == false){
        script.playerb = false;
        script.gardenArea = false;
        script.garageArea = false;
        script.masterBedroomArea = true;
        }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "GarageArea") {
        script.garageArea = false;
        script.garageb = false;
        script.garage1b = false;
        script.garage2b = false;
        script.garage3b = false;
        }

        if (other.gameObject.tag == "GardenArea") {
        script.gardenArea = false;
        script.gardenb = false;
        script.garden1b = false;
        script.garden2b = false;
        script.garden3b = false;
        }

        if (other.gameObject.tag == "MasterBedroomArea") {
        script.masterBedroomArea = false;
        script.masterBedroomb = false;
        script.masterBedroom1b = false;
        script.masterBedroom2b = false;
        script.masterBedroom3b = false;
        script.masterBedroom4b = false;
        script.masterBedroom5b = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (script.playerb == false & script.garageArea == true){ // Garage
        if (script.randomfloat <= 25) {
            script.garageb = true;
            script.garage1b = false;
            script.garage2b = false;
            script.garage3b = false;
        }

        if (script.randomfloat <= 50 && script.randomfloat > 25) {
            script.garageb = false;
            script.garage1b = true;
            script.garage2b = false;
            script.garage3b = false;
        }

        if (script.randomfloat <= 75 && script.randomfloat > 50) {
            script.garageb = false;
            script.garage1b = false;
            script.garage2b = true;
            script.garage3b = false;
        }

        if (script.randomfloat <= 100 && script.randomfloat > 75) {
            script.garageb = false;
            script.garage1b = false;
            script.garage2b = false;
            script.garage3b = true;
        }
        }

        if (script.playerb == false & script.gardenArea == true){ // Garden
        if (script.randomfloat <= 25) {
            script.gardenb = true;
            script.garden1b = false;
            script.garden2b = false;
            script.garden3b = false;
        }

        if (script.randomfloat <= 50 && script.randomfloat > 25) {
            script.gardenb = false;
            script.garden1b = true;
            script.garden2b = false;
            script.garden3b = false;
        }

        if (script.randomfloat <= 75 && script.randomfloat > 50) {
            script.gardenb = false;
            script.garden1b = false;
            script.garden2b = true;
            script.garden3b = false;
        }

        if (script.randomfloat <= 100 && script.randomfloat > 75) {
            script.gardenb = false;
            script.garden1b = false;
            script.garden2b = false;
            script.garden3b = true;
        }
        }

        if (script.playerb == false & script.masterBedroomArea == true){ // masterBedroom
        if (script.randomfloat <= 16) {
            script.masterBedroomb = true;
            script.masterBedroom1b = false;
            script.masterBedroom2b = false;
            script.masterBedroom3b = false;
            script.masterBedroom4b = false;
            script.masterBedroom5b = false;
        }

        if (script.randomfloat <= 32 && script.randomfloat > 16) {
            script.masterBedroomb = false;
            script.masterBedroom1b = true;
            script.masterBedroom2b = false;
            script.masterBedroom3b = false;
            script.masterBedroom4b = false;
            script.masterBedroom5b = false;
        }

        if (script.randomfloat <= 48 && script.randomfloat > 32) {
            script.masterBedroomb = false;
            script.masterBedroom1b = false;
            script.masterBedroom2b = true;
            script.masterBedroom3b = false;
            script.masterBedroom4b = false;
            script.masterBedroom5b = false;
        }

        if (script.randomfloat <= 64 && script.randomfloat > 48) {
            script.masterBedroomb = false;
            script.masterBedroom1b = false;
            script.masterBedroom2b = false;
            script.masterBedroom3b = true;
            script.masterBedroom4b = false;
            script.masterBedroom5b = false;
        }

        if (script.randomfloat <= 80 && script.randomfloat > 64) {
            script.masterBedroomb = false;
            script.masterBedroom1b = false;
            script.masterBedroom2b = false;
            script.masterBedroom3b = false;
            script.masterBedroom4b = true;
            script.masterBedroom5b = false;
        }

        if (script.randomfloat <= 100 && script.randomfloat > 80) {
            script.masterBedroomb = false;
            script.masterBedroom1b = false;
            script.masterBedroom2b = false;
            script.masterBedroom3b = false;
            script.masterBedroom4b = false;
            script.masterBedroom5b = true;
        }
        }
    }

    IEnumerator triggerShutdown() {
        hit = true;
        yield return new WaitForSeconds(2f);
        hit = false;
    }

}
