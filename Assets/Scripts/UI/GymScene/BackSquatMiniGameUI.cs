using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BackSquatMiniGameUI : MonoBehaviour
{
    public IntVariable startAmount;

    [SerializeField] private GameObject _miniGameUI;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _playerHand;
    [SerializeField] private GameObject _gymObject;
    [SerializeField] private GameObject _backSquatCamera;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private AnimatorController _animPlayerController;
    [SerializeField] private AnimatorController _animBackSquartController;
    [SerializeField] private Image _gaugeImage;
    [SerializeField] private Image _hitPointImage;
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private TMP_Text _countText;
    [SerializeField] private TMP_Text _StartText;
    [SerializeField] private TMP_Text _SpaceText;
    [SerializeField] private TMP_Text _ScheduleText;

    private Vector3 _originPlayerPosition;
    private Quaternion _originPlayerQuaternion;
    private Vector3 _originObjPosition;
    private int _gaugeAmount = 1;
    private int _hitPointAmount = 20;
    private int _timeCount = 60;
    private int _count = 0;
    private int _maxCount = 5;
    private float _startDelayTime = 12f;
    private float _failDelayTime = 2f;
    private bool _isHit = true;
    private Color _originSpaceTextColor;

    private void Start()
    {
        _originObjPosition = _gymObject.transform.position;
        _timeText.text = $"{_timeCount} s";
        _countText.text = $"{_count} / {_maxCount}";
        _originSpaceTextColor = _SpaceText.color;
    }

    public void StartMiniGame()
    {
        _gaugeAmount = 1;
        _hitPointAmount = 20;
        _timeCount = 60;
        _count = 0;

        _player.GetComponent<PlayerInput>().enabled = false;
        _gymObject.GetComponent<Collider>().enabled = false;

        _backSquatCamera.SetActive(true);
        _miniGameUI.SetActive(true);

        _playerAnimator.runtimeAnimatorController = _animBackSquartController;

        _originPlayerPosition = _player.transform.position;
        _originPlayerQuaternion = _player.transform.rotation;
        _player.transform.position = new Vector3(_gymObject.transform.position.x, 0, _gymObject.transform.position.z);
        _player.transform.rotation = Quaternion.Euler(Vector3.zero);
        _playerAnimator.SetBool("IsBackSquatStart", true);
        StartCoroutine(FollowPlayerHandCO());
        StartCoroutine(TimeCountDownCO());
        StartCoroutine(GaugeImageChangeCO());
    }

    public void EndMiniGame()
    {
        if (_count >= _maxCount)
        {
            startAmount.value += 1;
            _ScheduleText.color = Color.gray;
            _ScheduleText.fontStyle = FontStyles.Strikethrough;
        }

        _playerAnimator.runtimeAnimatorController = _animPlayerController;

        _player.transform.position = _originPlayerPosition;
        _player.transform.rotation = _originPlayerQuaternion;
        _gymObject.transform.position = _originObjPosition;

        StopAllCoroutines();

        _miniGameUI.SetActive(false);
        _backSquatCamera.SetActive(false);

        _player.GetComponent<PlayerInput>().enabled = true;
    }

    public void OnHitGauge(InputAction.CallbackContext context)
    {
        if (!_isHit)
            if (context.phase == InputActionPhase.Started)
            {
                if(_gaugeAmount >= (100 - _hitPointAmount))
                {
                    StartCoroutine(SuccessHitCO());
                }
                else
                {
                    StartCoroutine(FailHitCO());
                }
            }
    }

    IEnumerator SuccessHitCO()
    {
        _isHit = true;
        _SpaceText.color = Color.green;

        _playerAnimator.ResetTrigger("Fail");
        _playerAnimator.SetTrigger("Success");

        SoundManager.Instance.Play("OutdoorGame/BackSquat_01",AudioType.EFFECT, 0.2f);

        _count += 1;
        if (_count >= _maxCount)
            _countText.color = Color.green;

        _countText.text = $"{_count} / {_maxCount}";

        yield return new WaitForSecondsRealtime(0.5f);

        _SpaceText.color = _originSpaceTextColor;
        _gaugeAmount = 1;
        _gaugeImage.fillAmount = (float)_gaugeAmount * 0.01f;

        if(_hitPointAmount > 4)
        {
            _hitPointAmount += -2;
            _hitPointImage.fillAmount = (float)_hitPointAmount * 0.05f;
        }

        _isHit = false;
    }

    IEnumerator FailHitCO()
    {
        _isHit = true;
        _SpaceText.color = Color.red;

        _playerAnimator.SetTrigger("Fail");

        SoundManager.Instance.Play("OutdoorGame/Fail", AudioType.EFFECT, 0.5f);

        yield return new WaitForSecondsRealtime(_failDelayTime);

        _SpaceText.color = _originSpaceTextColor;
        _gaugeAmount = 1;
        _gaugeImage.fillAmount = (float)_gaugeAmount * 0.01f;

        _isHit = false;
    }

    IEnumerator FollowPlayerHandCO()
    {
        yield return new WaitForSecondsRealtime(2f);
        while (true)
        {
            _gymObject.transform.position = _playerHand.transform.position;
            _gymObject.transform.position += new Vector3(-0.2f, 0, 0);
            yield return null;
        }
    }

    IEnumerator TimeCountDownCO()
    {
        yield return new WaitForSecondsRealtime(_startDelayTime);

        _timeText.gameObject.SetActive(false);
        _StartText.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(1f);

        _timeText.gameObject.SetActive(true);
        _StartText.gameObject.SetActive(false);
        _isHit = false;

        while (_timeCount >= 0)
        {
            yield return new WaitForSecondsRealtime(1f);
            _timeCount += -1;
            _timeText.text = $"{_timeCount} s";

            if (_timeCount <= 0)
            {
                _isHit = true;
                StopCoroutine(GaugeImageChangeCO());
                yield return new WaitForSecondsRealtime(2f);
                _timeText.text = "END";
                yield return new WaitForSecondsRealtime(2f);
                EndMiniGame();
            }
        }
    }

    IEnumerator GaugeImageChangeCO()
    {
        bool isUp = true;
        yield return new WaitForSecondsRealtime(_startDelayTime);
        while (true)
        {
            if (!_isHit)
            {
                if (isUp)
                    _gaugeAmount += 1;
                else
                    _gaugeAmount += -1;

                if (_gaugeAmount <= 1)
                    isUp = true;
                if (_gaugeAmount == 100)
                    isUp = false;

                _gaugeImage.fillAmount = (float)_gaugeAmount * 0.01f;

                yield return new WaitForSecondsRealtime(Time.deltaTime);
            }
            yield return null;
        }
    }
}
