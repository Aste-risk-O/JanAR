using System;
using System.Collections;
using Google.XR.ARCoreExtensions;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro; // Используем TextMeshPro для красоты

public class AutoSpawnDirector : MonoBehaviour
{
    [Header("AR Components")]
    public AREarthManager EarthManager;
    public ARAnchorManager AnchorManager;

    [Header("UI")]
    public TMP_Text StatusText; // Ссылка на текст в центре экрана

    [Header("Settings")]
    public GameObject ContentPrefab; // Твой префаб Bai-Fin
    public double Latitude = 51.128302; // Твои координаты
    public double Longitude = 71.430531;
    public double Altitude = 0;
    public double Heading = 0;
    public bool ForcePutOnTerrain = true; // Как в твоем рабочем скрипте

    private bool isSpawned = false;
    private float stableTimer = 0f;
    private float spawnDelay = 3.0f; // Задержка 3 секунды

    void Update()
    {
        if (isSpawned) return;

        // Проверка готовности AR
        if (EarthManager.EarthTrackingState != TrackingState.Tracking)
        {
            StatusText.text = "Waiting for GPS...";
            StatusText.color = Color.red;
            return;
        }

        var pose = EarthManager.CameraGeospatialPose;

        // Проверка точность (как в твоем скрипте: < 25 и < 20)
        // Но для надежности лучше брать поменьше, например 10 и 5
        if (pose.OrientationYawAccuracy < 20 && pose.HorizontalAccuracy < 10)
        {
            stableTimer += Time.deltaTime;
            float timeLeft = spawnDelay - stableTimer;

            StatusText.text = $"High Accuracy!\nSpawn in: {Mathf.Ceil(timeLeft)}";
            StatusText.color = Color.green;

            if (stableTimer >= spawnDelay)
            {
                SpawnObject();
            }
        }
        else
        {
            stableTimer = 0;
            StatusText.text = "Low Accuracy.\nLook around buildings.";
            StatusText.color = Color.yellow;
        }
    }

    void SpawnObject()
    {
        Quaternion quaternion = Quaternion.AngleAxis(180f - (float)Heading, Vector3.up);

        if (ForcePutOnTerrain)
        {
            ResolveAnchorOnTerrainPromise terrainPromise =
                AnchorManager.ResolveAnchorOnTerrainAsync(Latitude, Longitude, 0, quaternion);
            StartCoroutine(CheckTerrainPromise(terrainPromise));
        }
        else
        {
            ARGeospatialAnchor anchor = AnchorManager.AddAnchor(Latitude, Longitude, Altitude, quaternion);
            if (anchor != null)
            {
                FinalizeSpawn(anchor.transform);
            }
        }
    }

    private IEnumerator CheckTerrainPromise(ResolveAnchorOnTerrainPromise promise)
    {
        while (promise.State == PromiseState.Pending)
        {
            yield return new WaitForSeconds(0.1f);
        }

        var result = promise.Result;
        if (result.TerrainAnchorState == TerrainAnchorState.Success && result.Anchor != null)
        {
            FinalizeSpawn(result.Anchor.gameObject.transform);
        }
    }

    void FinalizeSpawn(Transform anchorTransform)
    {
        Instantiate(ContentPrefab, anchorTransform);
        isSpawned = true;

        // Убираем текст, чтобы не мешал просмотру
        StatusText.gameObject.SetActive(false);
    }
}
