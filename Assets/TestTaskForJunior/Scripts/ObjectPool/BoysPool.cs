using Characters;
using Score;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ObjectPool
{
    public class BoysPool : MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private int _capacity;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private ScoreView _scoreView;

        private List<GameObject> _pool;

        private void Awake()
        {
            Init();
        }

        public bool TryGet(out GameObject result)
        {
            result = _pool.FirstOrDefault(p => p.activeSelf == false);
            return result != null;
        }

        public void Init()
        {
            _pool = new List<GameObject>();

            for (int i = 0; i < _capacity; i++)
            {
                GameObject item = Instantiate(_prefab, _container.transform);
                item.SetActive(false);
                BoyDie boyDie = item.GetComponent<BoyDie>();
                boyDie.Init(_scoreView);
                _pool.Add(item);
            }
        }
    }
}