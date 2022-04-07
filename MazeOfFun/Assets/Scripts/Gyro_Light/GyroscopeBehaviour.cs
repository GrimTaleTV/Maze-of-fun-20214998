using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GyroscopeBehaviour : MonoBehaviour
{

    private bool GyroEnabled;
    private UnityEngine.Gyroscope Gyro;

    public float rollSpeed = 10;
    float maxAngle = 35;

    private Quaternion rot;

    // Start is called before the first frame update
    void Start()
    {
        GyroEnabled = EnabledGyro();
    }

    private bool EnabledGryo()
    {
        if (SystemInfo.supportGyroscope)
        {
            Gyro = Input.gyro;
            Gyro.enabled = true;
            return true;
        }

        return false;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 rotation = new Vector3(); ;
        rotation.x = Gyro.attitude.rot.x * maxAngle;
        rotation.y = Gyro.attitude.rot.y * maxAngle;

        transform.eulerAngles = rotation;
    }
}
