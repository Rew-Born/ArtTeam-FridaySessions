using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendWorldPosToMaterial : MonoBehaviour
{
    public Material material;

    void Update()
    {
        material.SetVector("_WorldPos", transform.position);
    }
}
