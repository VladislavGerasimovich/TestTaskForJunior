using System.IO;
using UnityEngine;

namespace DataStorage
{
    public class JSONController : MonoBehaviour
    {
        public ScoreValue ScoreValue;

        public void Awake()
        {
            LoadField();
        }

        public void SaveField()
        {
            File.WriteAllText(Application.streamingAssetsPath + "/JSON.json", JsonUtility.ToJson(ScoreValue));
        }

        private void LoadField()
        {
            ScoreValue = JsonUtility.FromJson<ScoreValue>(File.ReadAllText(Application.streamingAssetsPath + "/JSON.json"));
        }
    }
}