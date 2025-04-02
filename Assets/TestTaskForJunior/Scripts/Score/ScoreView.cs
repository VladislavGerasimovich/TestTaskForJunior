using UnityEngine;
using TMPro;
using DataStorage;

namespace Score
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private JSONController _jsonController;

        private TMP_Text _text;
        private int _value;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            _value = _jsonController.ScoreValue.Value;
            PlayerPrefs.SetInt(Constants.Score, _jsonController.ScoreValue.Value);
            int score = PlayerPrefs.GetInt(Constants.Score);
            _text.text = score.ToString();
        }

        private void OnDisable()
        {
            _jsonController.ScoreValue.Set(_value);
            PlayerPrefs.SetInt(Constants.Score, _jsonController.ScoreValue.Value);
            _jsonController.SaveField();
        }

        public void Increase()
        {
            _value++;
            _text.text = _value.ToString();
        }
    }
}