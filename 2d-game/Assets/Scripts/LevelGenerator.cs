using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float playerDistanceSpawnLevelPart = 100f;
    [SerializeField] private Transform levelPartStart;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private GameObject player;
    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = levelPartStart.Find("EndPosition").position;
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndPosition) < playerDistanceSpawnLevelPart)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform pickedLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPart = GetLevelPart(pickedLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPart.Find("EndPosition").position;
    }

    private Transform GetLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform LevelPart = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return LevelPart;
    }
}
