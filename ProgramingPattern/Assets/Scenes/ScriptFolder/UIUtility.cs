/// <summary>
/// ���[�e�B���e�B�N���X
/// </summary>
public static class UIUtility
{
    // static �̓A�N�Z�X�����琶�������
    // �C���X�^���X�͂���
    // ����MonoBehaviour���p�����Ă��Ȃ��̂́AUnity�ŃA�^�b�`���Ȃ�����

    /// <summary>
    /// 3�����ƂɁu,�v��}����������𐶐�����
    /// </summary>
    public static string NumberFormatter(int number)
    {
        // ���̃t�H�[�}�b�g�𗘗p����ƁA3�����ƂɁu,�v��}���ł���
        return number.ToString("#,0");
    }

    /// <summary>
    /// ���l���p�[�Z���g�\���ɕύX(������2�ʂ܂�)
    /// </summary>
    public static string ConvertPercent(float ratio)
    {
        // �p�[�Z���g�\���ɕϊ�
        float convertRatio = ratio * 100.0f;

        // ������2�ʂ܂ŕ\�����āA������Ƃ��ĕԂ�
        return convertRatio.ToString("F2") + "%";
    }
}
