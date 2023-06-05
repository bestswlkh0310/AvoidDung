using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungCreateManager : MonoBehaviour
{
    public GameObject _dung;
    public float _createRateTime = 0.3f;
    private float _beforeTime = 0.0f;
    public float _rangeCreateDungPos;
    public float _createDungYPos;
    
    private void Update() {
        if (PlayerController.isGameOver == false)
        {
            CreateDung();
        }
    }

    private void CreateDung() {
        _beforeTime += Time.deltaTime;

        if (_beforeTime > _createRateTime) {
            Vector3 randomPos = new Vector3(Random.Range(-_rangeCreateDungPos, _rangeCreateDungPos), _createDungYPos,
                Random.Range(-_rangeCreateDungPos, _rangeCreateDungPos));
            GameObject dung = Instantiate(_dung);

            dung.transform.position = randomPos;

            _beforeTime = 0.0f;
        }
    }
}
