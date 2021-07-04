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

    public void Joy()
    {
        GetComponent<AudioSource>().Play();
        animator.SetBool("joy", true);
    }

    public void Inside()
    {
        animator.SetBool("inside", true);
    }

    public void Outside()
    {
        animator.SetBool("outside", true);//needs to be done
    }

    public void stage2Speak()
    {
        Stage2._instance.Speak();
    }

    public void disableAnimationParameters()
    {
        Debug.Log("disabled animation");    
        animator.SetBool("gotochair", false);
        animator.SetBool("jump", false);
        animator.SetBool("inside", false);
        animator.SetBool("joy", false);

    }

    public void FlipMonkey()
    {
        Vector2 tmpScale = rectTransform.localScale;
        tmpScale.x *= -1;
        rectTransform.localScale = tmpScale;
        Stage2._instance.Speak();
    }

    public void playSwingSound()
    {
        LetterAudioManager._instance.monkeySwing();
    }
}
