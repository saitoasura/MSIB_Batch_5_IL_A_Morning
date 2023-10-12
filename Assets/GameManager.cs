//#define  OLD_CODE

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public CameraFollow camera;
    public CameraShake bossCamera;
    public GameObject boss;

    private void Awake()
    {
        Instance = this;
    }

    public void StartBossFight()
    {
        boss.SetActive(true);
    }

    public void SwitchCamera(GameObject obj, float duration)
    {
        camera.gameObject.SetActive(false);
        obj.SetActive(true);
        StartCoroutine(Delay());
        IEnumerator Delay()
        {
            yield return new WaitForSeconds(duration);
            camera.gameObject.SetActive(true);
            obj.SetActive(false);
        }
    }

    #region OLD CODE


#if OLD_CODE
    [SerializeField] private GameObject playerPrefabs;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int currentCheckpoint;
    public GameObject[] checkPoints;
    private GameObject player;


    private void SpawnPlayer()
    {
        if (player == null)
        {
            player =
 Instantiate(playerPrefabs, checkPoints[currentCheckpoint].transform.position, checkPoints[currentCheckpoint].transform.rotation);   
        }
        else
        {
            player.transform.position = checkPoints[currentCheckpoint].transform.position;
            player.transform.rotation = checkPoints[currentCheckpoint].transform.rotation;
        }
    }
    void Start()
    {
        Load();
    }

    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
        currentCheckpoint = 0;
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("CurrentCheckpoint"))
        {
            currentCheckpoint = PlayerPrefs.GetInt("CurrentCheckpoint");
        }
        SpawnPlayer();
    }

    public void RandomSpawn()
    {
        currentCheckpoint = Random.Range(0, 2);
        SpawnPlayer();
    }
#endif

    #endregion
}
