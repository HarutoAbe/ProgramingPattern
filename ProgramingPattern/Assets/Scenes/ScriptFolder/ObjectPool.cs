using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 汎用オブジェクトプール
/// </summary>
public class ObjectPool<T> where T : Component
{
    // Enqueueで登録、Dequeueで取り出すを繰り返す
    // 自動で生成したやつも登録しなおせる
    // Componentは大体のものの親
    // GameObjectは対象外
    // もうそのオブジェクトを使用しないときは、情報を初期に戻してプールに再登録する
    // Tは複数の型に対応できるもの

    // 生成プレハブ
    private T prefab = null;

    // プール管理キュー
    private Queue<T> pool = new Queue<T>();

    // 生成オブジェクトをまとめる親トランスフォーム
    private Transform parent = null;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public ObjectPool(T prefab, int initialSize, Transform parent = null)
    {
        // プレハブと親を設定
        this.prefab = prefab;
        this.parent = parent;

        // 初期生成
        // 最初に生成した分だけ登録
        for (int i = 0; i < initialSize; i++)
        {
            // オブジェクト生成メソッドへアクセス
            T obj = CreateNewObject();

            // プールに登録をする
            pool.Enqueue(obj);
        }
    }

    /// <summary>
    /// 新規オブジェクト生成
    /// </summary>
    private T CreateNewObject()
    {
        // オブジェクト生成
        T obj = GameObject.Instantiate(prefab, parent);

        // 非アクティブにする
        obj.gameObject.SetActive(false);

        // 生成したオブジェクトを返す
        return obj;
    }

    /// <summary>
    /// オブジェクトを取り出す
    /// </summary>
    public T Get()
    {
        // プールにオブジェクトがあればプールから取得
        if (pool.Count > 0)
        {
            // プールから生成したオブジェクトを取り出す
            T obj = pool.Dequeue();

            // 取り出したオブジェクトをアクティブにする
            obj.gameObject.SetActive(true);

            // 取り出したオブジェクトを返す
            return obj;
        }
        else
        {
            // 足りない場合は新しく生成する
            return CreateNewObject();
        }
    }

    /// <summary>
    /// オブジェクトを返却する
    /// </summary>
    public void Release(T obj)
    {
        // オブジェクトを非アクティブにする
        obj.gameObject.SetActive(false);

        // プールに登録する
        pool.Enqueue(obj);
    }
}
