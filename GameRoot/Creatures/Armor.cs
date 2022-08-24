using DungeonLibrary.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Armor : Item
    {

        public int AttributeBonus { get; }
        public ArmorMat Material { get; set; }
        public ArmorSlot Slot { get; }


        public Armor(string name, int amount, ItemType type, string description, bool isUseable, ArmorMat material) : base(name, amount, type, description, isUseable)
        {
            Material = material;
            switch (Material)
            {
                case ArmorMat.Iron:
                    AttributeBonus = 1;
                    break;
                case ArmorMat.Steel:
                    AttributeBonus = 2;
                    break;
                case ArmorMat.Adamantite:
                    AttributeBonus = 3;
                    break;
                case ArmorMat.Gold:
                    AttributeBonus = 4;
                    break;
                case ArmorMat.Void:
                    AttributeBonus = 5;
                    break;
                default:
                    break;
            }//end Material switch
            switch (Name)
            {
                case "Chestplate":
                    Slot = ArmorSlot.Chest;
                    break;
                case "Platelegs":
                    Slot = ArmorSlot.Legs;
                    break;
                case "Helm":
                    Slot = ArmorSlot.Head;
                    break;
                default:
                    break;
            }//end Slot switch
            
        }


        public override void UseItem(Player player){}

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"Quantity: {Amount}\n" +
                   $"Type: {Type}\n" +
                   $"Description: {Description} made of {Material}.\nSlot: {Slot}\n";
        }

        public static Armor GetArmor()
        {
            Random rand = new Random();
            ArmorMat Iron = ArmorMat.Iron;
            ArmorMat Steel = ArmorMat.Steel;
            ArmorMat Adamantite = ArmorMat.Adamantite;
            ArmorMat Gold = ArmorMat.Gold;
            ArmorMat Void = ArmorMat.Void;
            List<ArmorMat> materials = new List<ArmorMat>()
            {
                Iron, Iron, Iron, Iron, Iron, Iron, Iron, Iron,
                Steel, Steel, Steel, Steel, Steel,
                Adamantite, Adamantite, Adamantite,
                Gold, Gold,
                Void
            };

            Armor chestPiece = new Armor("Chestplate", 1, ItemType.Armor, "A sturdy Chestplate", false, materials[rand.Next(materials.Count())]);
            Armor platelegs = new Armor("Platelegs", 1, ItemType.Armor, "A well-crafted set of Platelegs", false, materials[rand.Next(materials.Count())]);
            Armor helmet = new Armor("Helm", 1, ItemType.Armor, "A strong Helm", false, materials[rand.Next(materials.Count())]);

            List<Armor> pieces = new List<Armor>()
            {
                chestPiece, chestPiece,
                platelegs, platelegs,
                helmet, helmet,
            };

            return pieces[rand.Next(pieces.Count())];
        }

    }
}
