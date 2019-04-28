using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float assetsPixelPerUnit;
    public float pixelPerUnitScaling;
    public float verticalResolution;

    // Start is called before the first frame update
    void Start()
    {
        CalculateOrthographicSize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CalculateOrthographicSize()
    {
        Camera.main.orthographicSize = (verticalResolution / (pixelPerUnitScaling * assetsPixelPerUnit)) * 0.5f;
    }
}
