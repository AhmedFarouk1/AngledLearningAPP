using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Monkey : MonoBehaviour
{
    public RectTransform table_position_a;
    public float tween_duration;
    public Animator animator;

    private bool doneJumping = false;
    private void Start()
    {
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
}
