using UnityEngine;
using UnityEngine.Events;

public class BaseEnemy : MonoBehaviour
{
    public enum EnemyTypes // TODO : Replace this by real Enemy class
    {
        LesFDPQuiCourts,
        LesFDPQuiTirent,
        LesDronesDeFDP
    }

    [SerializeField] private EnemyTypes _enemyType;
    [SerializeField] protected Transform _targetTransform;
    public EnemyTypes EnemyType => _enemyType;

    public event UnityAction OnDeathCallback;

    public void SetTarget(Transform targetTransform)
    {
        this._targetTransform = targetTransform;
    }
    
    protected virtual void OnDestroy()
    {
        Core.GameManager.Instance.PlaySoundNormalExplosion();
        OnDeathCallback?.Invoke();
    }
}
