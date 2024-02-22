using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    byte Health { get; } 
    void Damage (byte damage);
}
