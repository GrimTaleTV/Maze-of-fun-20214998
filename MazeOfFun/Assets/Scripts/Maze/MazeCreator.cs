using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MazeCreator : MonoBehaviour
{
    LightSensor lightSensor = LightSensor.current;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(LightSensor.current.lightLevel.scaleFactor);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(lightSensor.lightLevel.scaleFactor);
    }
}
