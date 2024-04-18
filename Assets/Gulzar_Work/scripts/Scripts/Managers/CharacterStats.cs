using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Character/Create Character", order = 1)]
public class CharacterStats : ScriptableObject
{
    public string characterName;
    [Range(0, 1)]
    public float power;
    [Range(0, 1)]
    public float range;
    [Range(0, 1)]
    public float reload;
    [Range(0, 1)]
    public float damage;
    public int Price;
}
