using UnityEngine;

public class TimelineTransitionEffect : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayTransition()
    {
        if (animator == null) return;

        animator.ResetTrigger("Play");
        animator.SetTrigger("Play");
    }
}