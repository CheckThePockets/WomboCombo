using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
   

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(1000, 650 + Mathf.Sin(Time.time*10)*30, 0);
    }
}
