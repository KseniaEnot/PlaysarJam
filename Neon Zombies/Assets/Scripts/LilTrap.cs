using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LilTrap : MonoBehaviour
{
    public event Action<Collider> onLilTrapStay;
    private void OnTriggerStay(Collider other)
    {
        onLilTrapStay.Invoke(other);
    }

}
