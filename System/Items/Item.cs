using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New item";
    public Sprite icon = null;
    public string type = "";

    public virtual void Use()
    {
        Debug.Log("Using" + name);
    }
    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
