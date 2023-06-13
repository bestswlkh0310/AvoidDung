using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class DungCreateManager : MonoBehaviour
{
    public GameObject _dung;
    
    public float _rangeCreateDungPos;
    public float _createDungYPos;
    
    public float _createTimeRate = 0.3f;
    private float _beforeCreateTime;
    private float CREATE_TIME_RATE;
    
    private static int _stage = 1;

    public float _nextStageTimeRate = 10.0f;
    private float NEXT_STAGE_TIME_RATE;

    private void OnValidate()
    {
        _stage = 1;
        // _createTimeRate = CREATE_TIME_RATE;
        // _nextStageTimeRate = NEXT_STAGE_TIME_RATE;
    }
    private void Start()
    {
        CREATE_TIME_RATE = _createTimeRate;
        NEXT_STAGE_TIME_RATE = _nextStageTimeRate;
        StartCoroutine(UpdateStage());
    }

    public TextMeshProUGUI stageText;

    private void Update() {
        if (PlayerController.IsGameOver == false)
        {
            CreateDung();
        }
    }

    private void CreateDung() {
        _beforeCreateTime += Time.deltaTime;
        if (_beforeCreateTime > _createTimeRate) {
            for (int i = 0; i < _stage * 2; i++)
            {
                Vector3 randomPos = new Vector3(Random.Range(-_rangeCreateDungPos, _rangeCreateDungPos), _createDungYPos,
                    Random.Range(-_rangeCreateDungPos, _rangeCreateDungPos));
                GameObject dung = Instantiate(_dung);

                dung.transform.position = randomPos;

                _beforeCreateTime = 0.0f;
            }
        }
    }

    private IEnumerator UpdateStage()
    {
        while (_stage < 1000)
        {
            stageText.text = "Stage " + _stage;
            yield return new WaitForSeconds(_nextStageTimeRate);
            _nextStageTimeRate *= 1.2f;
            _stage++;
        }
    }
}
