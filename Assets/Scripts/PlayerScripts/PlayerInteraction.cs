using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public event Action<WeaponStore> OnWeaponStoreEnter;
    public event Action<WeaponStore> OnWeaponStoreExit;

    private void OnTriggerEnter(Collider other)
    {
        WeaponStore weaponStore = other.GetComponent<WeaponStore>();
        if (weaponStore != null)
        {
            OnWeaponStoreEnter?.Invoke(weaponStore);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        WeaponStore weaponStore = other.GetComponent<WeaponStore>();
        if (weaponStore != null)
        {
            OnWeaponStoreExit?.Invoke(weaponStore);
        }
    }
}
