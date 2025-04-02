using Pathfinding;
using UnityEngine;

namespace Characters
{
    public class BoyMovement : MonoBehaviour
    {
        [SerializeField] private AIDestinationSetter _destinationSetter;

        public void Perform(Transform targetPosition)
        {
            _destinationSetter.target = targetPosition;
        }
    }
}