using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour
{

    [SerializeField] private Transform lookAtTarget;
    [SerializeField] private Transform legIKGoal;
    
    [SerializeField] [Range(0f, 1f)] private float lookAtWeight;
    [SerializeField] [Range(0f, 1f)] private float legIKWeight;
    
    private const string VEL_Z = "ZVelocity";
    private const string VEL_Y = "XVelocity";
    private const string WAVING = "Waving";
    private const string DANCING = "Dancing";
    
    
    private Animator _animator;

    private int _waveParam;
    private int _danceParam;

    private float _danceValue;

    private AvatarIKGoal rightFoot = AvatarIKGoal.RightFoot;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _waveParam = _animator.GetLayerIndex(WAVING);
        _danceParam = _animator.GetLayerIndex(DANCING);
        Debug.Log(_waveParam);

    }

    private void Update()
    {
        float inputV = Input.GetAxis("Vertical");
        float inputH = Input.GetAxis("Horizontal");
        
        _animator.SetFloat(VEL_Z, inputV);
        _animator.SetFloat(VEL_Y, inputH);

        
        
        if (Input.GetKey(KeyCode.E))
        {
            if (_danceValue < 1.0)
                _danceValue += Time.deltaTime * 0.2f;
            
            _animator.SetLayerWeight(_danceParam, _danceValue);
        }
        else if(_danceValue > 0)
        {
            _danceValue -= Time.deltaTime * 0.5f;
            _animator.SetLayerWeight(_danceParam, _danceValue);
        }
        
        

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _animator.SetLayerWeight(_waveParam, 1f);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _animator.SetLayerWeight(_waveParam, 0f);
        }
    }

    private void OnAnimatorIK(int layerIndex)
    {
        _animator.SetLookAtPosition(lookAtTarget.position);
        _animator.SetLookAtWeight(lookAtWeight);
        
       // _animator.SetIKPosition(rightFoot, legIKGoal.position);
      // _animator.SetIKPositionWeight(rightFoot, legIKWeight);

    }
}
