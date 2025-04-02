using UnityEngine;
using CollisionPlatform;
using Characters;

namespace Player
{
    public class PlayerCollisionHandler : MonoBehaviour
    {
        [SerializeField] private CharactersCreator _charactersCreator;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Platform platform) == true)
            {
                _charactersCreator.Create();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Platform platform) == true)
            {
                _charactersCreator.StopCreate();
            }
        }
    }
}