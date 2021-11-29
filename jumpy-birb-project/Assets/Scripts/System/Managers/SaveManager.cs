using UnityEngine;

namespace JumpBirdGame
{
    public class SaveManager : MonoBehaviour
    {
        /* -------------------------------- Singleton ------------------------------- */

        public static SaveManager Instance
        {
            get => _instance;
        }

        private static SaveManager _instance;

        /* ------------------------------- Properties ------------------------------- */

        public bool HasSave
        {
            get => FileManager.FileExists(filename);
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] private string filename = "JumpyBirbSave.dat";

        /* ------------------------------ Unity Events ------------------------------ */

        private void Awake()
        {
            _instance = this;
        }

        /* --------------------------------- Saving --------------------------------- */

        public void Save(SaveData data)
        {
            bool successfullySaved = FileManager.WriteToFile(filename, data.ToJson());
            if (successfullySaved)
            {
                Debug.Log($"Saved {typeof(SaveData)} to file {filename}");
            }
            else
            {
                Debug.LogError($"Error ({this.name}): Failed to save {typeof(SaveData)} to file \"{filename}\".");
            }
        }

        public SaveData Load()
        {
            if(!FileManager.FileExists(filename))
            {
                Debug.LogWarning($"Log ({this.name}): Unable to load {typeof(SaveData)} from file \"{filename}\" as the file does not exist.");
                return null;
            }

            bool successfullyLoaded = FileManager.LoadFromFile(filename, out var json);
            if (successfullyLoaded)
            {
                SaveData data = new SaveData();
                data.LoadFromJson(json);
                Debug.Log($"Loaded {typeof(SaveData)} from file {filename}");
                return data;
            }
            else
            {
                Debug.LogWarning($"Warning ({this.name}): Failed to load {typeof(SaveData)} from file \"{filename}\".");
                return null;
            }
        }

        /* -------------------------------------------------------------------------- */
    }
}