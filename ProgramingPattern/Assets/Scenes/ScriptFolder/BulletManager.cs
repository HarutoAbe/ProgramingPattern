using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// prefabを生成し、プール化して管理する
/// </summary>
public class BulletManager : MonoBehaviour
{
    [Header("プール化するオブジェクトプレハブ")]
    public GameObject bullet = null;

    // オブジェクトプール
    private ObjectPool<Bullet> bulletPool = null;

    // 借りているオブジェクト保管用リスト
    private List<Bullet> bulletList = new List<Bullet>();

    // 位置補正用
    private float offsetPosition = 0.0f;

    /// <summary>
    /// 初期化
    /// </summary>
    private void Start()
    {
        // オブジェクトプールを新しく作る
        bulletPool = new ObjectPool<Bullet>(bullet.GetComponent<Bullet>(), 100, transform);
    }

    /// <summary>
    /// 更新
    /// </summary>
    private void Update()
    {
        // Fキーを押して一個出現させる
        if (Input.GetKeyDown(KeyCode.F))
        {
            // 取り出したオブジェクトをBullet型の変数に格納
            Bullet obj = bulletPool.Get();

            // 位置をずらす
            obj.transform.position = new Vector3(offsetPosition, 0.0f, 0.0f);

            // リストに登録する
            bulletList.Add(obj);

            // 位置補正の値を増やす
            offsetPosition += 1.0f;
        }

        // Rキーを押して一番古い弾を消す
        if (Input.GetKeyDown(KeyCode.R))
        {
            // リストの一番古いオブジェクトを非アクティブにしてプールに返す
            bulletPool.Release(bulletList[0]);

            // リストから削除
            bulletList.RemoveAt(0);
        }
    }
}
