using Godot;

public partial class Item : Area2D{
	[ExportCategory("General Information")]
	[Export]
	public string itemName {get;set;}
	[Export]
	public string description {get; set;}
	[ExportCategory("Available Actions")]
	[Export]
	public bool isPickable {get; set;}
	[Export]
	public bool isClue {get;set;}
	[Export]
	public bool isNoted {get;set;}
	public Label label;

	public override void _Ready(){
		label = GetNode<Label>("Label");
		label.Text = this.Name;
	}

	public void OnBodyEnteredOrExited(Node2D body){
		if(body is CharacterBody2D && (body.Name.Equals("PlayerTopDown") || body.IsInGroup("Player"))){
			label.Visible = !label.Visible;
		}
	}
}
