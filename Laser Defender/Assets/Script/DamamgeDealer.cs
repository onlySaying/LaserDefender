using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamamgeDealer : MonoBehaviour
{
   [SerializeField] int damage = 10;

    public int getDmg()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
