using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Monkey : MonoBehaviour
{
    public RectTransform table_position_a;
    public RectTransform chair_position;
    public RectTransform rectTransform;

    public float tween_duration;
    public Animator animator;

    public bool doneJumping = false;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        animator = GetComponent<Animator>();
    }
    public void Jump()
    {
        if (!doneJumping)
        {
            animator.SetBool("jump", true);
            GetComponent<RectTransform>().DOMove(table_position_a.position, tween_duration).OnComplete(Stage1._instance.MoveFruitToPlate);
            doneJumping = true;
        }        
     }

    public void GotoChair()
    {
        if (!doneJumping)
        {
            animator.SetBool("gotochair", true);
            GetComponent<RectTransform>().DOMove(chair_position.position, tween_duration).OnComplete(FlipMonkey);
            doneJumping = true;
        }

    }

    public void disableJumpAnimation()
    {
        animator.SetBool("gotochair", false);
        animator.SetBool("jump", false);

    }

    public void FlipMonkey()
    {
        Vector2 tmpScale = rectTransform.localScale;
        tmpScale.x *= -1;
        rectTransform.localScale = tmpScale;
    }
}
