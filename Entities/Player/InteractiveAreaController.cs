using Godot;
using Godot.Collections;

public partial class InteractiveAreaController : Area2D{
	[Signal]
	public delegate void InteractedEventHandler(Array<Item> itemList, Array<Person> personList);

	[ExportCategory("Interaction Variables")]
    [Export]
    private StringName _ignoreAreaGroupName;
    [Export]
    private StringName _ignoreBodyGroupName;
    [Export]
    private StringName _actionNameForIntecation;

    private Array<Area2D> _interactiveItemList; 
	private Array<Node2D> _interactivePersonList;

	public override void _Ready(){
        _interactiveItemList = new();
        _interactivePersonList = new();

        this.AreaEntered += (area) => this.AddInteractAreaToList(area);
		this.AreaExited += (area) => this.RemoveInteractAreaFromList(area);
		this.BodyEntered += (body) => this.AddInteractBodyToList(body);
		this.BodyExited += (body) => this.RemoveInteractBodyToList(body);
    }

    public override void _Input(InputEvent @event){
        this.InputProcess(@event);
    }

	private void InputProcess(InputEvent inputEvent){
		if(inputEvent.IsActionPressed(_actionNameForIntecation)){
			if(_interactiveItemList.Count > 0 || _interactivePersonList.Count > 0){
                GD.Print("Interaction Happened!");
                EmitSignal(SignalName.Interacted, _interactiveItemList, _interactivePersonList);
            }
		}
	}

	private void AddInteractBodyToList(Node2D body){
		if(!body.IsInGroup(_ignoreBodyGroupName) && body.IsInGroup("Person")){
			_interactivePersonList.Add(body);
			GD.Print("Added to InteractBody: " + body.Name);
        }
	}

	private void RemoveInteractBodyToList(Node2D body){
		if(!body.IsInGroup(_ignoreBodyGroupName) && body.IsInGroup("Group")){
			_interactivePersonList.Remove(body);
			GD.Print("Removed from InteractBody: " + body.Name);
		}
	}

	private void AddInteractAreaToList(Area2D area){
        if (!area.IsInGroup(_ignoreAreaGroupName) && area.IsInGroup("Item")){
            _interactiveItemList.Add(area);
            GD.Print("Added to InteractArea: " + area.Name);
        }
    }

	private void RemoveInteractAreaFromList(Area2D area){
        if (!area.IsInGroup(_ignoreAreaGroupName) && area.IsInGroup("Item")){
            _interactiveItemList.Remove(area);
			GD.Print("Removed from InteractArea: " + area.Name);
        }
    }
}
