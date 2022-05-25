using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator = null;
    private string IsOpenAnim = "IsOpen";

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            doorAnimator.SetBool(IsOpenAnim, true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimator.SetBool(IsOpenAnim, false);
        }
    }
}