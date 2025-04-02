using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    public class CharactersCreator : MonoBehaviour
    {
        [SerializeField] private float _timeOfCreation;
        [SerializeField] private BoyMovement _boy;
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private Transform _targetPosition;

        private Coroutine _createRoutine;

        public void Create()
        {
            _createRoutine = StartCoroutine(CreateCharacter());
        }

        public void StopCreate()
        {
            if (_createRoutine != null)
            {
                StopCoroutine(_createRoutine);
                _createRoutine = null;
            }
        }

        private IEnumerator CreateCharacter()
        {
            float duration = 0;

            while (enabled)
            {
                duration += Time.deltaTime;

                if (duration > _timeOfCreation)
                {
                    BoyMovement boymovement = Instantiate(_boy, _spawnPosition.position, Quaternion.identity);
                    boymovement.Perform(_targetPosition);
                    StopCreate();
                }

                yield return null;
            }
        }
    }
}