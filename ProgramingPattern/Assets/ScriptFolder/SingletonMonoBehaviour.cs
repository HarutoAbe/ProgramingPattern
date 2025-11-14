using UnityEngine;
using System;

/// <summary>
/// シングルトンクラス、親クラス、継承元
/// </summary>
public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    // abstractとは、継承先で必ず設定するもの、実装を持たずに定義だけするもの
    // whereとは、クラスを指定の型に制限するためもの
    // static とはクラス依存のメソッド、変数
    // staticなしはインスタンス依存
　
    // ジェネリック型の変数を宣言する
    private static T instance;

    /// <summary>
    /// Singletonのインスタンスを取得するプロパティ
    /// </summary>
    public static T Instance
    {
        // Instanceは変数
        // だが、メソッドとして扱っても良い
        // この中の処理でインスタンスを取得する
        get
        {
            // インスタンスがnullの時
            if (instance == null)
            {
                // typeofで型の情報を取得
                // テンプレートの型Tの情報を取得して、Type型の変数tに代入する
                Type t = typeof(T);

                // 型tを持っている最初のオブジェクトを探す
                // Firstなのは、シングルトンは一つと確証されているからである
                instance = (T)FindFirstObjectByType(t);

                // 見つからなかった時
                if (instance == null)
                {
                    // エラー文を出力する
                    Debug.LogError(t + " をアタッチしているGameObjectはありません");
                }
            }

            // インスタンスを返す
            return instance;
        }
    }

    /// <summary>
    /// インスタンス確認メソッドを呼び出すメソッド
    /// </summary>
    virtual protected void Awake()
    {
        // 他のゲームオブジェクトにアタッチされているか調べる
        // アタッチされている場合は破棄する。
        CheckInstance();
    }

    /// <summary>
    /// インスタンスの確認メソッド
    /// </summary>
    protected bool CheckInstance()
    {
        // インスタンスがnullの時
        if (instance == null)
        {
            // キャスト…他の型に変えること
            // as : キャスト
            // asは失敗したらnullを返す
            // ToStringもキャスト
            // thisとはインスタンスを指す
            // instanceにthisをキャストして代入
            instance = this as T;

            // trueを返す
            return true;
        }
        else if (Instance == this)
        {
            // 自分がインスタンスだったときはtrueを返す
            return true;
        }

        // Unity上ではリムーブしていることになる
        Destroy(this);

        // falseを返す
        return false;
    }
}
