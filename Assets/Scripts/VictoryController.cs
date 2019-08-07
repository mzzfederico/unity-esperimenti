using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryController : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(35, 10, 20) * Time.deltaTime);
    }
}
