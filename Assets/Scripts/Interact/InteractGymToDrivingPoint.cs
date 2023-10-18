using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractGymToDrivingPoint : MonoBehaviour, IInteractable
{
    [SerializeField] private MiniGameUI _miniGameUI;
    private Outline _outline;
    private int _selector = -1;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
    }

    public void BlickOutLine()
    {
        StartCoroutine(BlinkOutlingCO());
    }

    IEnumerator BlinkOutlingCO()
    {
        _outline.OutlineWidth = 6f;

        yield return new WaitForSecondsRealtime(2f);

        _outline.OutlineWidth = 0f;
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Player")){
            _outline.OutlineWidth = 6f;
            _miniGameUI.selector = _selector;
            _miniGameUI.isInterct = true;
            this.gameObject.transform.rotation = Quaternion.Euler(0, 90f, 0);
        }
    }

    public void OnCollisionExit(Collision collision)
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
        SceneManager.LoadScene("DrivingScene");
    }
}
