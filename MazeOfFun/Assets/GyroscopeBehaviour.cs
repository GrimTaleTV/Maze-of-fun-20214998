using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GyroscopeBehaviour : MonoBehaviour
{

    private bool gyroEnabled;
    private UnityEngine.InputSystem.Gyroscope gyro;

    float MaxAngle = 35;

    private Quaternion quatRot;

    // Start is called before the first frame update
    void Start()
    {
        gyroEnabled = EnabledGryo();
    }

    private bool EnabledGryo()
    {
        if (UnityEngine.InputSystem.Gyroscope.current != null)
        {
            gyro = UnityEngine.InputSystem.Gyroscope.current;
            InputSystem.EnableDevice(gyro);
            return true;
        }

        if(GravitySensor.current != null)
        {
            InputSystem.EnableDevice(GravitySensor.current);
        }

        return false;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 rotation = new Vector3(); ;
        rotation.x = GravitySensor.current.gravity.ReadValue().x * MaxAngle;
        rotation.y = GravitySensor.current.gravity.ReadValue().y * MaxAngle;

        transform.eulerAngles = rotation;
    }
}
