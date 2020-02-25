using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.SceneManagement;

public class EndLevelLogic : MonoBehaviour
{
    public GameEvent endLevelGE;
    public float timeToNextLevel = 0.2f;
    private AsyncOperation loadOp;
    private const string doorTag = "DoorTag";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DoorTag"))
        {
            loadOp = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
            loadOp.allowSceneActivation = false;
            endLevelGE.Raise();
            Invoke("NextLevel", timeToNextLevel);
        }
    }

    private void NextLevel()
    {
        loadOp.allowSceneActivation = true;
    }
}
