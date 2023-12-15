using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRecorder : MonoBehaviour
{
    public float timePlayed = 0.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        timePlayed += Time.deltaTime;

    }
}
