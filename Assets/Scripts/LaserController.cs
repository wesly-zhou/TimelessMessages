using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserController : MonoBehaviour
{
    private LineRenderer linerenderer;
    private float time;
    private float InitAngle;
    [SerializeField] private ParticleSystem EmissionPoint;
    [SerializeField] private GameObject startVFX;
    [SerializeField] private GameObject endVFX;
    // Control the rotation of the Launcher
    [SerializeField] private bool Rotation;
    [SerializeField] private float RotationPeriod;
    [SerializeField] private float RotationAngle;
    
    // Start is called before the first frame update
    void Start()
    {
        linerenderer = GetComponentInChildren<LineRenderer>();
        linerenderer.enabled = true;
        linerenderer.SetPosition(1, new Vector3(1, 0, 0));
        InitAngle = transform.rotation.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStartPosition();
        UpdateEndPosition();
        if (Rotation) RotateLauncher();
        
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
            if(hit.transform.gameObject.name.Equals("Player")){
                GameManager.DeathNum[SceneManager.GetActiveScene().name] += 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        
        // linerenderer.SetPosition(1, new Vector3(length, 0, 0));

        Vector2 endPosition = StartPosition + direction * length;
        startVFX.transform.position = StartPosition;
        endVFX.transform.position = endPosition;
        endVFX.transform.rotation = Quaternion.Euler(0, 0, laserEndRotation);
        linerenderer.SetPosition(1, endVFX.transform.position);

        
    }

    private void RotateLauncher()
    {
        if(RotationPeriod == 0) return;
        time += Time.deltaTime; 
        float angle = RotationAngle * Mathf.Sin(2 * Mathf.PI * time / RotationPeriod); 
        transform.rotation = Quaternion.Euler(0, 0, InitAngle + angle);
    }
}
