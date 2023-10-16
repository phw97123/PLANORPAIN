using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public static GroundManager GInstance;

    // ΩÃ±€≈Ê
    private void Awake()
    {
        if (GInstance == null)
        {
            GInstance = this;
        }
        else
        {
            if (GInstance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }


}
