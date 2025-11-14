using UnityEngine;

/// <summary>
/// ゲーム管理、子クラスでシングルトンを継承する
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [Header("テスト用変数")]
    public int testNumber = 0;

    /// <summary>
    /// テスト用のデバッグログを種強くするメソッド
    /// </summary>
    public void OutputTestDebugLog()
    {
        Debug.Log($"現在設定されているテスト変数 : {testNumber}");
    }
}
