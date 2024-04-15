using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TJ
{
public class CardActions : MonoBehaviour
{
    Card card;
    public Fighter target;
    public Fighter player;
    BattleSceneManager battleSceneManager;
    private void Awake()
    {
        battleSceneManager = FindObjectOfType<BattleSceneManager>();
    }
	public void PerformAction(Card _card, Fighter _fighter)
    {
        card = _card;
        target = _fighter;
        
        switch (card.cardTitle)
        {
            case "Punch":
                AttackEnemy();
                break;
            case "Block":
                PerformBlock();
                break;
            case "Kick":
                AttackEnemy();
                ApplyBuff(Buff.Type.vulnerable);
                break;
            case "Charge":
                ApplyBuffToSelf(Buff.Type.strength);
                break;
            case "Uppercut":
                AttackEnemy();
                ApplyBuff(Buff.Type.weak);
                break;
            case "ExtraPockets":
                PerformBlock();
                battleSceneManager.DrawCards(2);
                battleSceneManager.energy+=2;
                break;
            case "Fireball":
                AttackEnemy();
                break;
            case "MagicBlock":
                MagicBlock();
                break;
            case "Dodge":
                PerformBlock();
                break;
            case "PocketSand":
                AttackEnemy();
                ApplyBuff(Buff.Type.vulnerable);
                ApplyBuff(Buff.Type.weak);
                break;
            default:
                Debug.Log("theres an issue");
                break;
        }
    }
    private void AttackEnemy()
    {
        int totalDamage = card.GetCardEffectAmount()+player.strength.buffValue;
        if(target.vulnerable.buffValue>0)
        {
            float a = totalDamage*1.5f;
            Debug.Log("incrased damage from "+totalDamage+" to "+(int)a);
            totalDamage = (int)a;
        }
        target.TakeDamage(totalDamage);
    }
    private void AttackStrength()
    {
        int totalDamage = card.GetCardEffectAmount()+(player.strength.buffValue*3);
        if(target.vulnerable.buffValue>0)
        {
            float a = totalDamage*1.5f;
            Debug.Log("incrased damage from "+totalDamage+" to "+(int)a);
            totalDamage = (int)a;
        }
        target.TakeDamage(totalDamage);
    }
    private void BodySlam()
    {
        int totalDamage = player.currentBlock;
        if(target.vulnerable.buffValue>0)
        {
            float a = totalDamage*1.5f;
            Debug.Log("incrased damage from "+totalDamage+" to "+(int)a);
            totalDamage = (int)a;
        }
        target.TakeDamage(totalDamage);
    }
    private void MagicBlock()
    {
        player.AddBlock(player.currentBlock);
    }
    private void ApplyBuff(Buff.Type t)
    {
        target.AddBuff(t, card.GetBuffAmount());
    }
    private void ApplyBuffToSelf(Buff.Type t)
    {
        player.AddBuff(t, card.GetBuffAmount());
    }
    private void AttackSelf()
    {
        player.TakeDamage(2);
    }
    private void PerformBlock()
    {
        player.AddBlock(card.GetCardEffectAmount());
    }
}
}
