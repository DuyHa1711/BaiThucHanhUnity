using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : EnemyAttack
{
    [Header("Skeleton Attack")]
    [SerializeField] protected float skelDisAttackLimit = 10f;
    [SerializeField] protected float skelAttackTime = 0.5f;
    [SerializeField] protected float skelAttackCoolDown = 2f;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.disAttackLimit = this.skelDisAttackLimit;
        this.attackTime = this.skelAttackTime;
        this.attackCoolDown = this.skelAttackCoolDown;
    }
    protected override void Attacking()
    {
        if (this.enemyCtrl.EnemyFollow.Target.position.y > transform.position.y + 0.5f ||
         this.enemyCtrl.EnemyFollow.Target.position.y < transform.position.y - 0.5f)
            return;
        base.Attacking();
    }
    protected override void Attack()
    {
        Vector3 spawPos = transform.parent.position;
        Quaternion spawRot = transform.parent.rotation;
        Transform new_Arrow = ArrowEnemySpawn.Instance.Spawn(this.GetArrowName(), spawPos, spawRot);

        AudioManager.Instance.PlaySFX("Arrow");

        this.SetRotationArrow(new_Arrow);
        base.Attack();
    }
    protected string GetArrowName()
    {
        return ArrowEnemySpawn.Instance.ArrowTwo;
    }
    protected void SetRotationArrow(Transform new_Arrow)
    {
        if (transform.parent.localScale.x == -1) new_Arrow.rotation = Quaternion.Euler(0, 0, 180);
    }
}
