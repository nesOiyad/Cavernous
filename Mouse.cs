using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
  public GameObject crosshair;
  void Start()
  {
    Cursor.visible = false;
  }
  void Update()
  {
    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    transform.position = mousePos;
  }
}
