using UnityEngine;

public class OutdoorGameManager : MonoBehaviour
{
    [SerializeField] private IntVariable _starAmount;

    private void Awake()
    {
        _starAmount.value = 0;
    }
}
