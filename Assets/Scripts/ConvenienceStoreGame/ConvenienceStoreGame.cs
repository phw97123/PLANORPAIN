using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using System;

public class ConvenienceStoreGame : MonoBehaviour
{
    [SerializeField] private GameObject riceBall;

    public GameObject Player;
    public bool isWithinNPCZone;

    public bool isEating;
    public float eatingRate = 5.0f;

    public event Action<string> PopupUI;
    //public event Action PopupGameOverUI; cctv����� ����

    private int _score = 3;
    private int _progress = 0; //Ƚ�� 5������ �ø���
    private Renderer _riceBallRenderer;
    private Material[] _riceBallMaterials;

    private static ConvenienceStoreGame _instance;

    public static ConvenienceStoreGame Instance
    {
        get
        {
            if (_instance != null) { return _instance; }

            _instance = FindObjectOfType<ConvenienceStoreGame>();
            if (_instance != null) { return _instance; }

            _instance = new GameObject(nameof(ConvenienceStoreGame)).AddComponent<ConvenienceStoreGame>();
            return _instance;
        }
    }

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        _riceBallRenderer = riceBall.GetComponent<Renderer>();
        _riceBallRenderer.enabled = true;

        _riceBallMaterials = new Material[2];
        _riceBallMaterials[0] = Resources.Load<Material>("Materials/Base_Color2");
        _riceBallMaterials[1] = Resources.Load<Material>("Materials/Base_Color3");
    }
    private void Update()
    {
        CheckClickRiceBall();
    }

    private void CheckClickRiceBall() 
    {
        if (Time.timeScale > 0 && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(isEating)
                {
                    PopupUI?.Invoke("���� �ð� �ֽ��ϴ�");
                    return;
                }

                if (hit.transform.name == riceBall.name)
                {
                    isEating = true;
                    Invoke("OnCanEating", eatingRate);
                    if(isWithinNPCZone)
                    {
                        PopupUI?.Invoke("�մ��� �ν������ �Ҹ��� ������ϴ�");
                        _score--;
                    }
                    ChangeRiceBallModel();
                    Debug.Log(_score);
                }
            }
        }
    }

    private void OnCanEating()
    {
        isEating = false;
    }

    private void ChangeRiceBallModel()
    {
        if(_progress == 2)
        {
            PopupUI?.Invoke("�ﰢ����� �� �Ծ����ϴ�");
            // ���� ���� �����ϰ�
            // ���� ������ �Ѿ��
        }
        else
        {
            _riceBallRenderer.sharedMaterial = _riceBallMaterials[_progress]; 
            Debug.Log(_riceBallMaterials[_progress]);

            _progress++;
        }
    }

}
