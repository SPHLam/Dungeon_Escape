using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Animator _swordAnimator;
    private SpriteRenderer _spriteRender;
    private SpriteRenderer _swordSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _animator = transform.GetChild(0).GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.LogError("Animator is null!");
        }

        _spriteRender = transform.GetChild(0).GetComponent<SpriteRenderer>();
        if (_spriteRender == null)
        {
            Debug.LogError("Sprite render is null!");
        }

        _swordAnimator = transform.GetChild(1).GetComponent<Animator>();
        if (_swordAnimator == null)
        {
            Debug.LogError("Sword Arc animator is null!");
        }

        _swordSpriteRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
        if (_swordSpriteRenderer == null)
        {
            Debug.LogError("Sword Arc sprite renderer is null!");
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
            _swordSpriteRenderer.flipY = true;
        }
        else if (horizontalInput > 0)
        {
            _spriteRender.flipX = false;
            _swordSpriteRenderer.flipY = false;
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

    public void Death()
    {
        _animator.SetTrigger("Death");
    }
}
