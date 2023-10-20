using Godot;

public partial class Item : Area2D{
	[ExportCategory("General Information")]
	[Export]
	public string ItemName {get;set;}
	[Export]
	public string Description {get; set;}
	[ExportCategory("Available Actions")]
	[Export]
	public bool IsPickable {get; set;}
	[Export]
	public bool IsClue {get;set;}
	[Export]
	public bool IsNoted {get;set;}
	// [Export]
	// public bool LabelVisible = false;
	public Label label;

	public override void _Ready(){
		label = GetNode<Label>("Label");
		label.Text = this.Name;
	}

	public void OnBodyEnteredOrExited(Node2D body){
		if(body is CharacterBody2D && (body.Name == "PlayerTopDown" || body.IsInGroup("Player"))){
			label.Visible = !label.Visible;
			// LabelVisible = !LabelVisible;
		}
	}
}
