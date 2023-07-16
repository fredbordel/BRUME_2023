using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDying : MonoBehaviour
{

private bool isCollinding = false;
public GameData hello;

void Update()
{
if (isCollinding) 
{
    killFire();
}
}

private void OnTriggerEnter2D(Collider2D collision)
{
   isCollinding = true;
  
}

private void killFire()
{
    float newScale = Mathf.Lerp(transform.localScale.x, 0, Time.deltaTime * 0.9f);
    transform.localScale = new Vector3(newScale, newScale, newScale);
}

}
