using UnityEngine;

public class ShadowLOD : MonoBehaviour
{
    public Light targetLight;
    public Transform cameraTransform;
    public float shadowEnableDistance = 20f;

    void Update()
    {
        if (targetLight == null || cameraTransform == null) return;

        float dist = Vector3.Distance(transform.position, cameraTransform.position);
        targetLight.shadows = dist <= shadowEnableDistance ? LightShadows.Soft : LightShadows.None;
    }
}
