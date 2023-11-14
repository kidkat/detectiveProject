using Godot;

public partial class Person : CharacterBody2D{
	[ExportCategory("General Information")]
	[Export]
	public string PersonName {get;set;}
	[Export]
	public string PersonDescription {get; set;}

	public Label label;

	public override void _Ready(){

	}
}
