using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass : MonoBehaviour
{
    /// <summary>
    /// This is the BaseClass that needs to be overriden by the other character classes
    /// </summary>
    public String className = "Base";
    public float moveSpeed = 5;
    public float jumpPower = 8;
    public float baseGravity = 2;
    public float maxFallSpeed = 18;
    public float fallSpeedMultiplier = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Spell1() {
        throw new NotImplementedException();
    }

    public virtual void Spell2() {
        throw new NotImplementedException();
    }

    public virtual void Spell3() {
        throw new NotImplementedException();
    }

    public virtual void Spell4() {
        throw new NotImplementedException();
    }
}
