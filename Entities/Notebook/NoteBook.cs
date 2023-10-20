using System;
using Godot;
using Godot.Collections;

public partial class NoteBook : Node2D{
	[ExportCategory("Item List")]
	[Export]
	private Array<Item> notes;
	public override void _Ready(){
		NoteBook.Connect("Note_Added", "_On_Note_Added");
	}

	public override void _Process(double delta){

	}

	public void _On_Note_Added(){

	}
}
