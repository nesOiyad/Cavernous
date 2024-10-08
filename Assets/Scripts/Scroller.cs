using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    private float offset;
    private Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
    void Update()
    {
        offset += Time.deltaTime*scrollSpeed/10f;
        mat.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
