using UnityEngine;

public class FactoryTest : MonoBehaviour
{
    [Header("エネミーファクトリー")]
    [SerializeField] private EnemyFactory enemyFactory = null;

    // 座標移動用オフセット
    private float positionOffset = -10.0f;

    /// <summary>
    /// 更新
    /// </summary>
    private void Update()
    {
        // Zキーを押したときに丸形エネミーを生成する
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // GasmeObject型の変数を作り、CreateEnemyへ渡す引数としてEnemyKind.Sphereを指定して丸形エネミーを生成する
            GameObject enemy = enemyFactory.CreateEnemy(EnemyKind.Sphere);
            SetEnemyPosition(enemy);
        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            // Xキーを押したときに直方体エネミーを生成する
            // GasmeObject型の変数を作り、CreateEnemyへ渡す引数としてEnemyKind.Cubeを指定して直方体エネミーを生成する
            GameObject enemy = enemyFactory.CreateEnemy(EnemyKind.Cube);
            SetEnemyPosition(enemy);
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            // Cキーを押したときにカプセル型エネミーを生成する
            // GasmeObject型の変数を作り、CreateEnemyへ渡す引数としてEnemyKind.Capsuleを指定してカプセル型エネミーを生成する
            GameObject enemy = enemyFactory.CreateEnemy(EnemyKind.Capsule);
            SetEnemyPosition(enemy);
        }
    }

    /// <summary>
    /// エネミーを少しずつずらして配置する
    /// </summary>
    private void SetEnemyPosition(GameObject enemy)
    {
        // 生成したエネミーをpositionOffset分X方向にずらして配置する
        enemy.transform.position = new Vector3(positionOffset, 0.0f, 0.0f);

        // 次回生成時にさらにずらすためにpositionOffsetをインクリメントする
        positionOffset += 1.0f;
    }
}
