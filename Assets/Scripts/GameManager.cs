using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton instance untuk GameManager
    public static GameManager Instance { get; private set; }
    
    // Referensi ke LevelManager
    public LevelManager LevelManager { get; private set; }

    private void Awake()
    {
        // Singleton pattern: memastikan hanya ada satu instance GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Mendapatkan referensi ke LevelManager
        LevelManager = FindObjectOfType<LevelManager>();

        // Menghilangkan semua objek kecuali Camera dan Player
        foreach (GameObject obj in FindObjectsOfType<GameObject>())
        {
            if (obj.CompareTag("MainCamera") || obj.CompareTag("Player"))
                continue;

            Destroy(obj);
        }
    }
}
