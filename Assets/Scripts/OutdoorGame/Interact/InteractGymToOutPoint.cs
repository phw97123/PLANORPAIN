using UnityEngine;

public class InteractGymToOutPoint : MonoBehaviour, IInteractable
{
    [SerializeField] private IntVariable _starAmount;
    [SerializeField] private GymMiniGameUI _miniGameUI;
    private Outline _outline;
    private int _selector = -1;
    private bool _isInteract = false;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
    }

    public void MakeOutLine()
    {
        _outline.OutlineWidth = 6f;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Player")){
            _outline.OutlineWidth = 6f;
            _miniGameUI.selector = _selector;
            _miniGameUI.isInterct = true;
            this.gameObject.transform.rotation = Quaternion.Euler(0, 90f, 0);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            _outline.OutlineWidth = 0f;
            _miniGameUI.isInterct = false;
            this.gameObject.transform.rotation = Quaternion.identity;
        }
    }

    public void OnInteract()
    {
        if (!_isInteract)
        {
            UI_GameEndPopup endPopup = UIManager.Instance.GetUIComponent<UI_GameEndPopup>();

            int value = _starAmount.value <= 3 ? _starAmount.value : 3;
            endPopup.SetScore(value);
            endPopup.ShowPopup();
            _isInteract = true;
        }
    }
}
