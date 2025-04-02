using ObjectPool;
using Score;
using System.Collections;
using UnityEngine;

namespace Characters
{
    public class CharactersCreator : MonoBehaviour
    {
        [SerializeField] private float _timeOfCreation;
        [SerializeField] private BoyMovement _boy;
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private Transform _targetPosition;
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private BoysPool _boysPool;

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
                    if(_boysPool.TryGet(out GameObject gameObject) == true)
                    {
                        gameObject.SetActive(true);
                        gameObject.transform.position = _spawnPosition.position;
                        BoyMovement boyMovement = gameObject.GetComponent<BoyMovement>();
                        boyMovement.Perform(_targetPosition);
                    }

                    StopCreate();
                }

                yield return null;
            }
        }
    }
}