using UnityEngine;

/// <summary>
/// 数字の確認をするためのクラス
/// </summary>
public class TestScripts : MonoBehaviour
{
    /// <summary>
    /// 数字を入れる、表示を行うスクリプト
    /// </summary>
    private void Start()
    {
        // テスト用に数字を入れる
        int a = 1234567980;

        // ここでUIUtilityにアクセスして、メソッドを呼び出している
        string b = UIUtility.NumberFormatter(a);

        // テスト用に数字を入れる
        float c = 0.45286f;

        // ここでUIUtilityにアクセスして、メソッドを呼び出している
        string d = UIUtility.ConvertPercent(c);

        Debug.Log($"3桁ずつ,を入れた数字 : {b}");
        Debug.Log($"パーセントに直した表示 : {d}");
    }

}
