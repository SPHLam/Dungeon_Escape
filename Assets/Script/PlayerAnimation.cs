using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Animator _swordAnimator;
    private SpriteRenderer _spriteRender;

    // Start is called before the first frame update
    void Start()
    {
        _animator = transform.GetChild(0).gameObject.GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.LogError("Animator is null!");
        }

        _spriteRender = GetComponentInChildren<SpriteRenderer>();
        if (_spriteRender == null)
        {
            Debug.LogError("Sprite render is null!");
        }

        _swordAnimator = transform.GetChild(1).gameObject.GetComponent<Animator>();
        if (_swordAnimator == null)
        {
            Debug.LogError("Sword Arc animator is null!");
        }
    }

    public void Run(float horizontalInput)
    {
        // set the condition between run and idle animation
        _animator.SetFloat("Run", Mathf.Abs(horizontalInput));
    }

    public void Flip(float horizontalInput)
    {
        // Flipped the animation based on direction the player is heading to
        if (horizontalInput < 0)
        {
            _spriteRender.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            _spriteRender.flipX = false;
        }
    }

    public void Jump(bool isJumping)
    {
        _animator.SetBool("Jump", isJumping);
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
        _swordAnimator.SetTrigger("SwordAnimation");
    }
}
