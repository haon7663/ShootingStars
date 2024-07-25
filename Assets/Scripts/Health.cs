using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [HideInInspector] public Player player;
    
    [SerializeField] private float maxHp;
    [SerializeField] private Image hpBar;

    [SerializeField] private SpriteRenderer[] spriteRenderers;
    
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material whiteMaterial;

    [SerializeField] private DamageTMP damageHudPrefab;

    [SerializeField] private Transform worldCanvas;
    
    private bool isInv, isDashInv;
    private float _curHp;

    private void Awake()
    {
        _rigidbody2D = GetComponentInParent<Rigidbody2D>();
        player = GetComponentInParent<Player>();
        _curHp = maxHp;
    }

    public bool OnDamage(float damage, Vector2 angleVec)
    {
        if (isInv || isDashInv || !BattleManager.Inst.isPlaying) return false;
        
        _curHp -= damage;
        hpBar.fillAmount = _curHp / maxHp;

        var hud = Instantiate(damageHudPrefab, worldCanvas);
        hud.Setup(transform, (int)damage);

        _rigidbody2D.AddForce(angleVec * 6, ForceMode2D.Impulse);
        isInv = true;
        OnInvincibility(0.75f);
        OnWhite(0.1f);

        if (_curHp <= 0)
        {
            BattleManager.Inst.isPlaying = false;
            GameManager.Inst.SetGameStats(player.playerNumber == PlayerNumber.Pl1 ? PlayerGameStat.P1 : PlayerGameStat.P2);
            Fade.Inst.FadeIn();
        }

        return true;
    }
    
    public void OnInvincibility(float time)
    {
        var sequence = DOTween.Sequence();
        
        sequence.AppendCallback(() =>
        {
            foreach (var spriteRenderer in spriteRenderers)
            {
                var color = spriteRenderer.color;
                spriteRenderer.color = new Color(color.r, color.g, color.b, 0.4f);
            }
        });
        sequence.AppendInterval(time);
        sequence.AppendCallback(() =>
        {
            foreach (var spriteRenderer in spriteRenderers)
            {
                var color = spriteRenderer.color;
                spriteRenderer.color = new Color(color.r, color.g, color.b, 1);
            }
            isInv = false;
        });
    }

    public void OnDashInv(float time)
    {
        var sequence = DOTween.Sequence();
        
        isDashInv = true;
        sequence.AppendCallback(() =>
        {
            foreach (var spriteRenderer in spriteRenderers)
            {
                var color = spriteRenderer.color;
                spriteRenderer.color = new Color(color.r, color.g, color.b, 0.5f);
            }
        });
        sequence.AppendInterval(time);
        sequence.AppendCallback(() =>
        {
            foreach (var spriteRenderer in spriteRenderers)
            {
                var color = spriteRenderer.color;
                spriteRenderer.color = new Color(color.r, color.g, color.b, 1);
            }
            isDashInv = false;
        });
    }

    private void OnWhite(float time)
    {
        var sequence = DOTween.Sequence();

        sequence.AppendCallback(() =>
        {
            foreach (var spriteRenderer in spriteRenderers)
            {
                spriteRenderer.material = whiteMaterial;
            }
        });
        sequence.AppendInterval(time);
        sequence.AppendCallback(() =>
        {
            foreach (var spriteRenderer in spriteRenderers)
            {
                spriteRenderer.material = defaultMaterial;
            }
        });
    }
}

