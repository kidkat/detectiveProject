using Godot;
using Godot.Collections;
using System;

public partial class PopUpNameComponent : Area2D{
	[Export]
    private Label _popUpLabel;
    [Export]
    private Array<StringName> _popUpAreaTrigerGroups;
	public override void _Ready(){
        Node2D parent = GetParentOrNull<Node2D>();
		if(parent == null || _popUpLabel == null){
            GD.PrintErr("PopUpNameComponent:> No Parent/No Label found! Check it!");

            return;
        }

        _popUpLabel.Text = parent.Name;
        this.BodyEntered += (body) => this.OnBodyEnteredExited(body);
        this.BodyExited += (body) => this.OnBodyEnteredExited(body);

		GD.Print("PopUpNameComponent:> ", GetParent().Name, ":> Component ready with label: ", _popUpLabel.Text);
    }

	private void OnBodyEnteredExited(Node2D body){
        GD.Print("PopUpNameComponent:> ", GetParent().Name, "Body with name: ", body.Name, " Entered/Exited Area!");

		foreach(StringName popUpTriggerGroup in _popUpAreaTrigerGroups){
			if(body.IsInGroup(popUpTriggerGroup)){
				GD.Print("PopUpNameComponent:> ", GetParent().Name, ":> Body is in TriggerGroup: ", popUpTriggerGroup, " Changing visible to: ", !_popUpLabel.Visible);
            	_popUpLabel.Visible = !_popUpLabel.Visible;
			}
		}
    }
}
