using UnityEngine;

[RequireComponent(typeof(Animator))]

public class IKAnimation : MonoBehaviour
{
    [SerializeField]
    private bool _isActive;
    [SerializeField]
    private Transform _pointRightHand;
    [SerializeField]
    private Transform _pointLeftHand;
    [SerializeField]
    private Transform _pointLook;

    private Animator _animator;

    private float _distance = 2;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (_isActive)
        {
            if (Vector3.Distance(gameObject.transform.position, _pointLook.position) < _distance)
            {
                _animator.SetLookAtWeight(1);
                _animator.SetLookAtPosition(_pointLook.position);
            }
            else
            {
                _animator.SetLookAtWeight(0);
            }
            WeightRighthHand(1);
            _animator.SetIKPosition(AvatarIKGoal.RightHand, _pointRightHand.position);
            _animator.SetIKRotation(AvatarIKGoal.RightHand, _pointRightHand.rotation);
            WeightLefthHand(1);
            _animator.SetIKPosition(AvatarIKGoal.LeftHand, _pointLeftHand.position);
            _animator.SetIKRotation(AvatarIKGoal.LeftHand, _pointLeftHand.rotation);
        }
        else
        {
            WeightRighthHand(0);
            WeightLefthHand(0);
            _animator.SetLookAtWeight(0);
        }
    }

    private void WeightRighthHand(float value)
    {
        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, value);
        _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, value);
    }

    private void WeightLefthHand(float value)
    {
        _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, value);
        _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, value);
    }
}
