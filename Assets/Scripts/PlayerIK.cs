using UnityEngine;
public class PlayerIK : MonoBehaviour
{
    public Animator animator;

    public Transform rightHandTarget;
    public Transform leftHandTarget;
    public Transform leftElbowTarget;

    [Range(0, 1)]
    public float leftHandIKWeight = 1.0f;

    private bool isReloading = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        isReloading = stateInfo.IsName("Recargar") || stateInfo.IsName("RecargarRifle");

        if (isReloading)
        {
            leftHandIKWeight = 0;
        }
        else
        {
            leftHandIKWeight = 1.0f;
        }
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (animator)
        {
            // Right hand IK
            if (rightHandTarget != null)
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandTarget.position);
                animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandTarget.rotation);
            }

            // Left hand IK
            if (leftHandTarget != null)
            {
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandIKWeight);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandIKWeight);
                animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTarget.position);
                animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandTarget.rotation);
            }

            // Left elbow IK (if needed)
            if (leftElbowTarget != null)
            {
                animator.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, 1);
                animator.SetIKHintPosition(AvatarIKHint.LeftElbow, leftElbowTarget.position);
            }
        }
    }
}