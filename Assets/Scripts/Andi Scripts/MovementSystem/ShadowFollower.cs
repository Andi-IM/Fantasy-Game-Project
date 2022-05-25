using UnityEngine;

public class ShadowFollower : MonoBehaviour
{
    private CircleCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
    }
    
    public void SetActive()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}