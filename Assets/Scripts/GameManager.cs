using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Canvas canvas;
    public static GameManager gm;
    public Transform playerPefab;
    public Transform spawnPoint;
    public int spawnDelay = 1;
    //public Transform spawnPrefab;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(canvas);
        if (gm == null)
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    public IEnumerator RespawnPlayer()
    {

        yield return new WaitForSeconds(spawnDelay);

        Instantiate(playerPefab, spawnPoint.position, spawnPoint.rotation);
        //Transform cloneSpawn = Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation);
        //Destroy(cloneSpawn.gameObject, 3f);

    }
    public static void KillPlayer(PlayerController player)
    {
        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());
    }

}
