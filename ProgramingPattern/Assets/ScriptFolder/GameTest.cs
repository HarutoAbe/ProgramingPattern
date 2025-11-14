using UnityEngine;

/// <summary>
/// 動作確認用のクラス
/// </summary>
public class GameTest : MonoBehaviour
{
    /// <summary>
    /// 操作確認用のメソッド
    /// </summary>
    private void Update()
    {
        // Aキーが押されたら、GameManagerにあるデバッグログを出力するメソッドを呼び出す
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameManager.Instance.OutputTestDebugLog();
        }

        // Sキーが押されたら、GameManagerにあるテスト用変数をインクリメントする
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameManager.Instance.testNumber++; ;
        }
    }
}
