using System.Collections.Generic;
using Andi_Scripts;
using Pathfinding;
using UnityEngine;

public class PlayerAstarMovement : MonoBehaviour
{
    [Header("Main Configuration")] public bool isChased;
    public Camera cam;
    public Transform destination;
    public GameObject body;
    public bool isWalk;
    private Animator animator;

    [Header("Player Shadow")] public GameObject playerShadow;


    // List untuk penanda sedang di klik
    static List<PlayerAstarMovement> moveableObjects = new List<PlayerAstarMovement>();
    private AIDestinationSetter setter;
    private bool selected;
    private Vector3 target;
    IAstarAI ai;

    private CircleCollider2D trigger;
    private Rigidbody2D rb;

    private bool isFaint = false;

    private void Awake()
    {
        ai = GetComponent<IAstarAI>();
        moveableObjects.Add(this);
        setter = GetComponent<AIDestinationSetter>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (CanMoveOrInteract() == false) return;

        if (Input.GetMouseButtonDown(1) && selected)
        {
            target = cam.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;

            destination.position = target;
            playerShadow.GetComponent<ShadowFollower>().SetActive();
        }

        // ai.reachedEndOfPath ?  isWalk = true : isWalk = false;
        isWalk = !ai.reachedEndOfPath;
        
        animator.SetBool("IsWalk", isWalk);

        setter.target = destination;

        if (ai.isStopped && transform.position == destination.position)
        {
            setter.target = null;
        }
    }

    private void OnMouseDown()
    {
        selected = true;
        body.GetComponent<SpriteRenderer>().color = Color.green;
        
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        foreach (PlayerAstarMovement obj in moveableObjects)
        {
            if (obj != this)
            {
                obj.selected = false;
            }
        }


    }

    bool CanMoveOrInteract()
    {
        // ReSharper disable once ReplaceWithSingleAssignment.True
        var can = true;

        if (FindObjectOfType<InteractionSystem>().isExamining)
            can = false;
        if (FindObjectOfType<InventorySystem>().isOpen)
            can = false;
        if (isFaint) can = false;

        return can;
    }

    private void OnDrawGizmosSelected()
    {
        // Gizmos check
        Gizmos.color = Color.yellow;
    }

    public void Chased()
    {
        isChased = true;
        // Set level to reset
        // FindObjectOfType<LevelManager>().Restart():
    }


    public void ResetPlayer()
    {
        isFaint = false;
        isChased = false;
    }
}