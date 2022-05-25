using UnityEngine;
 
public class Tes : MonoBehaviour
{
   
    public GameObject enemy;
    public Transform spawnPoints;
    public Collider2D trigger;
 
 
    // void Start ()
    // {
    //     //Mengeksekusi fungs Spawn setiap beberapa detik sesui dengan nilai spawnTime
    //     InvokeRepeating ("Spawn", spawnTime, spawnTime);
    // }
 
 
    public void Spawn ()
    {
        

       
 
        //Memduplikasi enemy
        Instantiate (enemy, spawnPoints.position, spawnPoints.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        
        // hit = true;
        // boxCollider.enabled = true;
        // anim.SetTrigger("explode");

        if (collision.tag == "Player")
        {
           Spawn();
        }

       
    }

    
}