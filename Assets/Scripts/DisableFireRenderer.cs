using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableFireRenderer : MonoBehaviour
{

public FireGroupState fireGroup;
private SpriteRenderer someSprite;

void Start()
{
    someSprite = GetComponent<SpriteRenderer>();
}

void Update()
{
    if (!fireGroup.isFireGroupVisibleOne)
    {
        someSprite.enabled = false;
    }
}
}
