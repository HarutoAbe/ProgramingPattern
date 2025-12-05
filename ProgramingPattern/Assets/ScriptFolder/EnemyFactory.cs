using System.Net.Security;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.VersionControl;
using UnityEngine;

// ファクトリー
// publicメソッドは一つのみ↓
// メソッド一つあればできることは一つで済ます
// 内部で呼び出すならprivateにしておく
// メソッドの切り分けをし、修正しやすいようにする
// returnで返す型は少なくする。その方が無難

// 敵の種類
public enum EnemyKind : int
{
    // 先頭が0だと確証させるために0を代入
    [Tooltip("丸形エネミー")]Sphere = 0,
    [Tooltip("立方体エネミー")]Cube,
    [Tooltip("カプセル型エネミー")]Capsule,
}

/// <summary>
/// 敵生成ファクトリー
/// </summary>
public class EnemyFactory : MonoBehaviour
{
    [Header("丸形エネミープレハブ")]
    [SerializeField] private GameObject sphereEnemy = null;

    [Header("立方体エネミープレハブ")]
    [SerializeField] private GameObject cubeEnemy = null;

    [Header("カプセル型エネミープレハブ")]
    [SerializeField] private GameObject capsuleEnemy = null;

    /// <summary>
    /// エネミー生成のアクセサ
    /// </summary>
    public GameObject CreateEnemy(EnemyKind kind)
    {

        // 返却用インスタンス
        GameObject enemyInstance = null;

        // エネミー別生成メソッド切り替え
        switch (kind)
        {
            case EnemyKind.Sphere:
                enemyInstance = CreateSphereEnemy();
                break;

            case EnemyKind.Cube:
                enemyInstance = CreateCubeEnemy();
                break;

            case EnemyKind.Capsule:
                enemyInstance = CreateCapsuleEnemy();
                break;
            default:
                //Debug.LogError("想定されていないタイプの生成エネミーの種類が渡されました。");
                
                break;
        }

        // 生成したエネミーインスタンスを返却
        return enemyInstance;
    }

    /// <summary>
    /// 丸形エネミー生成
    /// </summary>
    private GameObject CreateSphereEnemy()
    {
        // 生成して返却
        return Instantiate(sphereEnemy);
    }

    /// <summary>
    /// 立方体エネミー完成
    /// </summary>
    private GameObject CreateCubeEnemy()
    {
        // 生成して返却
        return Instantiate(cubeEnemy);
    }

    /// <summary>
    /// カプセル型エネミー生成
    /// </summary>
    private GameObject CreateCapsuleEnemy()
    {
        // 生成して返却
        return Instantiate(capsuleEnemy);
    }

}
