using UnityEngine;

/// <summary>
/// �����̊m�F�����邽�߂̃N���X
/// </summary>
public class TestScripts : MonoBehaviour
{
    /// <summary>
    /// ����������A�\�����s���X�N���v�g
    /// </summary>
    private void Start()
    {
        // �e�X�g�p�ɐ���������
        int a = 1234567980;

        // ������UIUtility�ɃA�N�Z�X���āA���\�b�h���Ăяo���Ă���
        string b = UIUtility.NumberFormatter(a);

        // �e�X�g�p�ɐ���������
        float c = 0.45286f;

        // ������UIUtility�ɃA�N�Z�X���āA���\�b�h���Ăяo���Ă���
        string d = UIUtility.ConvertPercent(c);

        Debug.Log($"3������,����ꂽ���� : {b}");
        Debug.Log($"�p�[�Z���g�ɒ������\�� : {d}");
    }

}
