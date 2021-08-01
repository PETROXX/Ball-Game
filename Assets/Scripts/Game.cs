using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private float _restartCooldown = 3f;

    public IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(_restartCooldown);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
