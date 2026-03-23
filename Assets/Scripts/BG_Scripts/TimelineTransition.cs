using UnityEngine;

public class TimelineTransition : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayTransition()
    {
        animator.SetTrigger("Play");
    }
}
