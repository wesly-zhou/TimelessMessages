using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using Unity.Mathematics;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    private LineRenderer linerenderer;
    [SerializeField] private ParticleSystem EmissionPoint;
    [SerializeField] private GameObject startVFX;
    [SerializeField] private GameObject endVFX;
    // Start is called before the first frame update
    void Start()
    {
        linerenderer = GetComponentInChildren<LineRenderer>();
        linerenderer.SetPosition(1, new Vector3(1, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStartPosition();
        UpdateEndPosition();
    }

    private void UpdateStartPosition()
    {
        linerenderer.SetPosition(0, EmissionPoint.transform.position);
        
    }
    private void UpdateEndPosition()
    {
        Vector2 StartPosition = EmissionPoint.transform.position;
        float rotationZ =  transform.rotation.eulerAngles.z; //degree
        rotationZ *= Mathf.Deg2Rad; //radian

        Vector2 direction = new Vector2(math.cos(rotationZ), math.sin(rotationZ));

        RaycastHit2D hit = Physics2D.Raycast(StartPosition, direction.normalized);

        float length = 100f;
        float laserEndRotation = 180;

        if (hit) {
            length = (hit.point - StartPosition).magnitude;
            laserEndRotation = hit.transform.rotation.eulerAngles.z;
        }
        
        // linerenderer.SetPosition(1, new Vector3(length, 0, 0));

        Vector2 endPosition = StartPosition + direction * length;
        startVFX.transform.position = StartPosition;
        endVFX.transform.position = endPosition;
        endVFX.transform.rotation = Quaternion.Euler(0, 0, laserEndRotation);
        linerenderer.SetPosition(1, endVFX.transform.position);

        
    }
}
