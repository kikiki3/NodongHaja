using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SmartPointShadowLimiter : MonoBehaviour
{
    public Transform cameraTransform;
    public int maxActiveShadowLights = 4;

    private List<Light> pointLights;

    void Start()
    {
        pointLights = FindObjectsOfType<Light>()
            .Where(l => l.type == LightType.Point)
            .ToList();
    }

    void Update()
    {
        var sorted = pointLights
            .OrderBy(l => Vector3.Distance(l.transform.position, cameraTransform.position))
            .ToList();

        for (int i = 0; i < sorted.Count; i++)
        {
            sorted[i].shadows = i < maxActiveShadowLights ? LightShadows.Soft : LightShadows.None;
        }
    }
}
