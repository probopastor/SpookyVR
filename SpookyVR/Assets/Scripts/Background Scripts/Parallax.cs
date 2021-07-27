using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform[] backgroundObjects;
    private float[] parallaxScales;
    [SerializeField] private float smoothing = 1f;
    private Transform cameraTransform;

    private Vector3 previousCamPos;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        previousCamPos = cameraTransform.position;
        parallaxScales = new float[backgroundObjects.Length];

        for (int i = 0; i < backgroundObjects.Length; i++)
        {
            parallaxScales[i] = backgroundObjects[i].position.x * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ParallaxObjects();
    }

    private void ParallaxObjects()
    {
        for (int i = 0; i < backgroundObjects.Length; i++)
        {
            float parallax = (previousCamPos.z - cameraTransform.position.z) * parallaxScales[i];
            float backgroundTargetPosZ = backgroundObjects[i].transform.position.z + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundObjects[i].position.x, backgroundObjects[i].position.y, backgroundTargetPosZ);
            backgroundObjects[i].position = Vector3.Lerp(backgroundObjects[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }
        
        previousCamPos = cameraTransform.position;
    }
}
