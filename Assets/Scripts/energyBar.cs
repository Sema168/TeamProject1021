using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyBay : MonoBehaviour
{
    Slider _slider;
    void Start()
    {
        // �X���C�_�[���擾����
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    float _Energy = 0;
    void Update()
    {
        // �G�l���M�[�㏸
        _Energy += 0.01f;
        if (_Energy > 1)
        {
            // �ő�𒴂�����0�ɖ߂�
            _Energy = 0;
        }

        // �G�l���M�[�Q�[�W�ɒl��ݒ�
        _slider.value = _Energy;
    }
}
