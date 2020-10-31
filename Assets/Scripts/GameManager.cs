using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Canvas canvas;
    public static GameManager gm;
    public Transform playerPefab;
    public Transform spawnPoint;
    public int spawnDelay = 1;
    //public GameObject endGamePanel;
    //public Transform spawnPrefab;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(canvas);
        if (gm == null)
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    //public IEnumerator RespawnPlayer()
    //{

    //    yield return new WaitForSeconds(spawnDelay);

    //    Instantiate(playerPefab, spawnPoint.position, spawnPoint.rotation);
    //    //Transform cloneSpawn = Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation);
    //    //Destroy(cloneSpawn.gameObject, 3f);

    //}

    //public static void KillPlayer(PlayerController player)
    //{
    //    Destroy(player.gameObject);
    //    //gm.StartCoroutine(gm.RespawnPlayer());
    //}

    public void RespawnPlayer()
    {
        SceneManager.LoadScene("Scene1");
        //Instantiate(playerPefab, spawnPoint.position, spawnPoint.rotation);
        //endGamePanel.SetActive(false);
    }

    public void Destroy()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            Destroy(o);
        }
    }
}
