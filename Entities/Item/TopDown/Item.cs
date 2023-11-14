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
		label = GetNode<Label>("ItemName");
		label.Text = this.Name;

		this.BodyEntered += (body) => this.OnBodyEnteredOrExited(body);
		this.BodyExited += (body) => this.OnBodyEnteredOrExited(body);
	}

	public void OnBodyEnteredOrExited(Node2D body){
		if(body is CharacterBody2D && body.IsInGroup("Player")){
			label.Visible = !label.Visible;
		}
	}
}
