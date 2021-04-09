using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelGeneratorBase : MonoBehaviour
{
    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        
    }

    protected abstract void GenerateLevelPart();
}
