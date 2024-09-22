using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BulletProjectorHelper
{
    private readonly BulletProjectorData[] _bulletHoles;

    public BulletProjectorHelper(BulletProjectorData[] bulletHoles)
    {
        _bulletHoles = bulletHoles;
    }

    public void CreateBulletHole(Vector3 point, Vector3 normal, Transform parent)
    {
        BulletProjectorData data = _bulletHoles[Random.Range(0, _bulletHoles.Length)];
        Transform hole = CreateHole(point, normal, parent, data);
        CreateLight(hole, data);
    }

    private Transform CreateHole(Vector3 point, Vector3 normal, Transform parent, BulletProjectorData data)
    {
        const float size = 0.1f;
        DecalProjector projector = new GameObject("BulletHole").AddComponent<DecalProjector>();
        projector.transform.position = point;
        projector.transform.rotation = Quaternion.FromToRotation(-Vector3.forward, normal);
        Vector3 angles = projector!.transform.eulerAngles;
        projector.transform.rotation = Quaternion.Euler(angles.x, angles.y, Random.Range(0, 360));
        projector.transform.SetParent(parent);

        projector.size = new Vector3(size, size, size);
        projector.material = data.Material;
        projector.pivot = Vector3.zero;

        return projector.transform;
    }

    private void CreateLight(Transform hole, BulletProjectorData data)
    {
        Light light = new GameObject("LightHole").AddComponent<Light>();
        light.type = LightType.Spot;
        light.transform.SetParent(hole);
        light!.transform.localPosition = new Vector3(0.0f, 0.0f, -0.3f);
        light.range = data.LightRange;
        light.intensity = data.LightIntensity;
        light.innerSpotAngle = data.LightInnerSpotAngle;
        light.spotAngle = data.LightSpotAngle;
    }
}
    

