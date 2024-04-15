using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
   

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(550, 700 + Mathf.Sin(Time.time)*25, 0);
    }
}
