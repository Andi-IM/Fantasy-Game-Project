using UnityEngine;
 
public class EnemyManager : MonoBehaviour
{
   
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public Collider2D trigger;
 
 
    // void Start ()
    // {
    //     //Mengeksekusi fungs Spawn setiap beberapa detik sesui dengan nilai spawnTime
    //     InvokeRepeating ("Spawn", spawnTime, spawnTime);
    // }
 
 
    public void Spawn ()
    {
        

        //Mendapatkan nilai random
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
 
        //Memduplikasi enemy
        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        
        // hit = true;
        // boxCollider.enabled = true;
        // anim.SetTrigger("explode");

        // if (collision.tag == "Player")
        // {
        //    InvokeRepeating ("Spawn", spawnTime, spawnTime);
        // }

        Spawn();
    }

    
}