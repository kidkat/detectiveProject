using Godot;

public partial class Item : Node2D{
    [ExportCategory("Item Data")]
    [Export]
    private string _itemName { get; set; }
    [Export]
    private string _itemDescription { get; set; }
}
