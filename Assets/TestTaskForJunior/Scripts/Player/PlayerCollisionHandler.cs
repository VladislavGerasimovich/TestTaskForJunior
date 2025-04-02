using System.Collections;
using System.Collections.Generic;
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
                Debug.Log("trigger enter");
                _charactersCreator.Create();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Platform platform) == true)
            {
                Debug.Log("trigger exit");
                _charactersCreator.StopCreate();
            }
        }
    }
}