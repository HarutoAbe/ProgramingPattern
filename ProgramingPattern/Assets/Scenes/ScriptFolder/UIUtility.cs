/// <summary>
/// ユーティリティクラス
/// </summary>
public static class UIUtility
{
    // static はアクセスしたら生成される
    // インスタンスはある
    // 今回MonoBehaviourを継承していないのは、Unityでアタッチしないから

    /// <summary>
    /// 3桁ごとに「,」を挿入下文字列を生成する
    /// </summary>
    public static string NumberFormatter(int number)
    {
        // このフォーマットを利用すると、3桁ごとに「,」を挿入できる
        return number.ToString("#,0");
    }

    /// <summary>
    /// 数値をパーセント表示に変更(少数第2位まで)
    /// </summary>
    public static string ConvertPercent(float ratio)
    {
        // パーセント表示に変換
        float convertRatio = ratio * 100.0f;

        // 少数第2位まで表示して、文字列として返す
        return convertRatio.ToString("F2") + "%";
    }
}
