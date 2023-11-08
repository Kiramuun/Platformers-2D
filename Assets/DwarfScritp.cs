using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfScritp : MonoBehaviour
{
    public Animator _animatorRef;
    public Rigidbody2D _dwarfRigid;

    public float _force,
                 _forceJump;

    int _direction;

    bool _jump = false;

    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _animatorRef.SetBool("DwarfSpeedJump", false);
    }

    void Update()
    {
        if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0)
            && !_animatorRef.GetBool("DwarfSpeedJump"))
        {
            _jump = true;
            _animatorRef.SetBool("DwarfSpeedJump", true);
        }
        if (!_jump) { return; }
        
        _dwarfRigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, _forceJump);
        _dwarfRigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

        _jump = false;

        
    }

    void FixedUpdate()
    {
        _animatorRef.SetFloat("DwarfSpeedLine", Mathf.Abs(_dwarfRigid.velocity.x));

        Vector3 moveVelocity = Vector3.zero;

        float horizontal = Input.GetAxisRaw("Horizontal");
       
        if(horizontal > 0) 
        {
            _direction = 1;
            moveVelocity = Vector3.left;

            transform.localScale = new Vector3(_direction, 1, 1);
            
            _dwarfRigid.AddForce(transform.right * _force,ForceMode2D.Impulse); 
        }

        if(horizontal < 0) 
        {
            _direction = -1;
            moveVelocity = Vector3.right;

            transform.localScale = new Vector3(_direction, 1, 1);
            
            _dwarfRigid.AddForce(transform.right*-1 * _force, ForceMode2D.Impulse); 
        }

        if (_dwarfRigid.velocity.y < 0)
        {
            _animatorRef.SetBool("DwarfSpeedJump", false);
        }
    }
}
