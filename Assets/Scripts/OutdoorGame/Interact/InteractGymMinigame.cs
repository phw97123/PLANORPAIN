using System.Collections;
using UnityEngine;

public class InteractGymMinigame : MonoBehaviour
{
    [SerializeField] private GymMiniGameUI _miniGameUI;
    [SerializeField] private int _miniGameSelect;
    private Outline _outline;
    private bool _isInteract = false;
    private Coroutine _coroutine;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
    }

    private void Start()
    {
        _coroutine = StartCoroutine(BlinkOutlingCO());
    }

    IEnumerator BlinkOutlingCO()
    {
        _outline.OutlineWidth = 6f;

        yield return new WaitForSecondsRealtime(2f);

        _outline.OutlineWidth = 0f;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (!_isInteract)
            {
                if (_coroutine != null)
                    StopCoroutine(_coroutine);
                _outline.OutlineWidth = 6f;
                _miniGameUI.isInterct = true;
                _miniGameUI.selector = _miniGameSelect;
                _miniGameUI.SetInteractGymMinigame(this);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            _outline.OutlineWidth = 0f;
            _miniGameUI.isInterct = false;
        }
    }

    public void SetInteract(bool isinteract)
    {
        _isInteract = isinteract;
    }

    public void SetOutlineWidth(float value)
    {
        _outline.OutlineWidth = value;
    }
}
