using Pathfinding;
using System.Collections;
using UnityEngine;

namespace Characters
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(BoyDie))]
    public class BoyMovement : MonoBehaviour
    {
        [SerializeField] private float _timeBeforeDeath;
        [SerializeField] private AIDestinationSetter _destinationSetter;

        private float _distanceOffset;
        private Animator _animator;
        private BoyDie _boyDie;
        private Coroutine _followMovementRoutine;
        private AnimatorData _animatorData = new AnimatorData();

        private void Awake() 
        {
            _animator = GetComponent<Animator>();
            _boyDie = GetComponent<BoyDie>();
            _distanceOffset = 0.5f;
        }

        public void Perform(Transform targetPosition)
        {
            _destinationSetter.target = targetPosition;
            _followMovementRoutine = StartCoroutine(FollowMovement(targetPosition));
        }

        private IEnumerator FollowMovement(Transform targetPosition)
        {
            while (enabled)
            {
                if(Vector3.Distance(transform.position, targetPosition.position) < _distanceOffset)
                {
                    _animator.SetTrigger(_animatorData.Victory);

                    yield return new WaitForSeconds(_timeBeforeDeath);

                    StopCoroutine(_followMovementRoutine);
                    _boyDie.Perform();
                }

                yield return null;
            }
        }
    }
}